using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Mssql
{
  public class BulkCopyBatchPersisterConfiguration : BatchPersisterConfiguration
  {
    public static BulkCopyBatchPersisterConfiguration Default => new();

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddTransient<IBatchPersister, SqlServerBulkCopyBatchPersister>();
      return sc;
    }
  }
}