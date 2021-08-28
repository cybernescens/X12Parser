using X12.Parsing.Specification;

namespace X12.Parsing.Model
{
  public abstract class TypedLoop
  {
    internal Loop _loop;
    internal string _segmentId;

    protected TypedLoop(string segmentId) { _segmentId = segmentId; }

    internal virtual string GetSegmentString(X12DelimiterSet delimiters) =>
      string.Format("{0}{1}", _segmentId, delimiters.ElementSeparator);

    internal virtual void Initialize(Container parent, X12DelimiterSet delimiters, LoopSpecification loopSpecification)
    {
      _loop = new Loop(parent, delimiters, _segmentId, loopSpecification);
    }

    public Loop AddLoop(string segmentString) => _loop.AddLoop(segmentString);

    public T AddLoop<T>(T loop)
      where T : TypedLoop =>
      _loop.AddLoop(loop);

    public Segment AddSegment(string segmentString) => _loop.AddSegment(segmentString);

    public T AddSegment<T>(T segment)
      where T : TypedSegment =>
      _loop.AddSegment(segment);
  }
}