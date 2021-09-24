using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X12.Model;
using X12.Persistence.Meta;

namespace X12.Persistence.Model
{
  [Table("Interchange")]
  public class InterchangeEntity : Entity
  {
    [ForeignKey(nameof(FileEntity))]
    public object FileId { get; set; }

    [MaxLength(15)]
    public string Sender { get; init; }
    
    [MaxLength(15)]
    public string Receiver { get; init; }

    [MaxLength(50)]
    public string ControlNumber { get; init; }

    [MaxLength(15)]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Moment { get; init; }

    [ColumnMetadata(true)]
    [Required]
    public char SegmentTerminator { get; init; }

    [ColumnMetadata(true)]
    [Required]
    public char ElementSeparator { get; init; }

    [ColumnMetadata(true)]
    [Required]
    public char ComponentSeparator { get; init; }

    [ColumnMetadata(false)]
    [DefaultValue(0)]
    [Required]
    public bool HasError { get; set; }

    public static explicit operator InterchangeEntity(Interchange interchange) =>
      new() {
        Sender = interchange.InterchangeSenderId,
        Receiver = interchange.InterchangeReceiverId,
        ControlNumber = interchange.InterchangeControlNumber,
        Moment = interchange.InterchangeDate,
        SegmentTerminator = interchange.Delimiters.SegmentTerminator,
        ElementSeparator = interchange.Delimiters.ElementSeparator,
        ComponentSeparator = interchange.Delimiters.SubElementSeparator
      };
  }
}