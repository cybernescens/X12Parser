using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class Lookup
  {
    [XmlAttribute]
    public string Code { get; set; }

    [XmlText]
    public string Description { get; set; }
  }
}