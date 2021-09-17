namespace X12.Model
{
  public class TypedSegmentPRV : TypedSegment
  {
    public TypedSegmentPRV()
      : base("PRV") { }

    public string PRV01_ProviderCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PRV02_ReferenceIdQualifier
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string PRV03_ProviderTaxonomyCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string PRV04_StateOrProvinceCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string PRV05_ProviderSpecialtyInformation
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string PRV06_ProviderOrganizationCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}