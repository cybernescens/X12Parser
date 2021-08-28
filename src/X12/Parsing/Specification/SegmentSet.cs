using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace X12.Parsing.Specification
{
  [XmlRoot(Namespace = "http://tempuri.org/X12ParserSpecification.xsd")]
  public class SegmentSet
  {
    public SegmentSet()
    {
      if (QualifierSets == null) QualifierSets = new List<QualifierSet>();
      if (Segments == null) Segments = new List<SegmentSpecification>();
    }

    public string Name { get; set; }

    [XmlElement("QualifierSet")]
    public List<QualifierSet> QualifierSets { get; set; }

    [XmlElement("Segment")]
    public List<SegmentSpecification> Segments { get; set; }

    public string Serialize()
    {
      var xmlSerializer = new XmlSerializer(typeof(SegmentSet));
      var mstream = new MemoryStream();
      xmlSerializer.Serialize(mstream, this);
      mstream.Seek(0, SeekOrigin.Begin);
      var streamReader = new StreamReader(mstream);
      return streamReader.ReadToEnd();
    }

    public static SegmentSet Deserialize(string xml)
    {
      var stringReader = new StringReader(xml);
      var xmlTextReader = new XmlTextReader(stringReader);
      var xmlSerializer = new XmlSerializer(typeof(SegmentSet));

      return (SegmentSet) xmlSerializer.Deserialize(xmlTextReader);
    }
  }
}