using System.Collections.Generic;
using System.Linq;
using System.Xml;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public class Transaction : HierarchicalLoopContainer
  {
    private IList<string> _loopStartingSegmentIds;

    internal Transaction(Container parent, X12DelimiterSet delimiters, string segment, TransactionSpecification spec)
      : base(parent, delimiters, segment)
    {
      Specification = spec;
    }

    public override FunctionGroup Group => (FunctionGroup)Parent;

    protected internal override ISpecificationFinder SpecFinder => Group.SpecFinder;

    public TransactionSpecification Specification { get; }

    public string IdentifierCode
    {
      get => GetElement(1);
      set => SetElement(1, value);
    }

    public string ControlNumber
    {
      get => GetElement(2);
      set => SetElement(2, value);
    }

    public string ImplementationConventionReference
    {
      get => GetElement(3);
      set => SetElement(3, value);
    }

    internal override IList<LoopSpecification> AllowedChildLoops => 
      Specification != null ? Specification.LoopSpecifications : new List<LoopSpecification>();

    protected override IList<SegmentSpecification> AllowedChildSegments => 
      Specification != null ? Specification.SegmentSpecifications : new List<SegmentSpecification>();

    internal override IEnumerable<string> TrailerSegmentIds => 
      Specification.SegmentSpecifications.Where(ss => ss.Trailer).Select(spec => spec.SegmentId).ToList();

    internal override void Initialize(string segment)
    {
      base.Initialize(segment);
      _loopStartingSegmentIds = new List<string>();
      _loopStartingSegmentIds.Add("NM1");
    }

    public override bool AllowsHierarchicalLoop(string levelCode) =>
      Specification.HierarchicalLoopSpecifications.Exists(
        hl => hl.LevelCode == levelCode || string.IsNullOrEmpty(hl.LevelCode));

    public override HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchicalLoops)
    {
      var hloop = base.AddHLoop(
        string.Format(
          "HL{0}{1}{0}{0}{2}{0}",
          this._delimiters.ElementSeparator,
          id,
          levelCode));

      if (existingHierarchicalLoops.HasValue)
        hloop.HierarchicalChildCode = existingHierarchicalLoops.Value ? "1" : "0";

      return hloop;
    }

    internal override string ToX12String(bool addWhitespace)
    {
      UpdateTrailerSegmentCount("SE", 1, CountTotalSegments());
      return base.ToX12String(addWhitespace);
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      writer.WriteStartElement("Transaction");
      writer.WriteAttributeString("ControlNumber", ControlNumber);
      base.WriteXml(writer);
      writer.WriteEndElement();
    }
  }
}