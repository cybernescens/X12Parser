namespace X12.Model
{
  public class TypedSegmentN2 : TypedSegment
  {
    public TypedSegmentN2()
      : base("N2") { }

    public string N201_Name
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string N202_Name
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }
  }
}