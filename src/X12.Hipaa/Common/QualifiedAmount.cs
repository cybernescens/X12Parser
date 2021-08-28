using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class QualifiedAmount
  {
    [XmlAttribute]
    public string Qualifier { get; set; }

    [XmlAttribute]
    public decimal Amount { get; set; }

    [XmlText]
    public string Description { get; set; }
  }
}