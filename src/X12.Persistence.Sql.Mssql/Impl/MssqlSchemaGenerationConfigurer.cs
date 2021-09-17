using DbUp.Builder;
using X12.Persistence.Sql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlSchemaGenerationConfigurer : ISchemaGenerationConfigurer
  {
    private readonly string _connectionString;

    public MssqlSchemaGenerationConfigurer(string connectionString) { _connectionString = connectionString; }

    public UpgradeEngineBuilder Database(SupportedDatabases db) => db.SqlDatabase(_connectionString);
  }
}