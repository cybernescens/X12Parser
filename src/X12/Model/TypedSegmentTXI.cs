using X12.Extensions;

namespace X12.Model
{
  /// <summary>
  ///   Tax Information
  /// </summary>
  public class TypedSegmentTXI : TypedSegment
  {
    public TypedSegmentTXI()
      : base("TXI") { }

    public string TXI01_TaxTypeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public decimal? TXI02_MonetaryAmount
    {
      get => this._segment.GetDecimalElement(2);
      set => this._segment.SetElement(2, value);
    }

    public decimal? TXI03_Percent
    {
      get => this._segment.GetDecimalElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string TXI04_TaxJurisdictionCodeQualifier
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string TXI05_TaxJurisdictionCode
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string TXI06_TaxExemptCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public RelationshipCode TXI07_RelationshipCode
    {
      get => this._segment.GetElement(7).ToEnumFromEdiFieldValue<RelationshipCode>();
      set => this._segment.SetElement(7, value.EdiFieldValue());
    }

    public decimal? TXI08_DollarBasisForPercent
    {
      get => this._segment.GetDecimalElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string TXI09_TaxIdentificationNumber
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }

    public string TXI10_AssignedIdentification
    {
      get => this._segment.GetElement(10);
      set => this._segment.SetElement(10, value);
    }
  }
}