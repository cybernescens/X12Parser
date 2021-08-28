using System.Collections.Generic;
using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Claims
{
  public class ToothInformation
  {
    [XmlAttribute]
    public string ToothCode { get; set; }

    [XmlElement(ElementName = "ToothSurface")]
    public List<Lookup> ToothSurfaces { get; set; }
  }
}