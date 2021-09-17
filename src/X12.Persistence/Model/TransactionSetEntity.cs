using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X12.Model;

namespace X12.Persistence.Model
{
  [Table("TransactionSet")]
  public class TransactionSetEntity : Entity
  {
    [ForeignKey(nameof(InterchangeEntity))]
    [Required]
    public object InterchangeId { get; set; }

    [ForeignKey(nameof(FunctionalGroupEntity))]
    [Required]
    public object FunctionalGroupId { get; set; }

    [MaxLength(3)]
    public string IdentifierCode { get; set; }
    
    [MaxLength(9)]
    public string ControlNumber { get; set; }
    
    [MaxLength(35)]
    public string ImplementationConventionRef { get; set; }

    public static explicit operator TransactionSetEntity(Transaction tx) =>
      new () {
        IdentifierCode = tx.IdentifierCode,
        ControlNumber = tx.ControlNumber,
        ImplementationConventionRef = tx.ImplementationConventionReference
      };
  }
}