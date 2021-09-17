using System;

namespace X12.Model
{
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