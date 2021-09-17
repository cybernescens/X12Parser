using System;

namespace X12.Persistence
{
  public interface IConnectionManager : IDisposable
  {
    IDisposable CreateConnection();
  }

  public abstract class ConnectionManager : IConnectionManager
  {
    protected ConnectionManager(string connectionString)
    {
      ConnectionString = connectionString;
    }

    protected string ConnectionString { get; }

    public abstract void Dispose();
    public abstract IDisposable CreateConnection();
  }
}