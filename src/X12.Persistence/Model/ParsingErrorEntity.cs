using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace X12.Persistence.Model
{
  [Table("ParsingError")]
  public class ParsingErrorEntity : Entity
  {
    [ForeignKey(nameof(InterchangeEntity))]
    [Required]
    public object InterchangeId { get; set; }

    [Required]
    public long PositionInInterchange { get; set; }

    public string Message { get; set; }
  }
}