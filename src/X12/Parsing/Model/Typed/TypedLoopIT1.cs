using X12.Extensions;

namespace X12.Parsing.Model.Typed
{
  /// <summary>
  ///   Baseline Item Data (Invoice)
  /// </summary>
  public class TypedLoopIT1 : TypedLoop
  {
    public TypedLoopIT1()
      : base("IT1") { }

    public string IT101_AssignedIdentification
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public decimal? IT102_QuantityInvoiced
    {
      get => this._loop.GetDecimalElement(2);
      set => this._loop.SetElement(2, value);
    }

    public UnitOrBasisOfMeasurementCode IT103_UnitOrBasisForMeasurementCode
    {
      get => this._loop.GetElement(3).ToEnumFromEDIFieldValue<UnitOrBasisOfMeasurementCode>();
      set => this._loop.SetElement(3, value.EDIFieldValue());
    }

    public decimal? IT104_UnitPrice
    {
      get => this._loop.GetDecimalElement(4);
      set => this._loop.SetElement(4, value);
    }

    public string IT106_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(6);
      set => this._loop.SetElement(6, value);
    }

    public string IT107_ProductServiceId
    {
      get => this._loop.GetElement(7);
      set => this._loop.SetElement(7, value);
    }

    public string IT108_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(8);
      set => this._loop.SetElement(8, value);
    }

    public string IT109_ProductServiceId
    {
      get => this._loop.GetElement(9);
      set => this._loop.SetElement(9, value);
    }

    public string IT110_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(10);
      set => this._loop.SetElement(10, value);
    }

    public string IT111_ProductServiceId
    {
      get => this._loop.GetElement(11);
      set => this._loop.SetElement(11, value);
    }

    public string IT112_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(12);
      set => this._loop.SetElement(12, value);
    }

    public string IT113_ProductServiceId
    {
      get => this._loop.GetElement(13);
      set => this._loop.SetElement(13, value);
    }

    public string IT114_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(14);
      set => this._loop.SetElement(14, value);
    }

    public string IT115_ProductServiceId
    {
      get => this._loop.GetElement(15);
      set => this._loop.SetElement(15, value);
    }

    public string IT116_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(16);
      set => this._loop.SetElement(16, value);
    }

    public string IT117_ProductServiceId
    {
      get => this._loop.GetElement(17);
      set => this._loop.SetElement(17, value);
    }

    public string IT118_ProductServiceIdQualifier
    {
      get => this._loop.GetElement(18);
      set => this._loop.SetElement(18, value);
    }

    public string IT119_ProductServiceId
    {
      get => this._loop.GetElement(19);
      set => this._loop.SetElement(19, value);
    }
  }
}