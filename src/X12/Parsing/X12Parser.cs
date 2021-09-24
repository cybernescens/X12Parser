using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X12.Model;

namespace X12.Parsing
{
  public class X12Parser : IX12Parser
  {
    public ParserSettings Settings { get; }

    public X12Parser(ParserSettings settings) { Settings = settings; }
    
    public IList<Interchange> Parse(string x12, Encoding encoding = null)
    {
      encoding ??= Settings.DefaultEncoding;
      var ba = encoding.GetBytes(x12);
      using var ms = new MemoryStream(ba);
      return Parse(ms);
    }

    public IList<Interchange> Parse(Stream stream, Encoding encoding = null)
    {
      encoding ??= Settings.DefaultEncoding;
      var envelopes = new List<Interchange>();

      using var reader = new X12StreamReader(stream, encoding, Settings.IgnoredCharacters);
      var envelop = new Interchange(Settings.SpecificationFinder, reader.CurrentIsaSegment);
      envelopes.Add(envelop);
      Container currentContainer = envelop;
      FunctionGroup fg = null;
      Transaction tr = null;
      var hloops = new Dictionary<string, HierarchicalLoop>();

      var segmentString = reader.ReadNextSegment();
      var segmentId = reader.ReadSegmentId(segmentString);
      var segmentIndex = 1;
      var containerStack = new Stack<string>();
      while (segmentString.Length > 0)
      {
        switch (segmentId)
        {
          case "ISA":
            envelop = new Interchange(Settings.SpecificationFinder, segmentString + reader.Delimiters.SegmentTerminator);
            envelopes.Add(envelop);
            currentContainer = envelop;
            fg = null;
            tr = null;
            hloops = new Dictionary<string, HierarchicalLoop>();
            break;
          case "IEA":
            if (envelop == null)
              throw new InvalidOperationException(
                $"Segment {segmentString} does not have a matching ISA segment preceding it.");

            envelop.SetTerminatingTrailerSegment(segmentString);
            break;
          case "GS":
            if (envelop == null)
              throw new InvalidOperationException(
                $"Segment '{segmentString}' cannot occur before and ISA segment.");

            currentContainer = fg = envelop.AddFunctionGroup(segmentString);
            ;
            break;
          case "GE":
            if (fg == null)
              throw new InvalidOperationException(
                $"Segment '{segmentString}' does not have a matching GS segment precending it.");

            fg.SetTerminatingTrailerSegment(segmentString);
            fg = null;
            break;
          case "ST":
            if (fg == null)
              throw new InvalidOperationException(
                $"segment '{segmentString}' cannot occur without a preceding GS segment.");

            segmentIndex = 1;
            currentContainer = tr = fg.AddTransaction(segmentString);
            hloops = new Dictionary<string, HierarchicalLoop>();
            break;
          case "SE":
            if (tr == null)
              throw new InvalidOperationException(
                $"Segment '{segmentString}' does not have a matching ST segment preceding it.");

            tr.SetTerminatingTrailerSegment(segmentString);
            tr = null;
            break;
          case "HL":
            var hlSegment = new Segment(null, reader.Delimiters, segmentString);
            var id = hlSegment.GetElement(1);
            var parentId = hlSegment.GetElement(2);
            var levelCode = hlSegment.GetElement(3);

            while (!(currentContainer is HierarchicalLoopContainer) ||
              !((HierarchicalLoopContainer)currentContainer).AllowsHierarchicalLoop(levelCode))
              if (currentContainer.Parent != null)
                currentContainer = currentContainer.Parent;
              else
                throw new InvalidOperationException(
                  $"Heierchical Loop {segmentString}  cannot be added to transaction set {tr.ControlNumber} because it's specification cannot be identified.");

            var parentFound = false;
            if (parentId != string.Empty)
            {
              if (hloops.ContainsKey(parentId))
              {
                parentFound = true;
                currentContainer = hloops[parentId].AddHLoop(segmentString);
              }
              else
              {
                if (Settings.ThrowExceptionOnSyntaxErrors)
                  throw new InvalidOperationException(
                    $"Hierarchical Loop {id} expects Parent ID {parentId} which did not occur preceding it. To change this to a warning, pass ParserConfiguration.ThrowExceptionOnSyntaxErrors = false to the X12Parser.");

                Settings.OnParserWarning?.Invoke(
                  this,
                  new X12ParserWarningEventArgs {
                    FileIsValid = false,
                    InterchangeControlNumber = envelop.InterchangeControlNumber,
                    FunctionalGroupControlNumber = fg.ControlNumber,
                    TransactionControlNumber = tr.ControlNumber,
                    SegmentPositionInInterchange = segmentIndex,
                    Segment = segmentString,
                    SegmentId = segmentId,
                    Message = $"Hierarchical Loop {id} expects Parent ID {parentId} which did not occur preceding it.  This will be parsed as if it has no parent, but the file may not be valid."
                  });
              }
            }

            if (parentId == string.Empty || !parentFound)
            {
              while (!(currentContainer is HierarchicalLoopContainer container && container.HasHierarchicalSpecification()))
                currentContainer = currentContainer.Parent;

              currentContainer = ((HierarchicalLoopContainer)currentContainer).AddHLoop(segmentString);
              //hloops = new Dictionary<string, HierarchicalLoop>();
            }

            if (hloops.ContainsKey(id))
              throw new InvalidOperationException(
                $"Hierarchical Loop {segmentString} cannot be added to transaction {tr.ControlNumber} because the ID {id} already exists.");

            hloops.Add(id, (HierarchicalLoop)currentContainer);
            break;
          case "TA1": // Technical acknowledgement
            if (envelop == null)
              throw new InvalidOperationException(
                $"Segment {segmentString} does not have a matching ISA segment preceding it.");

            envelop.AddSegment(segmentString);
            break;
          default:
            var originalContainer = currentContainer;
            containerStack.Clear();
            while (currentContainer != null)
            {
              if (currentContainer.AddSegment(segmentString) != null)
              {
                if (segmentId == "LE")
                  currentContainer = currentContainer.Parent;

                break;
              }

              if (currentContainer is not LoopContainer loop)
                continue;

              var newLoop = loop.AddLoop(segmentString);
              if (newLoop != null)
              {
                currentContainer = newLoop;
                break;
              }

              if (currentContainer is Transaction)
              {
                var tran = (Transaction)currentContainer;

                if (Settings.ThrowExceptionOnSyntaxErrors)
                {
                  throw new TransactionValidationException(
                    "Segment '{3}' in segment position {4} within transaction '{1}' cannot be identified within the supplied specification for transaction set {0} in any of the expected loops: {5}.  To change this to a warning, pass ParserConfiguration.ThrowExceptionOnSyntaxErrors = false to the X12Parser.",
                    tran.IdentifierCode,
                    tran.ControlNumber,
                    "",
                    segmentString,
                    segmentIndex,
                    string.Join(",", containerStack));
                }

                currentContainer = originalContainer;
                currentContainer.AddSegment(segmentString, true);
                Settings.OnParserWarning?.Invoke(
                  this,
                  new X12ParserWarningEventArgs {
                    FileIsValid = false,
                    InterchangeControlNumber = envelop.InterchangeControlNumber,
                    FunctionalGroupControlNumber = fg.ControlNumber,
                    TransactionControlNumber = tran.ControlNumber,
                    SegmentPositionInInterchange = segmentIndex,
                    SegmentId = segmentId,
                    Segment = segmentString,
                    Message =
                      $"Segment '{segmentString}' in segment position {segmentIndex} within transaction '{tran.ControlNumber}' " +
                      $"cannot be identified within the supplied specification for transaction set {tran.IdentifierCode} " +
                      $"in any of the expected loops: {string.Join(",", containerStack)}.  " +
                      $"It will be added to loop {containerStack.LastOrDefault()}, but this may invalidate all subsequent segments."
                  });

                break;
              }

              if (currentContainer is Loop cloop)
                containerStack.Push(cloop.Specification.LoopId);
              else if (currentContainer is HierarchicalLoop chloop)
                containerStack.Push($"{chloop.Specification.LoopId}[{chloop.Id}]");

              currentContainer = currentContainer.Parent;
            }

            break;
        }

        segmentString = reader.ReadNextSegment();
        segmentId = reader.ReadSegmentId(segmentString);
        segmentIndex++;
      }

      return envelopes;
    }
    
    public async Task<IList<Interchange>> ParseAsync(Stream stream, Encoding encoding = null) => throw new NotImplementedException();
  }
}