namespace X12.Parsing.Model.Typed
{
  /// <summary>
  ///   Currency
  /// </summary>
  public class TypedSegmentCUR : TypedSegment
  {
    public TypedSegmentCUR()
      : base("CUR") { }

    /// <summary>
    ///   BY = Buying Party (Purchaser)
    ///   SE = Selling Party
    /// </summary>
    public string CUR01_EntityIdentifierCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    /// <summary>
    ///   CAD = Canadian dollars
    ///   USD = US Dollars
    /// </summary>
    public string CUR02_CurrencyCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public decimal? CUR03_ExchangeRate
    {
      get => this._segment.GetDecimalElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string CUR04_EntityIdentifierCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string CUR05_CurrencyCode
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string CUR06_CurrencyMarketExchangeCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}