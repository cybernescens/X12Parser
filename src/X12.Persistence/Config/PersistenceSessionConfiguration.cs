using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Config
{
  public class PersistenceSessionConfiguration
  {
    public static PersistenceSessionConfiguration Default => new();

    public virtual Type? StartHandler { get; set; }
    public virtual Type? CompleteHandler { get; set; }
    public virtual Type? RollbackHandler { get; set; }
    
    protected internal virtual IServiceCollection Apply(IServiceCollection sc)
    {
      new List<(string Name, Type? Handler, Type Interface)>() {
        (nameof(StartHandler), StartHandler, typeof(IPersistStartHandler)),
        (nameof(CompleteHandler), CompleteHandler, typeof(IPersistCompleteHandler)),
        (nameof(RollbackHandler), RollbackHandler, typeof(IPersistRollbackHandler))
      }.ForEach(
        x => {
          var (name, handler, @interface) = x;
          if (handler == null)
            throw new X12PersistenceConfigurationException(
              $"{name} must be configured.");
              
          sc.AddScoped(@interface, handler);
        });
      
      return sc;
    }
  }
}