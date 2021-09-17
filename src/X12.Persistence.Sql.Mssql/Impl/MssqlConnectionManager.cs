using System;
using System.Data;
using System.Data.SqlClient;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlConnectionManager : ConnectionManager
  {
    public MssqlConnectionManager(string connectionString) : base(connectionString) { }

    public override IDisposable CreateConnection() => new SqlConnectionProxy(new SqlConnection(ConnectionString));

    public override void Dispose() { }
  }
}