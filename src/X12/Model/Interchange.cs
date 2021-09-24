using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public sealed class Interchange : Container
  {
    internal Interchange() : base(null, null, "GS") { }

    internal Interchange(ISpecificationFinder specFinder, string segmentString)
      : base(null, new X12DelimiterSet(segmentString.ToCharArray()), segmentString)
    {
      SpecFinder = specFinder;
    }

    public Interchange(
      ISpecificationFinder specFinder,
      DateTime date,
      int controlNumber,
      bool production,
      X12DelimiterSet delimiters)
      : base(
        null,
        delimiters,
        string.Format(
          "ISA{1}00{1}          {1}00{1}          {1}01{1}SENDERID HERE  {1}01{1}RECIEVERID HERE{1}{3:yyMMdd}{1}{3:HHmm}{1}U{1}00401{1}{4:000000000}{1}1{1}{5}{1}{2}{0}",
          delimiters.SegmentTerminator,
          delimiters.ElementSeparator,
          delimiters.SubElementSeparator,
          date,
          controlNumber,
          production ? "P" : "T"))
    {
      SpecFinder = specFinder;
      if (controlNumber > 999999999 || controlNumber < 1)
        throw new ElementValidationException(
          "{0} Interchange Control Number must be a positive number between 1 and 999999999.",
          "ISA00",
          controlNumber.ToString());

      SetTerminatingTrailerSegment(
        string.Format(
          "IEA{0}0{0}{2:000000000}{1}",
          delimiters.ElementSeparator,
          delimiters.SegmentTerminator,
          controlNumber));
    }

    public Interchange(DateTime date, int controlNumber, bool production)
      : this(new SpecificationFinder(), date, controlNumber, production, new X12DelimiterSet('~', '*', ':')) { }

    public Interchange(
      DateTime date,
      int controlNumber,
      bool production,
      char segmentTerminator,
      char elementSeparator,
      char subElementSeparator)
      : this(
        new SpecificationFinder(),
        date,
        controlNumber,
        production,
        new X12DelimiterSet(segmentTerminator, elementSeparator, subElementSeparator)) { }

    protected internal override ISpecificationFinder SpecFinder { get; }
    public override FunctionGroup Group => null;
    public Segment Trailer => _trailer;
    public IEnumerable<FunctionGroup> FunctionGroups => this._segments.OfType<FunctionGroup>();

    public string AuthorInfoQualifier
    {
      get => GetElement(1);
      set => SetElement(1, $"{value,-2}");
    }

    public string AuthorInfo
    {
      get => GetElement(2);
      set => SetElement(2, $"{value,-10}");
    }

    public string SecurityInfoQualifier
    {
      get => GetElement(3);
      set => SetElement(3, $"{value,-2}");
    }

    public string SecurityInfo
    {
      get => GetElement(4);
      set => SetElement(4, $"{value,-10}");
    }

    public string InterchangeSenderIdQualifier
    {
      get => GetElement(5);
      set => SetElement(5, $"{value,-2}");
    }

    public string InterchangeSenderId
    {
      get => GetElement(6);
      set => SetElement(6, $"{value,-15}");
    }

    public string InterchangeReceiverIdQualifier
    {
      get => GetElement(7);
      set => SetElement(7, $"{value,-2}");
    }

    public string InterchangeReceiverId
    {
      get => GetElement(8);
      set => SetElement(8, $"{value,-15}");
    }

    public DateTime InterchangeDate
    {
      get {
        if (DateTime.TryParseExact(GetElement(9) + GetElement(10), "yyyyMMddHHmm", null, DateTimeStyles.None, out var date))
          return date;

        if (DateTime.TryParseExact(GetElement(9), "yyyyMMdd", null, DateTimeStyles.None, out date))
          return date;
        
        if (DateTime.TryParseExact(GetElement(9), "yyyyMMd", null, DateTimeStyles.None, out date))
          return date;

        if (DateTime.TryParseExact(GetElement(9), "yyMMdd", null, DateTimeStyles.None, out date))
          return date;

        throw new ArgumentException(
          $"{GetElement(9)} and {GetElement(10)} in ISA09 and ISA10 cannot be converted into a date and time.");
      }
      set {
        SetElement(9, $"{value:yyMMdd}");
        SetElement(10, $"{value:HHmm}");
      }
    }

    public string InterchangeControlNumber => GetElement(13);

    protected override IList<SegmentSpecification> AllowedChildSegments => new List<SegmentSpecification>();

    //internal override IEnumerable<string> TrailerSegmentIds => new List<string>();

    internal FunctionGroup AddFunctionGroup(string segmentString)
    {
      var fg = new FunctionGroup(SpecFinder, this, this._delimiters, segmentString);
      _segments.Add(fg);
      return fg;
    }

    public FunctionGroup AddFunctionGroup(string functionIdCode, DateTime date, int controlNumber) =>
      AddFunctionGroup(functionIdCode, date, controlNumber, "004010X096A1");

    public FunctionGroup AddFunctionGroup(string functionIdCode, DateTime date, int controlNumber, string version)
    {
      if (controlNumber > 999999999 || controlNumber < 1)
        throw new ElementValidationException(
          "Element {0} cannot contain the value '{1}' because it must be a positive number between 1 and 999999999.",
          "GS06",
          controlNumber.ToString());

      var fg = new FunctionGroup(
        SpecFinder,
        this,
        this._delimiters,
        string.Format(
          "GS{0}{0}{0}{0}{0}{0}{0}X{0}{2}{1}",
          this._delimiters.ElementSeparator,
          this._delimiters.SegmentTerminator,
          version));

      fg.FunctionalIdentifierCode = functionIdCode;
      fg.Date = date;
      fg.ControlNumber = controlNumber;

      fg.SetTerminatingTrailerSegment(
        string.Format(
          "GE{0}0{0}{2}{1}",
          this._delimiters.ElementSeparator,
          this._delimiters.SegmentTerminator,
          controlNumber));

      _segments.Add(fg);
      return fg;
    }
    
    internal override string ToX12String(bool addWhitespace = false, int indent = 0, int step = 0)
    {
      UpdateTrailerSegmentCount("IEA", 1, FunctionGroups.Count());
      return base.ToX12String(addWhitespace, indent, step);
    }

    public string Serialize() => Serialize(false);

    private void RemoveComments(XmlElement element)
    {
      var comments = new List<XmlComment>();

      foreach (XmlNode childElement in element.ChildNodes)
        if (childElement is XmlComment)
          comments.Add((XmlComment) childElement);

      foreach (var comment in comments)
      {
        var prev = comment.PreviousSibling as XmlWhitespace;
        var next = comment.NextSibling as XmlWhitespace;
        if (prev != null &&
          (prev.Value != null) & prev.Value.StartsWith(Environment.NewLine) &&
          next != null &&
          next.Value != null &&
          next.Value.StartsWith(Environment.NewLine))
          element.RemoveChild(next);

        element.RemoveChild(comment);
      }

      foreach (XmlNode childElement in element.ChildNodes)
        if (childElement is XmlElement && childElement.HasChildNodes)
          RemoveComments((XmlElement) childElement);
    }

    public string Serialize(bool suppressComments)
    {
      var memoryStream = new MemoryStream();

      Serialize(memoryStream);
      memoryStream.Seek(0, SeekOrigin.Begin);
      var streamReader = new StreamReader(memoryStream);
      var xml = streamReader.ReadToEnd();

      if (!suppressComments)
        return xml;

      var doc = new XmlDocument();
      doc.PreserveWhitespace = true;
      doc.LoadXml(xml);
      RemoveComments((XmlElement) doc.SelectSingleNode("Interchange"));
      xml = doc.OuterXml;
      return xml;
    }

    public void Serialize(Stream stream)
    {
      new XmlSerializer(GetType()).Serialize(stream, this);
    }

    #region IXmlSerializable Members

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      switch (this._delimiters.SegmentTerminator)
      {
        case '\x1D':
          var terminator =
            Convert.ToBase64String(Encoding.ASCII.GetBytes(this._delimiters.SegmentTerminator.ToString()));

          writer.WriteAttributeString("segment-terminator", terminator);
          break;
        default:
          writer.WriteAttributeString("segment-terminator", this._delimiters.SegmentTerminator.ToString());
          break;
      }

      writer.WriteAttributeString("element-separator", this._delimiters.ElementSeparator.ToString());
      writer.WriteAttributeString("sub-element-separator", this._delimiters.SubElementSeparator.ToString());
      base.WriteXml(writer);

      //foreach (var segment in Segments)
      //  segment.WriteXml(writer);

      //foreach (var functionGroup in FunctionGroups)
      //  functionGroup.WriteXml(writer);

      //foreach (var segment in TrailerSegments)
      //  segment.WriteXml(writer);
    }

    #endregion
  }
}