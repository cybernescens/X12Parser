using X12.Hipaa.Common;

namespace X12.Hipaa.ClaimStatus
{
  public class ClaimStatusBase
  {
    public EntityName Source { get; set; }
    public EntityName Receiver { get; set; }
    public EntityName ServiceProvider { get; set; }
    public Member Subscriber { get; set; }
    public Member Dependent { get; set; }
  }
}