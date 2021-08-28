using System.Diagnostics;
using System.Xml.Serialization;

namespace X12.Parsing.Specification
{
  [DebuggerStepThrough]
  [XmlType(AnonymousType = true)]
  public class Lookup
  {
    [XmlAttribute]
    public string Code { get; set; }
  }
}