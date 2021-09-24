using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    private static readonly Regex NewLineRegex = new(@"(\r\n|\r|\n)", RegexOptions.Compiled);

    protected readonly ICollection<Segment> _segments = new Collection<Segment>();

    public IEnumerable<Segment> Segments =>
      _trailer != null
        ? _segments.Concat(new[] { _trailer })
        : _segments;

    protected Segment _trailer;

    internal Container(Container parent, X12DelimiterSet delimiters, string segment)
      : base(parent, delimiters, segment) { }

    protected abstract IList<SegmentSpecification> AllowedChildSegments { get; }

    public Transaction Transaction
    {
      get {
        Container GetTransaction(Container c) =>
          c switch {
            Transaction tx => tx,
            { }            => GetTransaction(c.Parent),
            null           => null
          };

        return GetTransaction(this) as Transaction;
      }
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
    
    internal void SetTerminatingTrailerSegment(string segmentString)
    {
      _trailer = new Segment(this, this._delimiters, segmentString);
    }

    public override int Count => 1 + Segments.Sum(x => x.Count);

    internal bool UpdateTrailerSegmentCount(string segmentId, int elementNumber, int count)
    {
      var segment = _trailer;
      if (segment == null)
        return false;

      if (segment.ElementCount < elementNumber)
        return false;

      segment.SetElement(elementNumber, count.ToString());
      return true;
    }

    internal override string ToX12String(bool addWhitespace = false, int indent = 0, int step = 0)
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      string AddWhitespace(string s, Func<bool> extra = null) =>
        addWhitespace && (extra ?? (() => true))()
          ? NewLineRegex.Replace(s, Environment.NewLine)
          : s;

      var sb = new StringBuilder(); 
      sb.Append(base.ToX12String(addWhitespace, indent, step));

      Segments
        .ToList()
        .ForEach(x => sb.Append(AddWhitespace(x.ToX12String(addWhitespace, indent + step, step))));
        
      return sb.ToString();
    }
  }
}