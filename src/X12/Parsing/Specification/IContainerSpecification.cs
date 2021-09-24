using System.Collections.Generic;

namespace X12.Parsing.Specification
{
  public interface IContainerSpecification
  {
    string LoopId { get; }
    List<SegmentSpecification> SegmentSpecifications { get; }
    List<LoopSpecification> LoopSpecifications { get; }
    List<HierarchicalLoopSpecification> HierarchicalLoopSpecifications { get; }
  }
}