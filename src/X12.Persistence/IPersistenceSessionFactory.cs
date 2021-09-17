using X12.Parsing;

namespace X12.Persistence
{
  public interface IPersistenceSessionFactory
  {
    IFileHashService FileHashService { get; }
    IPersistenceSession OpenSession();
    IX12Parser CreateParser();
  }
}