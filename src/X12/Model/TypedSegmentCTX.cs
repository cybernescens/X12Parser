namespace X12.Model
{
  public class TypedSegmentCTX : TypedSegment
  {
    public TypedSegmentCTX() : base("CTX")
    {
      CTX01 = new TypedElementContextIdentification(this._segment, 1);
      CTX05 = new TypedElementPositionInSegment(this._segment, 5);
    }

    public TypedElementContextIdentification CTX01 { get; }

    public string CTX02_SegmentIdCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public int? CTX03_SegmentPositionInTransactionSet
    {
      get {
        int position;
        if (int.TryParse(this._segment.GetElement(3), out position))
          return position;

        return null;
      }
      set => this._segment.SetElement(3, string.Format("{0}", value));
    }

    public string CTX04_LoopIdentifierCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public TypedElementPositionInSegment CTX05 { get; }
  }
}