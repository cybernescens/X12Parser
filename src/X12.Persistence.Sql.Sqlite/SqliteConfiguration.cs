using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Sqlite
{
  public class SqliteConfiguration : ConnectionManagerConfiguration
  {
    public static SqliteConfiguration Standard => new();

    public SqliteConnectionStringBuilder? ConnectionStringBuilder { get; set; }

    public SqliteConfiguration InMemory()
    {
      var csb = GetDefaultConnectionStringBuilder();
      csb.DataSource = ":memory:";
      ConnectionStringBuilder = csb;
      return this;
    }

    public SqliteConfiguration UsingFile(string fileName)
    {
      var csb = GetDefaultConnectionStringBuilder();
      csb.DataSource = fileName;
      ConnectionStringBuilder = csb;
      return this;
    }

    public SqliteConfiguration UsingFileWithPassword(string fileName, string password)
    {
      var csb = GetDefaultConnectionStringBuilder();
      csb.DataSource = fileName;
      csb.Add("Password", password);
      ConnectionStringBuilder = csb;
      return this;
    }

    private SqliteConnectionStringBuilder GetDefaultConnectionStringBuilder()
    {
      var csb = new SqliteConnectionStringBuilder();
      csb.Add("Version", 3);
      csb.Add("New", true);
      return csb;
    }

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      if (ConnectionStringBuilder == null)
        throw new ArgumentException(nameof(ConnectionStringBuilder));

      sc.AddSingleton<DbConnectionStringBuilder>(ConnectionStringBuilder);
      sc.AddScoped(
        sp => new SqliteConnectionManager(
          sp.GetRequiredService<DbConnectionStringBuilder>().ConnectionString));

      return sc;
    }
  }
}