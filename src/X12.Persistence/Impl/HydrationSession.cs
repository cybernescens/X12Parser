using System;
using System.Collections.Generic;
using X12.Model;

namespace X12.Persistence.Impl
{
  public class HydrationSession : IIdentifiableHydrationSession
  {
    public Guid Id { get; }
    EventHandler<SessionPersistEventArgs>? IIdentifiableHydrationSession.OnHydrateComplete { get; set; }

    public IEnumerable<Interchange> Hydrate(FileHash sourceFile)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}