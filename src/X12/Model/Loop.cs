using System.Collections.Generic;
using System.Linq;
using System.Xml;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public class Loop : HierarchicalLoopContainer
  {
    internal Loop(
      Container parent,
      X12DelimiterSet delimiters,
      string startingSegment,
      LoopSpecification loopSpecification)
      : base(parent, delimiters, startingSegment)
    {
      Specification = loopSpecification;
    }
    
    public LoopSpecification Specification { get; }

    public string EntityIdentifierCode =>
      SegmentId switch {
        "CLI" => GetElement(1),
        "CUR" => GetElement(1),
        "G18" => GetElement(1),
        "MRC" => GetElement(1),
        "N1"  => GetElement(1),
        "NM1" => GetElement(1),
        "NX1" => GetElement(1),
        "RDI" => GetElement(1),
        "ENT" => GetElement(2),
        "LCD" => GetElement(2),
        "PLA" => GetElement(2),
        "PT"  => GetElement(2),
        "IN1" => GetElement(3),
        "SCH" => GetElement(3),
        _     => null
      };

    internal override IList<LoopSpecification> AllowedChildLoops => Specification.LoopSpecifications;

    protected override IList<SegmentSpecification> AllowedChildSegments => Specification.SegmentSpecifications;

    internal override IEnumerable<string> TrailerSegmentIds => 
      Specification.SegmentSpecifications.Where(ss => ss.Trailer).Select(spec => spec.SegmentId).ToList();

    public override bool AllowsHierarchicalLoop(string levelCode)
    {
      return Specification.HierarchicalLoopSpecifications.Exists(
        hl => hl.LevelCode == levelCode || hl.LevelCode == null || hl.LevelCode == "");
    }

    public override HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchicalLoops)
    {
      var hloop = base.AddHLoop(
        string.Format("HL{0}{1}{0}{2}{0}{3}{0}", this._delimiters.ElementSeparator, id, "", levelCode));

      if (existingHierarchicalLoops.HasValue)
        hloop.HierarchicalChildCode = existingHierarchicalLoops.Value ? "1" : "0";

      return hloop;
    }

    #region IXmlSerializable Members

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      writer.WriteStartElement("Loop");

      if (Specification != null)
      {
        writer.WriteAttributeString("LoopId", Specification.LoopId);
        writer.WriteAttributeString("Name", Specification.Name);
      }

      base.WriteXml(writer);

      writer.WriteEndElement();
    }

    #endregion
  }
}