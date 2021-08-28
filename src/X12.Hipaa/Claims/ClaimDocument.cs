using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace X12.Hipaa.Claims
{
  [XmlRoot(Namespace = "http://www.oopfactory.com/2011/XSL/Hipaa")]
  public class ClaimDocument
  {
    public ClaimDocument()
    {
      if (Claims == null) Claims = new List<Claim>();
    }

    [XmlElement(ElementName = "Claim")]
    public List<Claim> Claims { get; set; }

    #region Serialization Methods

    public string Serialize()
    {
      var writer = new StringWriter();
      new XmlSerializer(typeof(ClaimDocument)).Serialize(writer, this);
      return writer.ToString();
    }

    public static ClaimDocument Deserialize(string xml)
    {
      var serializer = new XmlSerializer(typeof(ClaimDocument));
      return (ClaimDocument) serializer.Deserialize(new StringReader(xml));
    }

    #endregion
  }
}