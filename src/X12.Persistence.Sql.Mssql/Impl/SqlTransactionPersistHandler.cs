using System;
using System.Data;

namespace X12.Persistence.Sql.Mssql
{
  public class SqlTransactionPersistHandler : IPersistStartHandler, IPersistRollbackHandler, IPersistCompleteHandler
  {
    private SqlConnectionProxy _proxy;

    public void OnStart(IPersistenceSession _, IDisposable connection)
    {
      var proxy = (SqlConnectionProxy)connection;
      proxy.CurrentTransaction = proxy.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
      _proxy = proxy;
    }

    public void OnComplete(IPersistenceSession _, IDisposable __)
    {
      _proxy.CurrentTransaction.Commit();
      _proxy = null;
    }

    public void OnRollback(IPersistenceSession _, IDisposable __, Exception ___)
    {
      _proxy.CurrentTransaction.Rollback();
      _proxy = null;
    }
  }
}