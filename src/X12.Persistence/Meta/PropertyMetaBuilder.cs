using System.Collections.Generic;
using X12.Persistence.Meta.Property;

namespace X12.Persistence.Meta
{
  public abstract class PropertyMetaBuilder<T> : IPropertyMetaBuilder
  {
    public PropertyMetaBuilder(IIdentityProvider identityProvider)
    {
      IdentityPropertyType = identityProvider.ToSqlDataType();
    }

    protected PropertyDataType IdentityPropertyType { get; }

    public IList<BatchPropertyMetadata> Describe(object? o) => Describe((T)o);

    protected abstract IList<BatchPropertyMetadata> Describe(T entity);
  }
}