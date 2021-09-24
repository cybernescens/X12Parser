using System;

namespace X12.Persistence.Meta.Property
{
  public class IntegerPropertyType : PropertyDataType
  {
    public static IntegerPropertyType Tiny() => new(IntegerType.Tiny);
    public static IntegerPropertyType Small() => new(IntegerType.Small);
    public static IntegerPropertyType Regular() => new(IntegerType.Regular);
    public static IntegerPropertyType Big() => new(IntegerType.Big);

    public IntegerType Type { get; }

    public enum IntegerType
    {
      Tiny, 
      Small, 
      Regular, 
      Big
    }

    public IntegerPropertyType(IntegerType type) { Type = type; }

    public override string Render() =>
      Type switch {
        IntegerType.Tiny    => "tinyint",
        IntegerType.Small   => "smallint",
        IntegerType.Regular => "int",
        IntegerType.Big     => "bigint",
        _                   => throw new InvalidOperationException("Unknown Integer Sql Type")
      };
  }
}