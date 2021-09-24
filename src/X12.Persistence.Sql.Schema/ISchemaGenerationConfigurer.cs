using DbUp.Builder;

namespace X12.Persistence.Sql.Schema
{
  public interface ISchemaGenerationConfigurer
  {
    UpgradeEngineBuilder Database(SupportedDatabases db);
    UpgradeEngineBuilder Configure(UpgradeEngineBuilder ueb);
  }
}