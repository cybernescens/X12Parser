using System;
using System.Data.SqlClient;

namespace X12.Persistence.Sql.Mssql
{
  public class SqlConnectionProxy : IDisposable
  {
    private SqlTransaction _tx;

    public SqlConnectionProxy(SqlConnection connection)
    {
      Connection = connection;
      Connection.Open();
    }

    public SqlTransaction CurrentTransaction
    {
      get => _tx;
      set {
        if (_tx != null)
          throw new InvalidOperationException("Cannot assign transaction when one is already assigned.");

        _tx = value;
      }
    }

    public SqlConnection Connection { get; }

    public void Dispose()
    {
      Connection?.Dispose();
      _tx?.Dispose();
    }
  }
}