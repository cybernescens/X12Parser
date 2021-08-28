using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.Parsing.Specification;

namespace X12.Parsing.Model
{
  public abstract class Container : Segment
  {
    protected List<Segment> _segments;

    private Segment _terminatingTrailerSegment;

    internal Container(Container parent, X12DelimiterSet delimiters, string segment)
      : base(parent, delimiters, segment) { }

    internal abstract IList<SegmentSpecification> AllowedChildSegments { get; }

    public Transaction Transaction
    {
      get {
        var container = this;
        while (!(container is Transaction))
        {
          container = container.Parent;
          if (container == null)
            return null;
        }

        return (Transaction) container;
      }
    }

    public IEnumerable<Segment> Segments => _segments;

    internal abstract IEnumerable<string> TrailerSegmentIds { get; }

    public IEnumerable<Segment> TrailerSegments
    {
      get {
        var list = new List<Segment>();
        if (_terminatingTrailerSegment != null)
          list.Add(_terminatingTrailerSegment);

        return list;
      }
    }

    internal override void Initialize(string segment)
    {
      base.Initialize(segment);
      _segments = new List<Segment>();
    }

    public Segment AddSegment(string segmentString) => AddSegment(segmentString, false);

    public Segment AddSegment(string segmentString, bool forceAdd)
    {
      var segment = new Segment(this, this._delimiters, segmentString);
      var spec = AllowedChildSegments.FirstOrDefault(acs => acs.SegmentId == segment.SegmentId);
      if (spec != null || segmentString.StartsWith("TA1") || forceAdd)
      {
        _segments.Add(segment);
        return segment;
      }

      if (SegmentId == "NM1" &&
        new[] { "N3", "N4", "PER", "REF" }.Contains(segment.SegmentId))
      {
        _segments.Add(segment);
        return segment;
      }

      return null;
    }

    public T AddSegment<T>(T segment)
      where T : TypedSegment
    {
      segment.Initialize(this, this._delimiters);
      var spec = AllowedChildSegments.FirstOrDefault(acs => acs.SegmentId == segment._segment.SegmentId);
      if (spec != null)
      {
        _segments.Add(segment._segment);
        return segment;
      }

      return null;
    }

    internal void SetTerminatingTrailerSegment(string segmentString)
    {
      _terminatingTrailerSegment = new Segment(this, this._delimiters, segmentString);
    }

    internal virtual int CountTotalSegments() => 1 + Segments.Count() + TrailerSegments.Count();

    internal bool UpdateTrailerSegmentCount(string segmentId, int elementNumber, int count)
    {
      var segment = _terminatingTrailerSegment;
      if (segment != null)
      {
        if (segment.ElementCount >= elementNumber)
        {
          segment.SetElement(elementNumber, count.ToString());
          return true;
        }

        return false;
      }

      return false;
    }

    internal abstract string SerializeBodyToX12(bool addWhitespace);

    internal override string ToX12String(bool addWhitespace)
    {
      var sb = new StringBuilder(base.ToX12String(addWhitespace));

      foreach (var segment in Segments.Where(seg => !TrailerSegmentIds.Contains(seg.SegmentId)))
        if (addWhitespace)
          sb.Append(segment.ToX12String(addWhitespace).Replace("\r\n", "\r\n  "));
        else
          sb.Append(segment.ToX12String(addWhitespace));

      if (addWhitespace)
        sb.Append(SerializeBodyToX12(addWhitespace).Replace("\r\n", "\r\n  "));
      else
        sb.Append(SerializeBodyToX12(addWhitespace));

      foreach (var segment in Segments.Where(seg => TrailerSegmentIds.Contains(seg.SegmentId)))
        if (addWhitespace)
          sb.Append(segment.ToX12String(addWhitespace).Replace("\r\n", "\r\n  "));
        else
          sb.Append(segment.ToX12String(addWhitespace));

      foreach (var segment in TrailerSegments)
      {
        string[] wrapperSegments = { "SE", "GE", "IEA" };
        if (addWhitespace && !wrapperSegments.Contains(segment.SegmentId))
          sb.Append(segment.ToX12String(addWhitespace).Replace("\r\n", "\r\n  "));
        else
          sb.Append(segment.ToX12String(addWhitespace));
      }

      return sb.ToString();
    }
  }
}