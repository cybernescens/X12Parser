using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X12.Model;

namespace X12.Persistence.Model
{
  [Table("Loop")]
  public class LoopEntity : Entity
  {
    public LoopEntity(
      object interchangeId,
      object transactionSetId,
      string transactionSetCode,
      string specificationLoop,
      string startingSegment)
    {
      InterchangeId = interchangeId;
      TransactionSetId = transactionSetId;
      TransactionSetCode = transactionSetCode;
      SpecificationLoop = specificationLoop;
      StartingSegment = startingSegment;
    }

    [ForeignKey(nameof(LoopEntity))]
    public object? ParentLoopId { get; set; }

    [ForeignKey(nameof(InterchangeEntity))]
    [Required]
    public object InterchangeId { get; set; }

    [ForeignKey(nameof(TransactionSetEntity))]
    [Required]
    public object TransactionSetId { get; set; }

    [MaxLength(3)]
    [Required]
    public string TransactionSetCode { get; set; }

    [MaxLength(8)]
    [Required]
    public string SpecificationLoop { get; set; }

    [MaxLength(12)]
    public string? Level { get; set; }

    [MaxLength(2)]
    public string? LevelCode { get; set; }

    [MaxLength(3)]
    [Required]
    public string StartingSegment { get; set; }

    [MaxLength(3)]
    public string? EntityIdentifierCode { get; set; }

    internal static LoopEntity ToLoopEntity(object isaId, object txId, string txCode, Loop loop) =>
      new(isaId, txId, txCode, loop.Specification.LoopId, loop.SegmentId)
        { EntityIdentifierCode = loop.EntityIdentifierCode };

    internal static LoopEntity ToLoopEntity(object isaId, object txId, string txCode, HierarchicalLoop loop) =>
      new(isaId, txId, txCode, loop.Specification.LoopId, loop.SegmentId)
        { Level = loop.Id, LevelCode = loop.LevelCode };
  }
}