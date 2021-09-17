using System.Collections.Generic;
using DbUp.Engine;

namespace X12.Persistence.Sql.Schema
{
  public class DefaultIdentityProviderScriptFactory : IIdentityProviderScriptFactory
  {
    public IList<SqlScript> CreateProviders() => new List<SqlScript>(0);
  }
}