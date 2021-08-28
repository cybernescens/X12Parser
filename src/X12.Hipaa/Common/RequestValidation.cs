using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class RequestValidation
  {
    [XmlAttribute]
    public bool ValidRequest { get; set; }

    public Lookup RejectReason { get; set; }
    public Lookup FollupAction { get; set; }
  }
}