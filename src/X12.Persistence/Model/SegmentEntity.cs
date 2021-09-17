using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X12.Model;

namespace X12.Persistence.Model
{
  [Table("Segment")]
  public class SegmentEntity : Entity
  {
    public SegmentEntity(object interchangeId, long positionInInterchange, string segment, string segmentText)
    {
      InterchangeId = interchangeId;
      PositionInInterchange = positionInInterchange;
      Segment = segment;
      SegmentText = segmentText;
    }

    [ForeignKey(nameof(InterchangeEntity))]
    [Required]
    public object InterchangeId { get; set; }

    [Required]
    public long PositionInInterchange { get; set; }

    [ForeignKey(nameof(FunctionalGroupEntity))]
    public object? FunctionalGroupId { get; set; }

    [ForeignKey(nameof(TransactionSetEntity))]
    public object? TransactionSetId { get; set; }

    [ForeignKey(nameof(LoopEntity))]
    public object? ParentLoopId { get; set; }

    [ForeignKey(nameof(LoopEntity))]
    public object? LoopId { get; set; }

    [MaxLength(3)]
    [Required]
    public string Segment { get; set; }

    [Required]
    public string SegmentText { get; set; }

    internal static SegmentEntity ToSegmentEntity(object isaId, long pii, Segment segment) =>
      new(isaId, pii, segment.SegmentId, segment.SegmentString);
  }
}