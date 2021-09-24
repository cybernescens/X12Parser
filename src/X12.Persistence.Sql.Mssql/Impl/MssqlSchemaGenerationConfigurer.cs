using System;
using DbUp.Builder;
using X12.Persistence.Sql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlSchemaGenerationConfigurer : ISchemaGenerationConfigurer
  {
    private readonly string _connectionString;
    private readonly Func<UpgradeEngineBuilder, UpgradeEngineBuilder> _config;

    public MssqlSchemaGenerationConfigurer(string connectionString)
    {
      _connectionString = connectionString;
      _config = ueb => ueb;
    }

    public MssqlSchemaGenerationConfigurer(string connectionString, Func<UpgradeEngineBuilder, UpgradeEngineBuilder> config)
    {
      _connectionString = connectionString;
      _config = config;
    }

    public UpgradeEngineBuilder Database(SupportedDatabases db) => db.SqlDatabase(_connectionString);
    public UpgradeEngineBuilder Configure(UpgradeEngineBuilder ueb) => _config(ueb);
  }
}