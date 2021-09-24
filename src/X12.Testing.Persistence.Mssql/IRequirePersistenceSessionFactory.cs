using X12.Persistence;

namespace X12.Testing.Persistence.Mssql
{
  [RequireDatabase]
  [RequirePersistence]
  public interface IRequirePersistenceSessionFactory : IRequireDatabase
  {
    IPersistenceSessionFactory CurrentPersistenceSessionFactory { get; set; }
  }
}