using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Claims
{
  public class SubmitterInfo
  {
    public SubmitterInfo()
    {
      if (Providers == null) Providers = new Provider();
    }

    [XmlElement(ElementName = "Provider")]
    public Provider Providers { get; set; }
  }
}