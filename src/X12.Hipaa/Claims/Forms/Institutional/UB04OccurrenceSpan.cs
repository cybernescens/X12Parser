using X12.Hipaa.Common;

namespace X12.Hipaa.Claims.Forms.Institutional
{
  public class UB04OccurrenceSpan
  {
    public string Code { get; set; }
    public string FromDate { get; set; }
    public string ThroughDate { get; set; }

    public UB04OccurrenceSpan CopyFrom(CodedDate source)
    {
      Code = source.Code;
      FromDate = string.Format("{0:MMddyy}", source.Date);
      return this;
    }

    public UB04OccurrenceSpan CopyFrom(CodedDateRange source)
    {
      Code = source.Code;
      FromDate = string.Format("{0:MMddyy}", source.FromDate);
      ThroughDate = string.Format("{0:MMddyy}", source.ThroughDate);
      return this;
    }
  }
}