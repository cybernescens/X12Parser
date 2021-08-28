namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentAMT : TypedSegment
  {
    public TypedSegmentAMT()
      : base("AMT") { }

    public string AMT01_AmountQualifierCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string AMT02_MonetaryAmount
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string AMT03_CreditDebigFlagCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }
  }
}