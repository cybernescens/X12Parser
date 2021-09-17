using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Mssql
{
  public class MssqlConnectionConfiguration : ConnectionManagerConfiguration
  {
    public static MssqlConnectionConfiguration Default => new();
    
    public SqlConnectionStringBuilder? ConnectionStringBuilder { get; set; }

    public MssqlConnectionConfiguration Using(string connectionString)
    {
      ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
      return this;
    }

    public MssqlConnectionConfiguration Using(string server, string db)
    {
      var csb = new SqlConnectionStringBuilder();
      csb.DataSource = server;
      csb.InitialCatalog = db;
      csb.IntegratedSecurity = true;
      ConnectionStringBuilder = csb;
      return this;
    }

    public MssqlConnectionConfiguration Using(string server, string db, string username, string password)
    {
      var csb = new SqlConnectionStringBuilder();
      csb.DataSource = server;
      csb.InitialCatalog = db;
      csb.UserID = username;
      csb.Password = password;
      ConnectionStringBuilder = csb;
      return this;
    }

    public MssqlConnectionConfiguration Express(string db)
    {
      var csb = new SqlConnectionStringBuilder();
      csb.DataSource = "(localdb)\\.";
      csb.InitialCatalog = db;
      csb.IntegratedSecurity = true;
      ConnectionStringBuilder = csb;
      return this;
    }

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      if (ConnectionStringBuilder == null)
        throw new ArgumentException(nameof(ConnectionStringBuilder));

      sc.AddSingleton<DbConnectionStringBuilder>(ConnectionStringBuilder);
      sc.AddSingleton<IConnectionManager>(
        sp => new MssqlConnectionManager(sp.GetRequiredService<DbConnectionStringBuilder>().ConnectionString));

      return sc;
    }
  }
}