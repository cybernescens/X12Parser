using System;
using System.Collections.Generic;
using X12.Model;

namespace X12.Persistence
{
  public interface IPersistenceSession : IDisposable
  {
    void Persist(IEnumerable<Interchange> interchanges, string filepath, string filehash, string? username = null);
  }

  internal class SessionPersistEventArgs : EventArgs
  {
    internal SessionPersistEventArgs(Guid sessionId) { SessionId = sessionId; }
    internal Guid SessionId { get; }
  }

  internal interface IIdentifiablePersistenceSession : IPersistenceSession
  {
    Guid Id { get; }
    EventHandler<SessionPersistEventArgs>? OnPersistComplete { get; set; }
  }
}