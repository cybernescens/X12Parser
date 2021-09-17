using X12.Persistence.Config;

namespace X12.Testing.Persistence.Mssql
{
  [RequireDatabase]
  public interface IRequireDatabase
  {
    GenerateSegments GenerateSegments { get; set; }
    string DataSource { get; set; }
    string DatabaseName { get; set; }
    string Segments { get; set; }
    string CurrentConnectionString { get; set; }
    PersistenceConfiguration CurrentPersistenceConfiguration { get; set; }
  }
}