using System.Collections.Generic;
using System.Linq;
using X12.Parsing.Specification;

namespace X12.Parsing.Model
{
  public abstract class LoopContainer : Container
  {
    private List<Loop> _loops;

    internal LoopContainer(Container parent, X12DelimiterSet delimiters, string startingSegment)
      : base(parent, delimiters, startingSegment) { }

    internal abstract IList<LoopSpecification> AllowedChildLoops { get; }

    public IEnumerable<Loop> Loops => _loops;

    internal override void Initialize(string segment)
    {
      base.Initialize(segment);
      _loops = new List<Loop>();
    }

    public Loop AddLoop(string segmentString)
    {
      var loopSpec = GetLoopSpecification(segmentString);

      if (loopSpec != null)
      {
        var loop = new Loop(this, this._delimiters, segmentString, loopSpec);
        this._segments.Add(loop);
        _loops.Add(loop);
        return loop;
      }

      return null;
    }

    public T AddLoop<T>(T loop)
      where T : TypedLoop
    {
      var segmentString = loop.GetSegmentString(this._delimiters);
      var loopSpec = GetLoopSpecification(segmentString);

      if (loopSpec != null)
      {
        loop.Initialize(this, this._delimiters, loopSpec);
        this._segments.Add(loop._loop);
        _loops.Add(loop._loop);
        return loop;
      }

      throw new TransactionValidationException(
        "Loop {3} could not be added because it could not be found in the specification for {2}",
        null,
        null,
        SegmentId,
        segmentString);
    }

    private LoopSpecification GetLoopSpecification(string segmentString)
    {
      var segment = new Segment(this, this._delimiters, segmentString);

      IList<LoopSpecification> matchingLoopSpecs = AllowedChildLoops
        .Where(cl => cl.StartingSegment.SegmentId == segment.SegmentId).ToList();

      if (matchingLoopSpecs == null || matchingLoopSpecs.Count == 0)
        return null;

      if (segment.SegmentId == "NM1" || segment.SegmentId == "N1")
      {
        var spec = matchingLoopSpecs.Where(
            ls => ls.StartingSegment.EntityIdentifiers.Any(
              ei => ei.Code.ToString() == segment.GetElement(1) ||
                ei.Code.ToString() == "Item" + segment.GetElement(1)))
          .FirstOrDefault();

        if (spec == null)
          if (matchingLoopSpecs.Where(ls => ls.StartingSegment.SegmentId == segment.SegmentId).Count() == 1)
            spec = matchingLoopSpecs.Where(ls => ls.StartingSegment.SegmentId == segment.SegmentId).First();

        return spec;
      }

      return matchingLoopSpecs.FirstOrDefault();
    }

    internal override int CountTotalSegments()
    {
      return base.CountTotalSegments() + Loops.Sum(l => l.CountTotalSegments()) - Loops.Count();
    }

    internal override string SerializeBodyToX12(bool addWhitespace) => "";
  }
}