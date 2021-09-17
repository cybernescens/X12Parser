using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;
using X12.Persistence.Sql.Schema;
using X12.Persistence.Sql.Mssql.Schema;

namespace X12.Persistence.Sql.Mssql
{
  public class LongHiLoSequenceIdentityProviderConfiguration : IdentityProviderConfiguration
  {
    public static LongHiLoSequenceIdentityProviderConfiguration Default => new();

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddScoped<IIdentityProvider, LongHiLoIdentityProvider>();
      sc.AddSingleton<IIdentityProviderScriptFactory, HiLoSequenceSqlScriptFactory>();
      return sc;
    }
  }
}