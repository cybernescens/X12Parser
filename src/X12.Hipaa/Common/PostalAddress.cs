using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class PostalAddress
  {
    public string Line1 { get; set; }
    public string Line2 { get; set; }

    [XmlAttribute]
    public string City { get; set; }

    [XmlAttribute]
    public string StateCode { get; set; }

    [XmlAttribute]
    public string PostalCode { get; set; }

    [XmlAttribute]
    public string CountryCode { get; set; }

    [XmlAttribute]
    public string CountrySubdivisionCode { get; set; }

    public string Locale => string.Format("{0}, {1} {2}", City, StateCode, PostalCode);
  }
}