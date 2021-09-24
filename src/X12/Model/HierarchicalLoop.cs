using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  [DebuggerDisplay("{ToString()}")]
  public class HierarchicalLoop : HierarchicalLoopContainer
  {
    internal HierarchicalLoop(
      Container parent,
      X12DelimiterSet delimiters,
      string segment,
      IEnumerable<HierarchicalLoopSpecification> specifications)
      : base(parent, delimiters, segment)
    {
      Specification =
        specifications.FirstOrDefault(hls => hls.LevelCode == null || hls.LevelCode.ToString() == LevelCode) ??
        throw new TransactionValidationException(
          "{0} Transaction does not expect {2} level code value {3} that appears in transaction control number {1}.",
          Transaction.IdentifierCode,
          Transaction.ControlNumber,
          "HL03",
          LevelCode);
    }

    public HierarchicalLoopSpecification Specification { get; }
    internal override bool HasHierarchicalSpecification() => false;

    internal override IList<LoopSpecification> AllowedChildLoops => 
      Specification != null ? Specification.LoopSpecifications : new List<LoopSpecification>();

    protected override IList<SegmentSpecification> AllowedChildSegments => 
      Specification != null ? Specification.SegmentSpecifications : new List<SegmentSpecification>();

    [XmlAttribute("Id")]
    public string Id => GetElement(1);

    [XmlAttribute("ParentId")]
    public string ParentId => GetElement(2);

    public string LevelCode => GetElement(3);

    public string HierarchicalChildCode
    {
      get => GetElement(4);
      internal set => SetElement(4, value);
    }
    
    public override bool AllowsHierarchicalLoop(string levelCode) => true;

    public override HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchicalLoops)
    {
      var hloop = base.AddHLoop(
        string.Format("HL{0}{1}{0}{2}{0}{3}{0}", this._delimiters.ElementSeparator, id, Id, levelCode));

      if (existingHierarchicalLoops.HasValue)
        hloop.HierarchicalChildCode = existingHierarchicalLoops.Value ? "1" : "0";

      return hloop;
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      writer.WriteStartElement("HierarchicalLoop");

      if (Specification != null)
      {
        writer.WriteAttributeString("LoopId", Specification.LoopId);
        writer.WriteAttributeString("LoopName", Specification.Name);
      }

      writer.WriteAttributeString("Id", Id);
      writer.WriteAttributeString("ParentId", ParentId);

      base.WriteXml(writer);

      writer.WriteEndElement();
    }

    public override int GetHashCode() => string.GetHashCode($"HL-{Id}");

    public override string ToString() =>
      $"{SegmentString} [Loop(Id={Id},ParentId={ParentId},Level={LevelCode},ChildLoops={Loops.Count()}, ChildSegments={((Container)this).Segments.Count()})]";
  }
}