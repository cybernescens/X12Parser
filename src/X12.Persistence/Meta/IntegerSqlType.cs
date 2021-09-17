using System;

namespace X12.Persistence.Meta
{
  public class IntegerSqlType : SqlDataType
  {
    public static IntegerSqlType Tiny() => new IntegerSqlType(IntegerType.Tiny);
    public static IntegerSqlType Small() => new IntegerSqlType(IntegerType.Small);
    public static IntegerSqlType Regular() => new IntegerSqlType(IntegerType.Regular);
    public static IntegerSqlType Big() => new IntegerSqlType(IntegerType.Big);

    public IntegerType Type { get; }

    public enum IntegerType
    {
      Tiny, 
      Small, 
      Regular, 
      Big
    }

    public IntegerSqlType(IntegerType type) { Type = type; }

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