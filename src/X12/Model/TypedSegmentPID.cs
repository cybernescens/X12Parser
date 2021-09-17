using X12.Extensions;

namespace X12.Model
{
  /// <summary>
  ///   Product/Item Description
  /// </summary>
  public class TypedSegmentPID : TypedSegment
  {
    public TypedSegmentPID()
      : base("PID") { }

    /// <summary>
    ///   F = Free form
    /// </summary>
    public string PID01_ItemDescriptionType
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PID02_ProductProcessCharacteristicCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string PID03_AgencyQualifierCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string PID04_ProductDescriptionCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string PID05_Description
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string PID06_SurfaceLayerPositionCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string PID07_SourceSubqualifier
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public YesNoConditionOrResponseCode PID08_YesNoConditionOrResponseCode
    {
      get => this._segment.GetElement(8).ToEnumFromEdiFieldValue<YesNoConditionOrResponseCode>();
      set => this._segment.SetElement(8, value.EdiFieldValue());
    }

    public string PID09_LanguageCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }
  }
}