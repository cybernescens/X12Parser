using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum AllowanceOrChargeIndicator
  {
    [EDIFieldValue("A")]
    Allowance,

    [EDIFieldValue("C")]
    Charge,

    [EDIFieldValue("N")]
    NoAllowanceOrCharge,

    [EDIFieldValue("P")]
    Promotion,

    [EDIFieldValue("Q")]
    ChargeRequest,

    [EDIFieldValue("R")]
    AllowanceRequest,

    [EDIFieldValue("S")]
    Service
  }
}