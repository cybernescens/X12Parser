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
  public class FunctionGroup : Container
  {
    internal FunctionGroup() : base(null, null, "GS") { }

    internal FunctionGroup(
      ISpecificationFinder specFinder,
      Container parent,
      X12DelimiterSet delimiters,
      string segment)
      : base(parent, delimiters, segment)
    {
      SpecFinder = specFinder;
    }

    public override FunctionGroup Group => this;

    protected internal override ISpecificationFinder SpecFinder { get; }

    public Interchange Interchange => (Interchange)Parent;
    public Segment Trailer => _trailer;

    public string FunctionalIdentifierCode
    {
      get => GetElement(1);
      set => SetElement(1, value);
    }

    public string ApplicationSendersCode
    {
      get => GetElement(2);
      set => SetElement(2, value);
    }

    public string ApplicationReceiversCode
    {
      get => GetElement(3);
      set => SetElement(3, value);
    }

    public DateTime Date
    {
      get {
        if (DateTime.TryParseExact(GetElement(4) + GetElement(5), "yyyyMMddHHmm", null, DateTimeStyles.None, out var date))
          return date;

        if (DateTime.TryParseExact(GetElement(4), "yyyyMMdd", null, DateTimeStyles.None, out date))
          return date;

        if (DateTime.TryParseExact(GetElement(4), "yyyyMMd", null, DateTimeStyles.None, out date))
          return date;
          
        if (DateTime.TryParseExact(GetElement(4), "yyMMdd", null, DateTimeStyles.None, out date))
          return date;

        throw new ArgumentException(
          $"{GetElement(4)} and {GetElement(5)} cannot be converted into a date and time.");
      }
      set {
        SetElement(4, $"{value:yyyyMMdd}");
        SetElement(5, $"{value:HHmm}");
      }
    }

    public int ControlNumber
    {
      get => int.Parse(GetElement(6));
      set => SetElement(6, value.ToString());
    }

    public string ResponsibleAgencyCode
    {
      get => GetElement(7);
      set => SetElement(7, value);
    }

    public string VersionIdentifierCode
    {
      get => GetElement(8);
      set => SetElement(8, value);
    }

    public List<Transaction> Transactions => Segments.OfType<Transaction>().ToList();

    protected override IList<SegmentSpecification> AllowedChildSegments => new List<SegmentSpecification>();

    //internal override IEnumerable<string> TrailerSegmentIds => new List<string>();

    public Transaction FindTransaction(string controlNumber)
    {
      return Transactions.FirstOrDefault(t => t.ControlNumber == controlNumber);
    }

    internal Transaction AddTransaction(string segmentString)
    {
      var transactionType = new Segment(null, this._delimiters, segmentString).GetElement(1);
      var spec = SpecFinder.FindTransactionSpec(FunctionalIdentifierCode, VersionIdentifierCode, transactionType);
      var transaction = new Transaction(this, this._delimiters, segmentString, spec);
      _segments.Add(transaction);
      return transaction;
    }

    public Transaction AddTransaction(string identifierCode, string controlNumber)
    {
      var spec = SpecFinder.FindTransactionSpec(FunctionalIdentifierCode, VersionIdentifierCode, identifierCode);

      var transaction = new Transaction(
        this,
        this._delimiters,
        string.Format("ST{0}{0}{1}", this._delimiters.ElementSeparator, this._delimiters.SegmentTerminator),
        spec);

      transaction.IdentifierCode = identifierCode;
      transaction.ControlNumber = controlNumber;
      transaction.SetTerminatingTrailerSegment(
        string.Format(
          "SE{0}0{0}{2}{1}",
          this._delimiters.ElementSeparator,
          this._delimiters.SegmentTerminator,
          controlNumber));

      _segments.Add(transaction);
      return transaction;
    }
    
    internal override string ToX12String(bool addWhitespace = false, int indent = 0, int step = 0)
    {
      UpdateTrailerSegmentCount("GE", 1, Transactions.Count());
      return base.ToX12String(addWhitespace, indent, step);
    }

    public virtual string Serialize()
    {
      var xmlSerializer = new XmlSerializer(
        GetType());

      var memoryStream = new MemoryStream();

      xmlSerializer.Serialize(memoryStream, this);
      memoryStream.Seek(0, SeekOrigin.Begin);
      var streamReader = new StreamReader(memoryStream);
      return streamReader.ReadToEnd();
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      writer.WriteStartElement("FunctionGroup");

      base.WriteXml(writer);

      //foreach (var segment in Segments)
      //  segment.WriteXml(writer);

      //foreach (var transaction in Transactions)
      //  transaction.WriteXml(writer);

      //foreach (var segment in TrailerSegments)
      //  segment.WriteXml(writer);

      writer.WriteEndElement();
    }
  }
}