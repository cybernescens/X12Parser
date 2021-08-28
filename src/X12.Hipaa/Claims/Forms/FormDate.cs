using System.Xml.Serialization;

namespace X12.Hipaa.Claims.Forms
{
  public class FormDate
  {
    [XmlAttribute]
    public string MM { get; set; }

    [XmlAttribute]
    public string DD { get; set; }

    [XmlAttribute]
    public string YY { get; set; }

    public override string ToString() => string.Format("{0}/{1}/{2}", MM, DD, YY);
  }
}