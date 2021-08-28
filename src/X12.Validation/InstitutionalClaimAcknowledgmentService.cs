using X12.Parsing;

namespace X12.Validation
{
  public class InstitutionalClaimAcknowledgmentService : X12AcknowledgmentService
  {
    public InstitutionalClaimAcknowledgmentService()
      : base(new InstitutionalClaimSpecificationFinder()) { }
  }
}