using System;
using System.Linq;
using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Claims
{
  public class InstitutionalProcedure
  {
    [XmlAttribute]
    public bool IsPrincipal
    {
      get { return new[] { "BBR", "BR", "CAH" }.Contains(Qualifier); }
      set { }
    }

    [XmlAttribute]
    public CodeListEnum Version
    {
      get {
        switch (Qualifier)
        {
          case "BBR":
          case "BBQ":
            return CodeListEnum.ICD10;
          case "BR":
          case "BQ":
            return CodeListEnum.ICD9;
          case "CAH":
            return CodeListEnum.ABC;
          default:
            return CodeListEnum.Unknown;
        }
      }
      set { }
    }

    [XmlAttribute]
    public string Qualifier { get; set; }

    [XmlAttribute]
    public string Code { get; set; }

    [XmlAttribute(DataType = "date")]
    public DateTime Date { get; set; }
  }
}