using X12.Extensions;

namespace X12.Model
{
  public class TypedLoopPID : TypedLoop
  {
    public TypedLoopPID()
      : base("PID") { }

    /// <summary>
    ///   F = Free form
    /// </summary>
    public string PID01_ItemDescriptionType
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public string PID02_ProductProcessCharacteristicCode
    {
      get => this._loop.GetElement(2);
      set => this._loop.SetElement(2, value);
    }

    public string PID03_AgencyQualifierCode
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string PID04_ProductDescriptionCode
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    public string PID05_Description
    {
      get => this._loop.GetElement(5);
      set => this._loop.SetElement(5, value);
    }

    public string PID06_SurfaceLayerPositionCode
    {
      get => this._loop.GetElement(6);
      set => this._loop.SetElement(6, value);
    }

    public string PID07_SourceSubqualifier
    {
      get => this._loop.GetElement(7);
      set => this._loop.SetElement(7, value);
    }

    public YesNoConditionOrResponseCode PID08_YesNoConditionOrResponseCode
    {
      get => this._loop.GetElement(8).ToEnumFromEdiFieldValue<YesNoConditionOrResponseCode>();
      set => this._loop.SetElement(8, value.EdiFieldValue());
    }

    public string PID09_LanguageCode
    {
      get => this._loop.GetElement(9);
      set => this._loop.SetElement(9, value);
    }
  }
}