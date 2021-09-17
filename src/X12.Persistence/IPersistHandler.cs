using System;

namespace X12.Persistence
{
  public interface IPersistStartHandler
  {
    void OnStart(IPersistenceSession session, IDisposable connection);
  }

  public interface IPersistCompleteHandler
  {
    void OnComplete(IPersistenceSession session, IDisposable connection);
  }

  public interface IPersistRollbackHandler
  {
    void OnRollback(IPersistenceSession session, IDisposable connection, Exception encounteredException);
  }
}