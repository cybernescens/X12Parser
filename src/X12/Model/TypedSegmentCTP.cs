namespace X12.Model
{
  /// <summary>
  ///   Pricing Infomration
  /// </summary>
  public class TypedSegmentCTP : TypedSegment
  {
    public TypedSegmentCTP()
      : base("CTP") { }

    public string CTP01_ClassOfTradeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string CTP02_PriceIDCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public decimal? CTP03_UnitPrice
    {
      get => this._segment.GetDecimalElement(3);
      set => this._segment.SetElement(3, value);
    }

    public decimal? CTIP04_Quantity
    {
      get => this._segment.GetDecimalElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string CTP05_CompositeUnitOfMeasure
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string CTP06_PriceMultiplierQualifier
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public decimal? CTP07_Multiplier
    {
      get => this._segment.GetDecimalElement(7);
      set => this._segment.SetElement(7, value);
    }

    public decimal? CTP08_MonetaryAmount
    {
      get => this._segment.GetDecimalElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string CTP09_BaseUnitPriceCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }

    public string CTP10_ConditionValue
    {
      get => this._segment.GetElement(10);
      set => this._segment.SetElement(10, value);
    }

    public int? CTP11_MultiplePriceQuantity
    {
      get => this._segment.GetIntElement(11);
      set => this._segment.SetElement(11, value);
    }
  }
}