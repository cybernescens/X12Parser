using System;
using System.Diagnostics;
using X12.Persistence.Meta.Property;

namespace X12.Persistence.Meta
{
  [DebuggerDisplay("{Render()}")]
  public class BatchPropertyMetadata
  {
    public BatchPropertyMetadata(string name, bool nullable, PropertyDataType propertyDataType, Func<object, object> valueFunction)
    {
      Segment = new PropertyName(name);
      Nullable = new PropertyNullability(nullable);
      DataType = propertyDataType;
      ValueFunction = valueFunction;
    }

    public PropertyName Segment { get; }
    public PropertyDataType DataType { get; }
    public PropertyNullability Nullable { get; }
    public Func<object, object> ValueFunction { get; }

    /* really this should probably be moved out into its own
        component that can be swapped out since it is rather 
        implementation specific its only really used by 
        the schema generator and also SqlBulkCopy batch persister*/
    public string Render() => $"{Segment.Render()} {DataType.Render()} {Nullable.Render()}";
  }
}