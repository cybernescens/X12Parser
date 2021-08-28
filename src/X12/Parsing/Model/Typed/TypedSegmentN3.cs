namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentN3 : TypedSegment
  {
    public TypedSegmentN3()
      : base("N3") { }

    public string N301_AddressInformation
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string N302_AddressInformation
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }
  }
}