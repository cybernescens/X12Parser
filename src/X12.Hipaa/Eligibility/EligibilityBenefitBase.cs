using X12.Hipaa.Common;

namespace X12.Hipaa.Eligibility
{
  public abstract class EligibilityBenefitBase
  {
    public Entity Source { get; set; }
    public Provider Receiver { get; set; }

    public BenefitMember Subscriber { get; set; }
    public BenefitMember Dependent { get; set; }
  }
}