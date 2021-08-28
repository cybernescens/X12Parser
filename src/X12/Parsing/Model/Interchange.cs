﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using X12.Parsing.Specification;

namespace X12.Parsing.Model
{
  public class Interchange : Container, IXmlSerializable
  {
    private readonly List<FunctionGroup> _functionGroups;

    internal Interchange() : base(null, null, "GS") { }

    internal Interchange(ISpecificationFinder specFinder, string segmentString)
      : base(null, new X12DelimiterSet(segmentString.ToCharArray()), segmentString)
    {
      SpecFinder = specFinder;
      _functionGroups = new List<FunctionGroup>();
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

      _functionGroups = new List<FunctionGroup>();

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

    internal ISpecificationFinder SpecFinder { get; }

    public string AuthorInfoQualifier
    {
      get => GetElement(1);
      set => SetElement(1, string.Format("{0,-2}", value));
    }

    public string AuthorInfo
    {
      get => GetElement(2);
      set => SetElement(2, string.Format("{0,-10}", value));
    }

    public string SecurityInfoQualifier
    {
      get => GetElement(3);
      set => SetElement(3, string.Format("{0,-2}", value));
    }

    public string SecurityInfo
    {
      get => GetElement(4);
      set => SetElement(4, string.Format("{0,-10}", value));
    }

    public string InterchangeSenderIdQualifier
    {
      get => GetElement(5);
      set => SetElement(5, string.Format("{0,-2}", value));
    }

    public string InterchangeSenderId
    {
      get => GetElement(6);
      set => SetElement(6, string.Format("{0,-15}", value));
    }

    public string InterchangeReceiverIdQualifier
    {
      get => GetElement(7);
      set => SetElement(7, string.Format("{0,-2}", value));
    }

    public string InterchangeReceiverId
    {
      get => GetElement(8);
      set => SetElement(8, string.Format("{0,-15}", value));
    }

    public DateTime InterchangeDate
    {
      get {
        DateTime date;
        if (DateTime.TryParseExact(GetElement(9) + GetElement(10), "yyMMddHHmm", null, DateTimeStyles.None, out date))
          return date;

        if (DateTime.TryParseExact(GetElement(9), "yyMMdd", null, DateTimeStyles.None, out date))
          return date;

        throw new ArgumentException(
          string.Format(
            "{0} and {1} in ISA09 and ISA10 cannot be converted into a date and time.",
            GetElement(9),
            GetElement(10)));
      }
      set {
        SetElement(9, string.Format("{0:yyMMdd}", value));
        SetElement(10, string.Format("{0:HHmm}", value));
      }
    }

    public string InterchangeControlNumber => GetElement(13);

    public IEnumerable<FunctionGroup> FunctionGroups => _functionGroups;

    internal override IList<SegmentSpecification> AllowedChildSegments
    {
      get {
        var list = new List<SegmentSpecification>();
        return list;
      }
    }

    internal override IEnumerable<string> TrailerSegmentIds => new List<string>();

    internal FunctionGroup AddFunctionGroup(string segmentString)
    {
      var fg = new FunctionGroup(SpecFinder, this, this._delimiters, segmentString);
      _functionGroups.Add(fg);
      return fg;
    }

    public FunctionGroup AddFunctionGroup(string functionIdCode, DateTime date, int controlNumber) =>
      AddFunctionGroup(functionIdCode, date, controlNumber, "004010X096A1");

    public FunctionGroup AddFunctionGroup(string functionIdCode, DateTime date, int controlNumber, string version)
    {
      if (controlNumber > 999999999 || controlNumber < 1)
        throw new ElementValidationException(
          "Element {0} cannot containe the value '{1}' because it must be a positive number between 1 and 999999999.",
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

      _functionGroups.Add(fg);
      return fg;
    }

    internal override string SerializeBodyToX12(bool addWhitespace)
    {
      var sb = new StringBuilder();
      foreach (var fg in _functionGroups)
        sb.Append(fg.ToX12String(addWhitespace));

      return sb.ToString();
    }

    internal override string ToX12String(bool addWhitespace)
    {
      UpdateTrailerSegmentCount("IEA", 1, _functionGroups.Count);
      return base.ToX12String(addWhitespace);
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

    public virtual string Serialize(bool suppressComments)
    {
      var memoryStream = new MemoryStream();

      Serialize(memoryStream);
      memoryStream.Seek(0, SeekOrigin.Begin);
      var streamReader = new StreamReader(memoryStream);
      var xml = streamReader.ReadToEnd();

      if (suppressComments)
      {
        var doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        doc.LoadXml(xml);
        RemoveComments((XmlElement) doc.SelectSingleNode("Interchange"));

        xml = doc.OuterXml;
      }

      return xml;
    }

    public void Serialize(Stream stream)
    {
      var xmlSerializer = new XmlSerializer(GetType());

      xmlSerializer.Serialize(stream, this);
    }

    #region IXmlSerializable Members

    internal override void WriteXml(XmlWriter writer)
    {
      if (!string.IsNullOrEmpty(SegmentId))
      {
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

        foreach (var segment in Segments)
          segment.WriteXml(writer);

        foreach (var functionGroup in FunctionGroups)
          functionGroup.WriteXml(writer);

        foreach (var segment in TrailerSegments)
          segment.WriteXml(writer);
      }
    }

    #endregion
  }
}