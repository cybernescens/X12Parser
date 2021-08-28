using X12.Extensions;

namespace X12.Parsing.Model.Typed
{
  /// <summary>
  ///   Service, Promotion, Allowance, or Charge Information
  /// </summary>
  public class TypedSegmentSAC : TypedSegment
  {
    public TypedSegmentSAC()
      : base("SAC") { }

    public AllowanceOrChargeIndicator SAC01_AllowanceOrChargeIndicator
    {
      get => this._segment.GetElement(1).ToEnumFromEDIFieldValue<AllowanceOrChargeIndicator>();
      set => this._segment.SetElement(1, value.EDIFieldValue());
    }

    public string SAC02_ServicePromotionAllowanceOrChargeCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string SAC03_AgencyQualifierCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string SAC04_AgencyServicePromotionAllowanceOrChageCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    /// <summary>
    ///   This is an implied decimal with 2 decimal points,
    ///   multiply your decimal by 100 to assign here
    /// </summary>
    public int? SAC05_AmountN2
    {
      get {
        int element;
        if (int.TryParse(this._segment.GetElement(5), out element))
          return element;

        return null;
      }
      set => this._segment.SetElement(5, string.Format("{0}", value));
    }

    /// <summary>
    ///   3 = Discount/Gross
    ///   Z = Mutually Defined
    /// </summary>
    public string SAC06_AllowanceChargePercentQualifier
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public decimal? SAC07_Percent
    {
      get => this._segment.GetDecimalElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string SAC13_ReferenceIdentification
    {
      get => this._segment.GetElement(13);
      set => this._segment.SetElement(13, value);
    }

    public string SAC14_OptionNumber
    {
      get => this._segment.GetElement(14);
      set => this._segment.SetElement(14, value);
    }

    public string SAC15_Description
    {
      get => this._segment.GetElement(15);
      set => this._segment.SetElement(15, value);
    }

    public string SAC16_LanguageCode
    {
      get => this._segment.GetElement(16);
      set => this._segment.SetElement(16, value);
    }
  }
}