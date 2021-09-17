using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Config
{
  public abstract class ConnectionManagerConfiguration
  {
    protected internal abstract IServiceCollection Apply(IServiceCollection sc);
  }
}