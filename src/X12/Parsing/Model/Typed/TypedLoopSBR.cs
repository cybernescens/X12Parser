namespace X12.Parsing.Model.Typed
{
  public class TypedLoopSBR : TypedLoop
  {
    public TypedLoopSBR()
      : base("SBR") { }

    public string SBR01_PayerResponsibilitySequenceNumberCode
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public string SBR02_IndividualRelationshipCode
    {
      get => this._loop.GetElement(2);
      set => this._loop.SetElement(2, value);
    }

    public string SBR03_PolicyOrGroupNumber
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string SBR04_GroupName
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    public string SBR05_InsuranceTypeCode
    {
      get => this._loop.GetElement(5);
      set => this._loop.SetElement(5, value);
    }

    public string SBR06_CoordinationOfBenefitsCode
    {
      get => this._loop.GetElement(6);
      set => this._loop.SetElement(6, value);
    }

    public string SBR07_YesNoCode
    {
      get => this._loop.GetElement(7);
      set => this._loop.SetElement(7, value);
    }

    public string SBR08_EmploymentStatusCode
    {
      get => this._loop.GetElement(8);
      set => this._loop.SetElement(8, value);
    }

    public string SBR09_ClaimFilingIndicatorCode
    {
      get => this._loop.GetElement(9);
      set => this._loop.SetElement(9, value);
    }
  }
}