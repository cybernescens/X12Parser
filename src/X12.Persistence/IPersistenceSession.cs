using System;
using System.Collections.Generic;
using X12.Model;

namespace X12.Persistence
{
  public interface IPersistenceSession : IDisposable
  {
    void Persist(IEnumerable<Interchange> interchanges, FileHash sourceFile);
  }

  public interface IHydrationSession : IDisposable
  {
    IEnumerable<Interchange> Hydrate(FileHash sourceFile);
  }

  internal class SessionPersistEventArgs : EventArgs
  {
    internal SessionPersistEventArgs(Guid sessionId) { SessionId = sessionId; }
    internal Guid SessionId { get; }
  }

  internal interface IIdentifiableSession : IDisposable
  {
    Guid Id { get; }
  }

  internal interface IIdentifiablePersistenceSession : IPersistenceSession, IIdentifiableSession
  {
    EventHandler<SessionPersistEventArgs>? OnPersistComplete { get; set; }
  }

  internal interface IIdentifiableHydrationSession : IHydrationSession, IIdentifiableSession
  {
    EventHandler<SessionPersistEventArgs>? OnHydrateComplete { get; set; }
  }
}