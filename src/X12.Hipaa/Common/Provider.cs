using System.Linq;
using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class Provider : Entity
  {
    [XmlAttribute]
    public string Npi
    {
      get {
        if (Name != null && Name.Identification != null && Name.Identification.Qualifier == "XX")
          return Name.Identification.Id;

        return GetReferenceId("HPI");
      }
      set { }
    }

    [XmlAttribute]
    public string TaxId
    {
      get {
        if (Name != null && Name.Identification != null && new[] { "FI", "24" }.Contains(Name.Identification.Qualifier))
          return Name.Identification.Id;

        var taxId = GetReferenceId("EI");
        if (taxId != null)
          return taxId;

        return GetReferenceId("TJ");
      }
      set { }
    }

    [XmlAttribute]
    public string ServiceProviderNumber
    {
      get {
        if (Name != null && Name.Identification != null && Name.Identification.Qualifier == "SV")
          return Name.Identification.Id;

        return null;
      }
      set { }
    }

    public ProviderInformation ProviderInfo { get; set; }
  }
}