using System;
using X12.Extensions;

namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentDTP : TypedSegment
  {
    public TypedSegmentDTP() : base("DTP") { }

    public DTPQualifier DTP01_DateTimeQualifier
    {
      get => this._segment.GetElement(1).ToEnumFromEDIFieldValue<DTPQualifier>();
      set => this._segment.SetElement(1, value.EDIFieldValue());
    }

    public DTPFormatQualifier DTP02_DateTimePeriodFormatQualifier
    {
      get => this._segment.GetElement(2).ToEnumFromEDIFieldValue<DTPFormatQualifier>();
      set => this._segment.SetElement(2, value.EDIFieldValue());
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

  /// <summary>
  ///   Move this class in seperate file if being used by other classes.
  /// </summary>
  public class DateTimePeriod
  {
    public DateTimePeriod(DateTime date)
    {
      StartDate = date;
      IsDateRange = false;
    }

    public DateTimePeriod(DateTime startDate, DateTime endDate)
    {
      StartDate = startDate;
      EndDate = endDate;
      IsDateRange = true;
    }

    public bool IsDateRange { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
  }
}