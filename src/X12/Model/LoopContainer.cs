using System.Collections.Generic;
using System.Linq;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public abstract class LoopContainer : Container
  {
    internal LoopContainer(Container parent, X12DelimiterSet delimiters, string startingSegment)
      : base(parent, delimiters, startingSegment) { }

    internal abstract IList<LoopSpecification> AllowedChildLoops { get; }

    public List<Loop> Loops => Segments.OfType<Loop>().ToList();

    public Loop AddLoop(string segmentString)
    {
      var loopSpec = GetLoopSpecification(segmentString);
      if (loopSpec == null)
        return null;

      var loop = new Loop(this, this._delimiters, segmentString, loopSpec);
      this._segments.Add(loop);
      return loop;
    }

    private LoopSpecification GetLoopSpecification(string segmentString)
    {
      var segment = new Segment(this, this._delimiters, segmentString);

      IList<LoopSpecification> matchingLoopSpecs = AllowedChildLoops
        .Where(cl => cl.StartingSegment.SegmentId == segment.SegmentId)
        .ToList();

      if (!matchingLoopSpecs.Any())
        return null;

      if (segment.SegmentId != "NM1" && segment.SegmentId != "N1")
        return matchingLoopSpecs.FirstOrDefault();

      var spec = matchingLoopSpecs
        .FirstOrDefault(
          ls => ls.StartingSegment.EntityIdentifiers.Any(
            ei => ei.Code.ToString() == segment.GetElement(1) ||
              ei.Code.ToString() == "Item" + segment.GetElement(1)));

      if (spec == null && matchingLoopSpecs.Count(ls => ls.StartingSegment.SegmentId == segment.SegmentId) == 1)
        spec = matchingLoopSpecs.First(ls => ls.StartingSegment.SegmentId == segment.SegmentId);

      return spec;
    }
  }
}