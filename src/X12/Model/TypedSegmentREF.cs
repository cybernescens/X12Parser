namespace X12.Model
{
  public class TypedSegmentREF : TypedSegment
  {
    public TypedSegmentREF()
      : base("REF") { }

    public string REF01_ReferenceIdQualifier
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string REF02_ReferenceId
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string REF03_Description
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string REF04_ReferenceId
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }
  }
}