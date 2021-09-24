using X12.Parsing;

namespace X12.Persistence
{
  public interface IPersistenceSessionFactory
  {
    IFileHashService FileHashService { get; }
    IPersistenceSession OpenPersistence();
    IHydrationSession OpenHydration();
    IX12Parser CreateParser();
  }
}