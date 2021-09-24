using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using X12.Model;

namespace X12.Persistence.Model
{
  [Table("FunctionalGroup")]
  public class FunctionalGroupEntity : Entity
  {
    [ForeignKey(nameof(InterchangeEntity))]
    public object InterchangeId { get; set; }

    [MaxLength(2)]
    public string FunctionalCode { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime Moment { get; set; }

    public int ControlNumber { get; set; }

    [MaxLength(16)]
    public string Version { get; set; }

    public static explicit operator FunctionalGroupEntity(FunctionGroup fg) =>
      new () {
        FunctionalCode = fg.FunctionalIdentifierCode,
        Moment = fg.Date,
        ControlNumber = fg.ControlNumber,
        Version = fg.VersionIdentifierCode
      };
  }
}