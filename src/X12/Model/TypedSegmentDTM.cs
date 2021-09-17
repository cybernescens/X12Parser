using X12.Extensions;

namespace X12.Model
{
  /// <summary>
  ///   Date/Time Reference
  /// </summary>
  public class TypedSegmentDTM : TypedSegment
  {
    public TypedSegmentDTM()
      : base("DTM") { }

    public DtpQualifier DTM01_DateTimeQualifier
    {
      get => this._segment.GetElement(1).ToEnumFromEdiFieldValue<DtpQualifier>();
      set => this._segment.SetElement(1, value.EdiFieldValue());
    }

    public string DTM02_Date
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string DTM03_Time
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public TimeCode DTM04_TimeCode
    {
      get => this._segment.GetElement(4).ToEnumFromEdiFieldValue<TimeCode>();
      set => this._segment.SetElement(4, value.EdiFieldValue());
    }

    public DtpFormatQualifier DTM05_DateTimePeriodFormatQualifier
    {
      get => this._segment.GetElement(5).ToEnumFromEdiFieldValue<DtpFormatQualifier>();
      set => this._segment.SetElement(5, value.EdiFieldValue());
    }

    public string DTM06_DateTimePeriod
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}