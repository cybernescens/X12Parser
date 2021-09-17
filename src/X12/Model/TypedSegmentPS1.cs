namespace X12.Model
{
  public class TypedSegmentPS1 : TypedSegment
  {
    public TypedSegmentPS1()
      : base("PS1") { }

    public string PS101_ReferenceId
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PS102_MonentaryAmount
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string PS103_StateOrProvinceCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }
  }
}