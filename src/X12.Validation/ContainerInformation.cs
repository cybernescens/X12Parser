using System.Collections.Generic;
using X12.Parsing.Specification;

namespace X12.Validation
{
  public class ContainerInformation
  {
    public ContainerInformation()
    {
      Segments = new List<SegmentInformation>();
      Containers = new List<ContainerInformation>();
    }

    public IContainerSpecification Spec { get; set; }
    public string HLoopNumber { get; set; }
    public List<SegmentInformation> Segments { get; }
    public List<ContainerInformation> Containers { get; }

    public override string ToString()
    {
      if (Spec == null)
        return base.ToString();

      return string.Format("LoopId={0}, Segments={1}, Loop={2}", Spec.LoopId, Segments.Count, Containers.Count);
    }
  }
}