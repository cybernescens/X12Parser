using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace X12.Parsing.Model
{
  public abstract class HierarchicalLoopContainer : LoopContainer
  {
    protected Dictionary<string, HierarchicalLoop> _allHLoops;

    private Dictionary<string, HierarchicalLoop> _hLoops;

    internal HierarchicalLoopContainer(Container parent, X12DelimiterSet delimiters, string startingSegment)
      : base(parent, delimiters, startingSegment)
    {
      _allHLoops = new Dictionary<string, HierarchicalLoop>();
    }

    public IEnumerable<HierarchicalLoop> HLoops => _hLoops.Values;

    internal override void Initialize(string segment)
    {
      base.Initialize(segment);
      _hLoops = new Dictionary<string, HierarchicalLoop>();
    }

    internal void AddToHLoopDictionary(HierarchicalLoop hloop) { _allHLoops.Add(hloop.Id, hloop); }

    public HierarchicalLoop FindHLoop(string id)
    {
      if (_allHLoops.ContainsKey(id))
        return _allHLoops[id];

      return null;
    }

    public bool HasHierachicalSpecs()
    {
      if (this is Transaction)
        return true;

      if (this is HierarchicalLoop)
        return false;

      if (this is Loop)
        return ((Loop) this).Specification.HierarchicalLoopSpecifications.Count > 0;

      return false;
    }

    internal HierarchicalLoop AddHLoop(string segmentString)
    {
      var transaction = Transaction;

      var hl = new HierarchicalLoop(this, this._delimiters, segmentString);

      var specContainer = this;
      while (!(specContainer is HierarchicalLoopContainer && specContainer.HasHierachicalSpecs()))
        if (specContainer.Parent is HierarchicalLoopContainer)
          specContainer = (HierarchicalLoopContainer) specContainer.Parent;
        else
          throw new InvalidOperationException(
            string.Format("Cannot find specification for hierarichal loop {0}", segmentString));

      if (specContainer is Transaction)
      {
        hl.Specification = transaction.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
          hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);
      }
      else if (specContainer is HierarchicalLoop)
      {
        var loopWithSpec = (HierarchicalLoop) specContainer;
        hl.Specification = loopWithSpec.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
          hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);
      }
      else if (specContainer is Loop)
      {
        var loopWithSpec = (Loop) specContainer;
        hl.Specification = loopWithSpec.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
          hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);
      }

      if (hl.Specification == null)
        throw new TransactionValidationException(
          "{0} Transaction does not expect {2} level code value {3} that appears in transaction control number {1}.",
          transaction.IdentifierCode,
          transaction.ControlNumber,
          "HL03",
          hl.LevelCode);

      _hLoops.Add(hl.Id, hl);
      // loop id must be unique throughout the transaction
      try
      {
        specContainer.AddToHLoopDictionary(hl);
      }
      catch (ArgumentException exc)
      {
        if (exc.Message == "An item with the same key has already been added.")
          throw new TransactionValidationException(
            "Hierarchical Loop ID {3} cannot be added to {0} transaction with control number {1} because it already exists.",
            transaction.IdentifierCode,
            transaction.ControlNumber,
            "HL01",
            hl.Id);

        throw;
      }

      return hl;
    }

    public abstract bool AllowsHierarchicalLoop(string levelCode);

    public abstract HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchalLoops);

    internal override int CountTotalSegments()
    {
      return base.CountTotalSegments() + HLoops.Sum(hl => hl.CountTotalSegments());
    }

    internal override string SerializeBodyToX12(bool addWhitespace)
    {
      var sb = new StringBuilder(base.SerializeBodyToX12(addWhitespace));
      foreach (var hloop in HLoops)
        sb.Append(hloop.ToX12String(addWhitespace));

      return sb.ToString();
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (!string.IsNullOrEmpty(SegmentId))
      {
        base.WriteXml(writer);

        foreach (var segment in Segments)
          segment.WriteXml(writer);

        foreach (var hloop in HLoops)
          hloop.WriteXml(writer);

        foreach (var segment in TrailerSegments)
          segment.WriteXml(writer);
      }
    }
  }
}