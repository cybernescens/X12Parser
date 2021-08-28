using System;
using X12.Parsing.Specification;

namespace X12.Parsing.Model.Typed
{
  public class TypedLoopCLM : TypedLoop
  {
    public TypedLoopCLM() : base("CLM") { }

    public string CLM01_PatientControlNumber
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public decimal CLM02_TotalClaimChargeAmount
    {
      get {
        decimal amount;
        if (decimal.TryParse(this._loop.GetElement(2), out amount))
          return amount;

        return 0;
      }
      set {
        if (value < 0)
          throw new ArgumentOutOfRangeException("Total Claim Charge Amount must be greater than or equal to zero.");

        this._loop.SetElement(2, value.ToString().TrimStart('0'));
      }
    }

    public string CLM03_ClaimFilingIndicatorCode
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string CLM04_NonInstitutionalClaimTypeCode
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    public TypedElementServiceLocationInfo CLM05 { get; private set; }

    public bool? CLM06_ProviderOrSupplierSignatureIndicator
    {
      get {
        switch (this._loop.GetElement(6))
        {
          case "Y": return true;
          case "N": return false;
          default:  return null;
        }
      }
      set {
        if (value.HasValue)
        {
          if (value.Value)
            this._loop.SetElement(6, "Y");
          else
            this._loop.SetElement(6, "N");
        }
        else
        {
          this._loop.SetElement(6, "");
        }
      }
    }

    public string CLM07_ProviderAcceptAssignmentCode
    {
      get => this._loop.GetElement(7);
      set => this._loop.SetElement(7, value);
    }

    public string CLM08_BenefitsAssignmentCerficationIndicator
    {
      get => this._loop.GetElement(8);
      set => this._loop.SetElement(8, value);
    }

    public string CLM09_ReleaseOfInformationCode
    {
      get => this._loop.GetElement(9);
      set => this._loop.SetElement(9, value);
    }

    public string CLM10_PatientSignatureSourceCode
    {
      get => this._loop.GetElement(10);
      set => this._loop.SetElement(10, value);
    }

    public TypedElementRelatedCausesInfo CLM11 { get; private set; }

    public string CLM12_SpecialProgramCode
    {
      get => this._loop.GetElement(12);
      set => this._loop.SetElement(12, value);
    }

    public string CLM20_DelayReasonCode
    {
      get => this._loop.GetElement(20);
      set => this._loop.SetElement(20, value);
    }

    internal override void Initialize(Container parent, X12DelimiterSet delimiters, LoopSpecification loopSpecification)
    {
      base.Initialize(parent, delimiters, loopSpecification);
      CLM05 = new TypedElementServiceLocationInfo(this._loop, 5);
      CLM11 = new TypedElementRelatedCausesInfo(this._loop, 11);
    }
  }
}