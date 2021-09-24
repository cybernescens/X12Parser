using System;
using System.Data.Common;
using DbUp.Builder;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Sql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlSchemaGenerationOptionsConfiguration : SchemaGenerationOptionsConfiguration
  {
    public static MssqlSchemaGenerationOptionsConfiguration Default => new();

    public MssqlSchemaGenerationOptionsConfiguration Customize(Func<UpgradeEngineBuilder, UpgradeEngineBuilder> customize)
    {
      UpgradeEngineCustomizer = customize;
      return this;
    }

    public Func<UpgradeEngineBuilder, UpgradeEngineBuilder>? UpgradeEngineCustomizer { get; set; }

    public override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton<ISchemaGenerationConfigurer>(
        sp => new MssqlSchemaGenerationConfigurer(
          sp.GetRequiredService<DbConnectionStringBuilder>().ConnectionString,
          UpgradeEngineCustomizer ?? (ueb => ueb)));

      return sc;
    }
  }
}