using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;
using X12.Persistence.Sql.Schema;
using X12.Persistence.Sql.Mssql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class IntHiLoSequenceIdentityProviderConfiguration : IdentityProviderConfiguration
  {
    public static IntHiLoSequenceIdentityProviderConfiguration Default => new();

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddScoped<IIdentityProvider, IntHiLoIdentityProvider>();
      sc.AddSingleton<IIdentityProviderScriptFactory, HiLoSequenceSqlScriptFactory>();
      return sc;
    }
  }
}