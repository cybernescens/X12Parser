using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.File;

namespace X12.Persistence.Config
{
  public class PersistenceOptionsConfiguration
  {
    public static PersistenceOptionsConfiguration Default => new();

    public string Schema { get; set; } = "X12";
    public int BatchSize { get; set; } = 10 * 1000;
    public int Retries { get; set; } = 3;

    internal IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton(
        _ => new PersistenceOptions {
          Schema = Schema,
          BatchSize = BatchSize,
          Retries = Retries,
        });

      return sc;
    }
  }
}