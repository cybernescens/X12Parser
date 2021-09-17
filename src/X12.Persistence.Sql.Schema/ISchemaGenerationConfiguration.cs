using DbUp.Engine;

namespace X12.Persistence.Sql.Schema
{
  public interface ISchemaGenerationConfiguration : IPersistenceConfiguration
  {
    ISchemaGenerator Prepare();
  }
}