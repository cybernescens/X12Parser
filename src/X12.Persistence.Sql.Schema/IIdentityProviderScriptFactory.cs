using System.Collections.Generic;
using DbUp.Engine;

namespace X12.Persistence.Sql.Schema
{
  public interface IIdentityProviderScriptFactory
  {
    IList<SqlScript> CreateProviders();
  }
}