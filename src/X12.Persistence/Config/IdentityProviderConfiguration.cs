using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.HiLo;

namespace X12.Persistence.Config
{
  public abstract class IdentityProviderConfiguration
  {
    protected internal abstract IServiceCollection Apply(IServiceCollection sc);
  }

  public class GuidIdentityProviderConfiguration : IdentityProviderConfiguration
  {
    public static GuidIdentityProviderConfiguration Default => new();

    protected internal override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddScoped<IIdentityProvider, SequentialGuidIdentityProvider>();
      return sc;
    }
  }
}