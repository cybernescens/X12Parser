﻿using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using X12.Parsing.Specification;

namespace X12.Parsing.Model
{
  public class HierarchicalLoop : HierarchicalLoopContainer
  {
    internal HierarchicalLoop(Container parent, X12DelimiterSet delimiters, string segment)
      : base(parent, delimiters, segment) { }

    public HierarchicalLoopSpecification Specification { get; internal set; }

    internal override IList<LoopSpecification> AllowedChildLoops
    {
      get {
        if (Specification != null)
          return Specification.LoopSpecifications;

        return new List<LoopSpecification>();
      }
    }

    internal override IList<SegmentSpecification> AllowedChildSegments
    {
      get {
        if (Specification != null)
          return Specification.SegmentSpecifications;

        return new List<SegmentSpecification>();
      }
    }

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

    internal override IEnumerable<string> TrailerSegmentIds
    {
      get {
        var list = new List<string>();

        foreach (var spec in Specification.SegmentSpecifications.Where(ss => ss.Trailer))
          list.Add(spec.SegmentId);

        return list;
      }
    }

    public override bool AllowsHierarchicalLoop(string levelCode) => true;

    public override HierarchicalLoop AddHLoop(string id, string levelCode, bool? willHoldChildHLoops)
    {
      var hloop = base.AddHLoop(
        string.Format("HL{0}{1}{0}{2}{0}{3}{0}", this._delimiters.ElementSeparator, id, Id, levelCode));

      if (willHoldChildHLoops.HasValue)
        hloop.HierarchicalChildCode = willHoldChildHLoops.Value ? "1" : "0";

      return hloop;
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (!string.IsNullOrEmpty(SegmentId))
      {
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
    }

    public override string ToString() =>
      string.Format(
        "Loop(Id={0},ParentId={1},Level={2},ChildLoops={3}, ChildSegments={4})",
        Id,
        ParentId,
        LevelCode,
        Loops.Count(),
        Segments.Count());
  }
}