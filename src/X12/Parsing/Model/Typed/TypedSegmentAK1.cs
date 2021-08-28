namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentAK1 : TypedSegment
  {
    public TypedSegmentAK1()
      : base("AK1") { }

    public string AK101_FunctionalIdCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string AK102_GroupControlNumber
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string AK103_VersionIdentifierCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }
  }
}