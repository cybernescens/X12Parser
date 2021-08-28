using System.Xml.Serialization;

namespace X12.Hipaa.Claims
{
  public class ClaimsAdjustment
  {
    [XmlAttribute]
    public string GroupCode { get; set; }

    [XmlAttribute]
    public string ReasonCode { get; set; }

    [XmlAttribute]
    public decimal Amount { get; set; }

    [XmlIgnore]
    public decimal? Quantity { get; set; }

    [XmlAttribute(AttributeName = "Quantity")]
    public decimal SerializableQuantity
    {
      get => Quantity ?? decimal.Zero;
      set => Quantity = value;
    }

    [XmlIgnore]
    public bool SerializableQuantitySpecified
    {
      get => Quantity.HasValue;
      set { }
    }
  }
}