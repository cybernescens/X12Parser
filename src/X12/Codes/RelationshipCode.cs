using X12.Attributes;

namespace X12.Codes
{
  public enum RelationshipCode
  {
    [EdiFieldValue("A")]
    Add,

    [EdiFieldValue("D")]
    Delete,

    [EdiFieldValue("I")]
    Include,

    [EdiFieldValue("O")]
    InformationOnly,

    [EdiFieldValue("S")]
    Substituted
  }
}