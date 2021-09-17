using System;
using X12.Extensions;

namespace X12.Model
{
  public class TypedSegmentDTP : TypedSegment
  {
    public TypedSegmentDTP() : base("DTP") { }

    public DtpQualifier DTP01_DateTimeQualifier
    {
      get => this._segment.GetElement(1).ToEnumFromEdiFieldValue<DtpQualifier>();
      set => this._segment.SetElement(1, value.EdiFieldValue());
    }

    public DtpFormatQualifier DTP02_DateTimePeriodFormatQualifier
    {
      get => this._segment.GetElement(2).ToEnumFromEdiFieldValue<DtpFormatQualifier>();
      set => this._segment.SetElement(2, value.EdiFieldValue());
    }

    public DateTimePeriod DTP03_Date
    {
      get {
        var element = this._segment.GetElement(3);
        if (element.Length == 8)
          return new DateTimePeriod(DateTime.ParseExact(element, "yyyyMMdd", null));

        if (element.Length == 17)
          return new DateTimePeriod(
            DateTime.ParseExact(element.Substring(0, 8), "yyyyMMdd", null),
            DateTime.ParseExact(element.Substring(9), "yyyyMMdd", null));

        return null;
      }
      set =>
        this._segment.SetElement(
          3,
          value.IsDateRange
            ? string.Format("{0:yyyyMMdd}-{1:yyyyMMdd}", value.StartDate, value.EndDate)
            : string.Format("{0:yyyyMMdd}", value.StartDate));
    }
  }
}