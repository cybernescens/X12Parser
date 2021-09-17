namespace X12.Persistence
{
  public class PersistenceOptions
  {
    public string Schema { get; set; }
    public int BatchSize { get; set; }
    public int Retries { get; set; }
  }
}