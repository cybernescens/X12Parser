using System;
using System.Data.SqlClient;
using Microsoft.Identity.Client;

namespace X12.Persistence.Sql.Mssql
{
  public class AzureConnectionManager : ConnectionManager
  {
    private const int MaxRetries = 3;
    private readonly IConfidentialClientApplication _confidentialClient;
    private readonly bool _retry;

    public AzureConnectionManager(
      string connectionString,
      bool retry,
      IConfidentialClientApplication confidentialClient) : base(connectionString)
    {
      _retry = retry;
      _confidentialClient = confidentialClient;
    }

    public override IDisposable CreateConnection()
    {
      var ar = _confidentialClient
        .AcquireTokenForClient(new[] { "https://database.windows.net//.default" })
        .ExecuteAsync()
        .GetAwaiter()
        .GetResult();

      var connection = new SqlConnection();
      connection.ConnectionString = ConnectionString;
      connection.AccessToken = ar.AccessToken;

      for (var retry = 1; retry <= MaxRetries; retry++)
      {
        try
        {
          connection.Open();
          return new SqlConnectionProxy(connection);
        }
        catch
        {
          if (!_retry || retry >= MaxRetries)
            throw;
        }
      }

      throw new InvalidOperationException("Unable to open a connection.");
    }

    public override void Dispose() { }
  }
}