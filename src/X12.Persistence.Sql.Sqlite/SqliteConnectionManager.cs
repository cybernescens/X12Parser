using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace X12.Persistence.Sql.Sqlite
{
  public class SqliteConnectionManager : ConnectionManager
  {
    private bool _closed;
    private SqliteConnection _connection;

    public SqliteConnectionManager(string connectionString) : base(connectionString) { }

    public override IDisposable CreateConnection()
    {
      if (_connection is { State: ConnectionState.Open })
        return _connection;

      _connection = new SqliteConnection(ConnectionString);
      _connection.Open();
      return _connection;
    }
    
    public override void Dispose()
    {
      if (_closed ||
        _connection.State == ConnectionState.Broken || 
        _connection.State == ConnectionState.Closed)
        return;

      _connection.Close();
      _connection?.Dispose();
    }
  }
}