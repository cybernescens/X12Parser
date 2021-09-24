using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace X12.Parsing.Specification
{
  [DebuggerStepThrough]
  [XmlType(AnonymousType = true)]
  public class HierarchicalLoopSpecification : IContainerSpecification
  {
    [XmlAttribute]
    public string LevelCode { get; set; }

    [XmlAttribute]
    public UsageEnum Usage { get; set; }

    public string Name { get; set; }
    
    [XmlElement("Segment")]
    public List<SegmentSpecification> SegmentSpecifications { get; set; }

    [XmlElement("Loop")]
    public List<LoopSpecification> LoopSpecifications { get; set; }

    [XmlElement("HierarchicalLoop")]
    public List<HierarchicalLoopSpecification> HierarchicalLoopSpecifications { get; set; }

    [XmlAttribute]
    public string LoopId { get; set; }
  }
}