using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Mssql
{
  public class AzureConnectionConfiguration : ConnectionManagerConfiguration
  {
    public static AzureConnectionConfiguration Default => new();

    public AzureAuthorization? Authorization { get; set; }
    public string? ApplicationId { get; set; }
    public string? TenantId { get; set; }
    public bool Retries { get; set; }
    public SqlConnectionStringBuilder? ConnectionStringBuilder { get; set; }

    public AzureConnectionConfiguration Using(string server, string db)
    {
      var csb = new SqlConnectionStringBuilder();
      csb.DataSource = server;
      csb.InitialCatalog = db;
      csb.IntegratedSecurity = true;
      ConnectionStringBuilder = csb;
      return this;
    }

    public AzureConnectionConfiguration WithApplicationId(string id)
    {
      ApplicationId = id;
      return this;
    }

    public AzureConnectionConfiguration WithTenantId(string id)
    {
      TenantId = id;
      return this;
    }

    public AzureConnectionConfiguration WithCertificate(string certificate)
    {
      if (Authorization != null)
        throw new X12PersistenceConfigurationException(
          $"Authorization configuration has been set an instance of `{Authorization.GetType().FullName}`.");

      Authorization = new CertificateAzureAuthorization(certificate);
      return this;
    }
    
    public AzureConnectionConfiguration WithRetries(bool retry)
    {
      Retries = retry;
      return this;
    }

    public AzureConnectionConfiguration WithAuthorization(AzureAuthorization auth)
    {
      if (Authorization != null)
        throw new X12PersistenceConfigurationException(
          $"Authorization configuration has been set an instance of `{Authorization.GetType().FullName}`.");

      Authorization = auth;
      return this;
    }

    protected override IServiceCollection Apply(IServiceCollection sc)
    {
      if (string.IsNullOrEmpty(ApplicationId))
        throw new ArgumentException("Missing required configuration option.", nameof(ApplicationId));

      if (string.IsNullOrEmpty(TenantId))
        throw new ArgumentException("Missing required configuration option.", nameof(TenantId));

      if (ConnectionStringBuilder == null)
        throw new ArgumentException(nameof(ConnectionStringBuilder));

      if (Authorization == null)
        throw new ArgumentException(nameof(Authorization));

      sc.AddSingleton<DbConnectionStringBuilder>(ConnectionStringBuilder);
      sc.AddSingleton(
        Authorization
          .Apply(
            ConfidentialClientApplicationBuilder
              .Create(ApplicationId)
              .WithAuthority(AzureCloudInstance.AzurePublic, TenantId))
          .Build());

      sc.AddScoped(
        sp => {
          var csb = sp.GetRequiredService<DbConnectionStringBuilder>();
          return new AzureConnectionManager(
            csb.ConnectionString,
            Retries,
            sp.GetRequiredService<IConfidentialClientApplication>());
        });
        
      return sc;
    }
  }
}