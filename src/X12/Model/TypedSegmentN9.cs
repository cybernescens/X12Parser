namespace X12.Model
{
  public class TypedSegmentN9 : TypedSegment
  {
    public TypedSegmentN9()
      : base("N9") { }

    public string N901_ReferenceIdentificationQualifier
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string N902_ReferenceIdentification
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }
  }
}