using System;
using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class CodedDate
  {
    [XmlAttribute]
    public string Code { get; set; }

    [XmlAttribute(DataType = "date")]
    public DateTime Date { get; set; }
  }
}