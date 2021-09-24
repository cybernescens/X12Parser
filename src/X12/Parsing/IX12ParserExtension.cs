using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using X12.Model;

namespace X12.Parsing
{
  public interface IX12ParserExtension : IX12Parser
  {
    string TransformToX12(string xml);
    IList<Interchange> UnbundleByLoop(Interchange interchange, string loopId);
    IList<Interchange> UnbundleByTransaction(Interchange interchange);
  }

  public class X12ParserExtension : X12Parser, IX12ParserExtension
  {
    public X12ParserExtension(ParserSettings settings) : base(settings) { }

    public string TransformToX12(string xml)
    {
      var transform = new XslCompiledTransform();
      transform.Load(
        XmlReader.Create(
          Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("X12.Transformations.X12-XML-to-X12.xslt")));

      using var writer = new StringWriter();
      using var reader = new StringReader(xml);
      transform.Transform(XmlReader.Create(reader), new XsltArgumentList(), writer);
      return writer.GetStringBuilder().ToString();
    }

    public IList<Interchange> UnbundleByLoop(Interchange interchange, string loopId)
    {
      var terminator = interchange._delimiters.SegmentTerminator;
      var service = new UnbundlingService(interchange._delimiters.SegmentTerminator);
      var isa = interchange.SegmentString;
      var iea = interchange.Trailer.SegmentString;
      var list = new List<string>();
      foreach (var group in interchange.FunctionGroups)
        foreach (var transaction in group.Transactions)
          service.UnbundleHLoops(list, transaction, loopId);

      var interchanges = new List<Interchange>();
      foreach (var item in list)
      {
        var x12 = new StringBuilder();
        x12.AppendFormat("{0}{1}", isa, terminator);
        x12.Append(item);
        x12.AppendFormat("{0}{1}", iea, terminator);
        using var ms = new MemoryStream(Encoding.ASCII.GetBytes(x12.ToString()));
        interchanges.AddRange(Parse(ms));
      }

      return interchanges;
    }

    public IList<Interchange> UnbundleByTransaction(Interchange interchange)
    {
      var interchanges = new List<Interchange>();

      var terminator = interchange._delimiters.SegmentTerminator;
      var isa = interchange.SegmentString;
      var iea = interchange.Trailer.SegmentString;
      
      foreach (var group in interchange.FunctionGroups)
      {
        foreach (var transaction in group.Transactions)
        {
          var x12 = new StringBuilder();
          x12.AppendFormat("{0}{1}", isa, terminator);
          x12.AppendFormat("{0}{1}", group.SegmentString, terminator);
          x12.Append(transaction.SerializeToX12(false));
          x12.AppendFormat("{0}{1}", group.Trailer.SegmentString, terminator);
          x12.AppendFormat("{0}{1}", iea, terminator);
          using var ms = new MemoryStream(Encoding.ASCII.GetBytes(x12.ToString()));
          interchanges.AddRange(Parse(ms));
        }
      }

      return interchanges;
    }
  }
}