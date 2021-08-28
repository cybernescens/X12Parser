using X12.Parsing.Specification;

namespace X12.Validation
{
  public class SegmentInformation
  {
    public string SegmentId { get; set; }
    public int SegmentPosition { get; set; }
    public string[] Elements { get; set; }
    public string LoopId { get; set; }
    public SegmentSpecification Spec { get; set; }

    public override string ToString() => string.Format("Id={0}, Pos={1}, Loop={2}", SegmentId, SegmentPosition, LoopId);
  }
}