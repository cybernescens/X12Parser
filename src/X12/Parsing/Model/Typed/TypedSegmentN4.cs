namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentN4 : TypedSegment
  {
    public TypedSegmentN4()
      : base("N4") { }

    public string N401_CityName
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string N402_StateOrProvinceCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string N403_PostalCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string N404_CountryCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string N405_LocationQualifier
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string N406_LocationIdentifier
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string N407_CountrySubdivisionCode
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }
  }
}