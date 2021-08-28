using System.Collections.Generic;
using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Claims
{
  public class BillingInformation
  {
    public BillingInformation()
    {
      if (Providers == null) Providers = new List<Provider>();
    }

    public Lookup Currency { get; set; }
    public ProviderInformation ProviderInfo { get; set; }

    [XmlElement(ElementName = "Provider")]
    public List<Provider> Providers { get; set; }
  }
}