using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace X12.Parsing.Specification
{
  [DebuggerStepThrough]
  [XmlType(AnonymousType = true)]
  public class StartingSegment : SegmentSpecification
  {
    public StartingSegment()
    {
      if (EntityIdentifiers == null) EntityIdentifiers = new List<Lookup>();
    }

    [XmlElement("EntityIdentifier")]
    public List<Lookup> EntityIdentifiers { get; set; }
  }
}