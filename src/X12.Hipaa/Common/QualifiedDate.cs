using System;
using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class QualifiedDate
  {
    [XmlAttribute]
    public string Qualifier { get; set; }

    [XmlAttribute]
    public DateTime Date { get; set; }

    [XmlText]
    public string Description { get; set; }
  }
}