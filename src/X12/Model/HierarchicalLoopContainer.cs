using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public abstract class HierarchicalLoopContainer : LoopContainer
  {
    internal HierarchicalLoopContainer(Container parent, X12DelimiterSet delimiters, string startingSegment)
      : base(parent, delimiters, startingSegment)
    {
    }

    public IEnumerable<HierarchicalLoop> HLoops => Segments.OfType<HierarchicalLoop>();

    internal override void Initialize(string segment)
    {
      base.Initialize(segment);
    }

    //internal void AddToHLoopDictionary(HierarchicalLoop hloop) { _allHLoops.Add(hloop.Id, hloop); }

    //public HierarchicalLoop FindHLoop(string id) => _allHLoops.ContainsKey(id) ? _allHLoops[id] : null;

    internal virtual bool HasHierarchicalSpecification() => false;
    //protected abstract HierarchicalLoop CreateHierarchicalLoop(string segmentString);

    internal HierarchicalLoop AddHLoop(string segmentString)
    {
      HierarchicalLoop CreateHl(IEnumerable<HierarchicalLoopSpecification> candidates) => 
        new HierarchicalLoop(this, this._delimiters, segmentString, candidates);

      HierarchicalLoopContainer specContainer = this;

      for (;
        specContainer != null && !specContainer.HasHierarchicalSpecification();
        specContainer = specContainer.Parent as HierarchicalLoopContainer) { }
      //);

      var hl = specContainer switch {
        Transaction tx => CreateHl(tx.Specification.HierarchicalLoopSpecifications),
        HierarchicalLoop hloop => CreateHl(hloop.Specification.HierarchicalLoopSpecifications),
        Loop l => CreateHl(l.Specification.HierarchicalLoopSpecifications),
        _ => throw new Exception()
      };

      _segments.Add(hl);

      if (!Transaction.AllowsHierarchicalLoop(hl))
      {
        throw new TransactionValidationException(
          "Hierarchical Loop ID {3} cannot be added to {0} transaction with control number {1} because it already exists.",
          Transaction.IdentifierCode,
          Transaction.ControlNumber,
          "HL01",
          hl.Id);
      }

      return hl;
    }

    public abstract bool AllowsHierarchicalLoop(string levelCode);

    public abstract HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchicalLoops);
    
    //internal override string SerializeBodyToX12(bool addWhitespace)
    //{
    //  var sb = new StringBuilder(base.SerializeBodyToX12(addWhitespace));
    //  foreach (var hloop in HLoops)
    //    sb.Append(hloop.ToX12String(addWhitespace));

    //  return sb.ToString();
    //}

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      base.WriteXml(writer);

      //foreach (var segment in ((Container)this).Segments)
      //  segment.WriteXml(writer);

      //foreach (var hloop in HLoops)
      //  hloop.WriteXml(writer);

      //foreach (var segment in TrailerSegments)
      //  segment.WriteXml(writer);
    }
  }
}