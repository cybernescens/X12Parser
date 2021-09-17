using System;

namespace X12.Persistence.Config
{
  public static class PersistenceConfigurationExtensions
  {
    public static IPersistenceConfiguration ConnectionManager(
      this PersistenceConfiguration config,
      ConnectionManagerConfiguration mgr,
      Action<ConnectionManagerConfiguration> configure = null)
    {
      configure ??= _ => { };
      configure(mgr);
      config.ConnectionManagerConfiguration = mgr;
      return config;
    }
  }
}