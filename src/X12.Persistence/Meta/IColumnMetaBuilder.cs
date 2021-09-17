using System.Collections.Generic;

namespace X12.Persistence.Meta
{
  public interface IColumnMetaBuilder
  {
    IList<ColumnMetadata> Describe(object? o);
  }
}