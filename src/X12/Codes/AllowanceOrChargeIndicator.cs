using X12.Attributes;

namespace X12.Codes
{
  public enum AllowanceOrChargeIndicator
  {
    [EdiFieldValue("A")]
    Allowance,

    [EdiFieldValue("C")]
    Charge,

    [EdiFieldValue("N")]
    NoAllowanceOrCharge,

    [EdiFieldValue("P")]
    Promotion,

    [EdiFieldValue("Q")]
    ChargeRequest,

    [EdiFieldValue("R")]
    AllowanceRequest,

    [EdiFieldValue("S")]
    Service
  }
}