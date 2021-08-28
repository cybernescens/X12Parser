using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class ProviderInformation : Identification
  {
    [XmlAttribute]
    public string ProviderCode { get; set; }

    [XmlAttribute]
    public string ProviderDescription { get; set; }
  }
}