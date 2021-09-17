using System.Collections.Generic;

namespace X12.Persistence.Meta
{
  public abstract class ColumnMetaBuilder<T> : IColumnMetaBuilder
  {
    public ColumnMetaBuilder(IIdentityProvider identityProvider) { IdentitySqlType = identityProvider.ToSqlDataType(); }

    protected SqlDataType IdentitySqlType { get; }

    public IList<ColumnMetadata> Describe(object? o) => Describe((T)o);

    protected abstract IList<ColumnMetadata> Describe(T entity);
  }
}