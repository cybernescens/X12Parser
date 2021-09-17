using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Sql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlSchemaGenerationOptionsConfiguration : SchemaGenerationOptionsConfiguration
  {
    public static MssqlSchemaGenerationOptionsConfiguration Default => new();

    public override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton<ISchemaGenerationConfigurer>(
        sp => new MssqlSchemaGenerationConfigurer(sp.GetRequiredService<DbConnectionStringBuilder>().ConnectionString));

      return sc;
    }
  }
}