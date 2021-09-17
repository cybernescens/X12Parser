using System;
using X12.Model;

namespace X12.Persistence.Model
{
  public class IndexedSegmentEntity : Entity
  {
    private readonly Segment _segment;

    public IndexedSegmentEntity(Segment segment, object interchangeId, object transactionSetId)
    {
      _segment = segment;
      InterchangeId = interchangeId;
      TransactionSetId = transactionSetId;
    }

    public object InterchangeId { get; set; }
    public long PositionInInterchange { get; set; }
    public object TransactionSetId { get; set; }
    public object? ParentLoopId { get; set; }
    public object? LoopId { get; set; }
    public object? ErrorId { get; set; }

    public DateTime? GetDateElement(string element) => _segment.GetDate8Element(int.Parse(element));
    public decimal? GetDecimalElement(string element) => _segment.GetDecimalElement(int.Parse(element));
    public string GetElement(string element) => _segment.GetElement(int.Parse(element));
    public int? GetIntElement(string element) => _segment.GetIntElement(int.Parse(element));
    public long? GetLongElement(string element) => _segment.GetLongElement(int.Parse(element));
    public TimeSpan? GetTimeElement(string element) => _segment.GetTimeElement(int.Parse(element));
    public string GetSegmentId() => _segment.SegmentId;

    public short? GetShortElement(string element)
    {
      unchecked
      {
        var value = _segment.GetIntElement(int.Parse(element));
        return value.HasValue ? (short)value.Value : null;
      }
    }
  }
}