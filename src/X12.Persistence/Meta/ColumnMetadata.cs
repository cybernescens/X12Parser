using System;
using System.Diagnostics;

namespace X12.Persistence.Meta
{
  [DebuggerDisplay("{Render()}")]
  public class ColumnMetadata
  {
    public ColumnMetadata(string name, bool nullable, SqlDataType sqlDataType, Func<object, object> valueFunction)
    {
      Segment = new ColumnName(name);
      Nullable = new ColumnNullability(nullable);
      DataType = sqlDataType;
      ValueFunction = valueFunction;
    }

    public ColumnName Segment { get; set; }
    public SqlDataType DataType { get; set; }
    public ColumnNullability Nullable { get; set; }
    public Func<object, object> ValueFunction { get; }

    public string Render() => $"{Segment.Render()} {DataType.Render()} {Nullable.Render()}";
  }
}