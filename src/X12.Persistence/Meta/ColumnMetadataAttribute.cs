using System;
using System.Data;

namespace X12.Persistence.Meta
{
  public class ColumnMetadataAttribute : Attribute
  {
    public bool Nullable { get; }
    public SqlDbType? SqlDbType { get; }

    public ColumnMetadataAttribute(bool nullable)
    {
      Nullable = nullable;
    }

    public ColumnMetadataAttribute(bool nullable, SqlDbType sqlDbType)
    {
      Nullable = nullable;
      SqlDbType = sqlDbType;
    }
  }
}