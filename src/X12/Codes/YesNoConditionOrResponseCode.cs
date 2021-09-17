using X12.Attributes;

namespace X12.Codes
{
  public enum YesNoConditionOrResponseCode
  {
    [EdiFieldValue("N")]
    No,

    [EdiFieldValue("U")]
    Unknown,

    [EdiFieldValue("W")]
    NotApplicable,

    [EdiFieldValue("Y")]
    Yes
  }
}