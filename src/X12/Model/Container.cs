using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public abstract class Container : Segment
  {
    private static readonly Regex NewLineRegex = new("(?<nl>\r\n|\r|\n)", RegexOptions.Compiled);
    protected IList<Segment> _segments;

    private Segment _terminatingTrailerSegment;

    internal Container(Container parent, X12DelimiterSet delimiters, string segment)
      : base(parent, delimiters, segment) { }

    protected abstract IList<SegmentSpecification> AllowedChildSegments { get; }

    public Transaction Transaction
    {
      get {
        Container GetTransaction(Container c) =>
          c switch {
            Transaction tx => tx,
            Container      => GetTransaction(c.Parent),
            null           => null
          };

        return GetTransaction(this) as Transaction;
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
      if (spec != null || segmentString.StartsWith("TA1", StringComparison.Ordinal) || forceAdd)
      {
        _segments.Add(segment);
        return segment;
      }

      if (SegmentId != "NM1" || !new[] { "N3", "N4", "PER", "REF" }.Contains(segment.SegmentId))
        return null;

      _segments.Add(segment);
      return segment;
    }

    //public T AddSegment<T>(T segment) where T : TypedSegment
    //{
    //  segment.Initialize(this, this._delimiters);
    //  var spec = AllowedChildSegments.FirstOrDefault(acs => acs.SegmentId == segment._segment.SegmentId);
    //  if (spec == null)
    //    return null;

    //  _segments.Add(segment._segment);
    //  return segment;
    //}

    internal void SetTerminatingTrailerSegment(string segmentString)
    {
      _terminatingTrailerSegment = new Segment(this, this._delimiters, segmentString);
    }

    internal virtual int CountTotalSegments() => 1 + Segments.Count() + TrailerSegments.Count();

    internal bool UpdateTrailerSegmentCount(string segmentId, int elementNumber, int count)
    {
      var segment = _terminatingTrailerSegment;
      if (segment == null)
        return false;

      if (segment.ElementCount < elementNumber)
        return false;

      segment.SetElement(elementNumber, count.ToString());
      return true;
    }

    internal abstract string SerializeBodyToX12(bool addWhitespace);

    internal override string ToX12String(bool addWhitespace)
    {
      var sb = new StringBuilder(base.ToX12String(addWhitespace));

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      string AddWhitespace(string s, Func<bool> extra = null) =>
        addWhitespace && (extra ?? (() => true))()
          ? NewLineRegex.Replace(s, me => $"{me.Groups["nl"]} ")
          : s;

      Segments.Where(seg => !TrailerSegmentIds.Contains(seg.SegmentId))
        .ToList()
        .ForEach(x => sb.Append(AddWhitespace(x.ToX12String(addWhitespace))));

      sb.Append(AddWhitespace(SerializeBodyToX12(addWhitespace)));

      Segments.Where(seg => TrailerSegmentIds.Contains(seg.SegmentId))
        .ToList()
        .ForEach(x => sb.Append(AddWhitespace(x.ToX12String(addWhitespace))));

      TrailerSegments
        .ToList()
        .ForEach(
          x => sb.Append(
            AddWhitespace(
              x.ToX12String(addWhitespace),
              () => new[] { "SE", "GE", "IEA" }.All(y => y != x.SegmentId))));

      return sb.ToString();
    }
  }
}