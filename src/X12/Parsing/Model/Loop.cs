using System.Collections.Generic;
using System.Linq;
using System.Xml;
using X12.Parsing.Specification;

namespace X12.Parsing.Model
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

    internal override IList<LoopSpecification> AllowedChildLoops => Specification.LoopSpecifications;

    internal override IList<SegmentSpecification> AllowedChildSegments => Specification.SegmentSpecifications;

    internal override IEnumerable<string> TrailerSegmentIds
    {
      get {
        var list = new List<string>();

        foreach (var spec in Specification.SegmentSpecifications.Where(ss => ss.Trailer))
          list.Add(spec.SegmentId);

        return list;
      }
    }

    public override bool AllowsHierarchicalLoop(string levelCode)
    {
      return Specification.HierarchicalLoopSpecifications.Exists(
        hl => hl.LevelCode == levelCode || hl.LevelCode == null || hl.LevelCode == "");
    }

    public override HierarchicalLoop AddHLoop(string id, string levelCode, bool? willHoldChildHLoops)
    {
      var hloop = base.AddHLoop(
        string.Format("HL{0}{1}{0}{2}{0}{3}{0}", this._delimiters.ElementSeparator, id, "", levelCode));

      if (willHoldChildHLoops.HasValue)
        hloop.HierarchicalChildCode = willHoldChildHLoops.Value ? "1" : "0";

      return hloop;
    }

    #region IXmlSerializable Members

    internal override void WriteXml(XmlWriter writer)
    {
      if (!string.IsNullOrEmpty(SegmentId))
      {
        writer.WriteStartElement("Loop");

        if (Specification != null)
        {
          writer.WriteAttributeString("LoopId", Specification.LoopId);
          writer.WriteAttributeString("Name", Specification.Name);
        }

        base.WriteXml(writer);

        writer.WriteEndElement();
      }
    }

    #endregion
  }
}