using System;

namespace X12.Parsing.Model
{
  public abstract class TypedSegment
  {
    internal Segment _segment;
    private readonly string _segmentId;

    protected TypedSegment(string segmentId) { _segmentId = segmentId; }

    public event EventHandler Initializing;
    public event EventHandler Initialized;

    protected virtual void OnInitializing(EventArgs e)
    {
      if (Initializing != null)
        Initializing(this, e);
    }

    protected virtual void OnInitialized(EventArgs e)
    {
      if (Initialized != null)
        Initialized(this, e);
    }

    internal void Initialize(Container parent, X12DelimiterSet delimiters)
    {
      OnInitializing(new EventArgs());
      _segment = new Segment(parent, delimiters, _segmentId);
      OnInitialized(new EventArgs());
    }
  }
}