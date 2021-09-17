using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Config
{
  public abstract class BatchPersisterConfiguration
  {
    protected internal abstract IServiceCollection Apply(IServiceCollection sc);
  }
}