namespace X12.Model
{
  public class TypedSegmentSBR : TypedSegment
  {
    public TypedSegmentSBR()
      : base("SBR") { }

    public string SBR01_PayerResponsibilitySequenceNumberCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string SBR02_IndividualRelationshipCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string SBR03_PolicyOrGroupNumber
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string SBR04_GroupName
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string SBR05_InsuranceTypeCode
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string SBR06_CoordinationOfBenefitsCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string SBR07_YesNoCode
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string SBR08_EmploymentStatusCode
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string SBR09_ClaimFilingIndicatorCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }
  }
}