using X12.Extensions;

namespace X12.Model
{
  public class TypedSegmentCN1 : TypedSegment
  {
    public TypedSegmentCN1()
      : base("CN1") { }

    public string CN101_ContractTypeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public ContractTypeCode CN101_ContractTypeCodeEnum
    {
      get => this._segment.GetElement(1).ToEnumFromEdiFieldValue<ContractTypeCode>();
      set => this._segment.SetElement(1, value.EdiFieldValue());
    }

    public decimal? CN102_MonetaryAmount
    {
      get => this._segment.GetDecimalElement(2);
      set => this._segment.SetElement(2, value);
    }

    public decimal? CN103_Percent
    {
      get => this._segment.GetDecimalElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string CN104_ReferenceIdentification
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public decimal? CN105_TermsDiscountPercent
    {
      get => this._segment.GetDecimalElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string CN106_VersionIdentifier
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}