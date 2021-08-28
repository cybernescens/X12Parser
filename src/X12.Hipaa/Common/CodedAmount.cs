using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class CodedAmount
  {
    [XmlAttribute]
    public string Code { get; set; }

    [XmlIgnore]
    public decimal? Amount { get; set; }

    [XmlAttribute(AttributeName = "Amount")]
    public decimal SerializableAmount
    {
      get => Amount ?? decimal.Zero;
      set => Amount = value;
    }

    [XmlIgnore]
    public bool SerializableAmountSpecified
    {
      get => Amount.HasValue;
      set { }
    }
  }
}