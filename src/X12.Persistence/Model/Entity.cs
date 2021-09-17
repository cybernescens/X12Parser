using System.ComponentModel.DataAnnotations;

namespace X12.Persistence.Model
{
  public abstract class Entity
  {
    [Key]
    public object Id { get; set; }
  }
}