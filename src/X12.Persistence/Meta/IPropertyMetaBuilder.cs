using System.Collections.Generic;

namespace X12.Persistence.Meta
{
  public interface IPropertyMetaBuilder
  {
    IList<BatchPropertyMetadata> Describe(object? o);
  }
}