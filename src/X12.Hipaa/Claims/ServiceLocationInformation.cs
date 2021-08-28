using System.Xml.Serialization;

namespace X12.Hipaa.Claims
{
  public class ServiceLocationInformation
  {
    [XmlAttribute]
    public string Qualifier { get; set; }

    [XmlAttribute]
    public string FacilityCode { get; set; }

    [XmlAttribute]
    public string FrequencyTypeCode { get; set; }
  }
}