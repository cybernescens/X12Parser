using System;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlPersistenceSessionConfiguration : PersistenceSessionConfiguration
  {
    public new static MssqlPersistenceSessionConfiguration Default = new();
    public override Type? StartHandler => typeof(SqlTransactionPersistHandler);
    public override Type? CompleteHandler => typeof(SqlTransactionPersistHandler);
    public override Type? RollbackHandler => typeof(SqlTransactionPersistHandler);

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddScoped<SqlTransactionPersistHandler, SqlTransactionPersistHandler>();
      sc.AddScoped<IPersistStartHandler>(sp => sp.GetRequiredService<SqlTransactionPersistHandler>());
      sc.AddScoped<IPersistCompleteHandler>(sp => sp.GetRequiredService<SqlTransactionPersistHandler>());
      sc.AddScoped<IPersistRollbackHandler>(sp => sp.GetRequiredService<SqlTransactionPersistHandler>());
      return sc;
    }
  }
}