namespace X12.Persistence
{
  public interface IPersistenceConfiguration
  {
    IPersistenceSessionFactory Build();
  }
}