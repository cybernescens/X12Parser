using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using X12.Parsing;

namespace X12.Model
{
  public abstract class HierarchicalLoopContainer : LoopContainer
  {
    protected readonly IDictionary<string, HierarchicalLoop> _allHLoops;

    private IDictionary<string, HierarchicalLoop> _hLoops;

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

    public HierarchicalLoop FindHLoop(string id) => _allHLoops.ContainsKey(id) ? _allHLoops[id] : null;

    public bool HasHierarchicalSpecs() =>
      this switch {
        Model.Transaction => true,
        HierarchicalLoop  => false,
        Loop l            => l.Specification.HierarchicalLoopSpecifications.Count > 0,
        _                 => false
      };

    internal HierarchicalLoop AddHLoop(string segmentString)
    {
      var transaction = Transaction;

      var hl = new HierarchicalLoop(this, this._delimiters, segmentString);

      var specContainer = this;
      while (!(specContainer is HierarchicalLoopContainer && specContainer.HasHierarchicalSpecs()))
        specContainer = specContainer.Parent is HierarchicalLoopContainer parent
          ? parent
          : throw new InvalidOperationException($"Cannot find specification for hierarchical loop {segmentString}");

      switch (specContainer)
      {
        case Model.Transaction:
          hl.Specification = transaction.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
            hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);

          break;
        case HierarchicalLoop hloop: {
          var loopWithSpec = hloop;
          hl.Specification = loopWithSpec.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
            hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);

          break;
        }
        case Loop l: {
          var loopWithSpec = l;
          hl.Specification = loopWithSpec.Specification.HierarchicalLoopSpecifications.FirstOrDefault(
            hls => hls.LevelCode == null || hls.LevelCode.ToString() == hl.LevelCode);

          break;
        }
      }

      if (hl.Specification == null)
      {
        throw new TransactionValidationException(
          "{0} Transaction does not expect {2} level code value {3} that appears in transaction control number {1}.",
          transaction.IdentifierCode,
          transaction.ControlNumber,
          "HL03",
          hl.LevelCode);
      }

      _hLoops.Add(hl.Id, hl);
      // loop id must be unique throughout the transaction
      try
      {
        specContainer.AddToHLoopDictionary(hl);
      }
      catch (ArgumentException exc)
      {
        if (exc.Message == "An item with the same key has already been added.")
        {
          throw new TransactionValidationException(
            "Hierarchical Loop ID {3} cannot be added to {0} transaction with control number {1} because it already exists.",
            transaction.IdentifierCode,
            transaction.ControlNumber,
            "HL01",
            hl.Id);
        }

        throw;
      }

      return hl;
    }

    public abstract bool AllowsHierarchicalLoop(string levelCode);

    public abstract HierarchicalLoop AddHLoop(string id, string levelCode, bool? existingHierarchicalLoops);

    internal override int CountTotalSegments() => base.CountTotalSegments() + HLoops.Sum(hl => hl.CountTotalSegments());

    internal override string SerializeBodyToX12(bool addWhitespace)
    {
      var sb = new StringBuilder(base.SerializeBodyToX12(addWhitespace));
      foreach (var hloop in HLoops)
        sb.Append(hloop.ToX12String(addWhitespace));

      return sb.ToString();
    }

    internal override void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

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