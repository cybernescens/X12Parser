using X12.Config;

namespace X12.Persistence
{
  public interface IPersistenceConfiguration : IParserConfiguration
  {
    IPersistenceSessionFactory Build();
  }
}