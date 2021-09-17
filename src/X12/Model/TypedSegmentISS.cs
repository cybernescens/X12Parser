using X12.Extensions;

namespace X12.Model
{
  /// <summary>
  ///   Invoice Shipment Summary
  /// </summary>
  public class TypedSegmentISS : TypedSegment
  {
    public TypedSegmentISS()
      : base("ISS") { }

    public decimal? ISS01_NumberOfUnitsShipped
    {
      get => this._segment.GetDecimalElement(1);
      set => this._segment.SetElement(1, value);
    }

    /// <summary>
    ///   CA = Case
    /// </summary>
    public UnitOrBasisOfMeasurementCode ISS02_UnitOrBasisForMeasurementCode
    {
      get => this._segment.GetElement(2).ToEnumFromEdiFieldValue<UnitOrBasisOfMeasurementCode>();
      set => this._segment.SetElement(2, value.EdiFieldValue());
    }

    public decimal? ISS03_Weight
    {
      get => this._segment.GetDecimalElement(3);
      set => this._segment.SetElement(3, value);
    }

    /// <summary>
    ///   LB = Pounds
    /// </summary>
    public UnitOrBasisOfMeasurementCode ISS04_UnitOrBasisForMeasurementCode
    {
      get => this._segment.GetElement(4).ToEnumFromEdiFieldValue<UnitOrBasisOfMeasurementCode>();
      set => this._segment.SetElement(4, value.EdiFieldValue());
    }

    public decimal? ISS05_Volume
    {
      get => this._segment.GetDecimalElement(5);
      set => this._segment.SetElement(5, value);
    }

    public UnitOrBasisOfMeasurementCode ISS06_UnitOrBasisForMeasurementCode
    {
      get => this._segment.GetElement(6).ToEnumFromEdiFieldValue<UnitOrBasisOfMeasurementCode>();
      set => this._segment.SetElement(6, value.EdiFieldValue());
    }
  }
}