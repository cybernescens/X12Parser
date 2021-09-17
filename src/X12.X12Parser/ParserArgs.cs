using System;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PowerArgs;
using X12.Parsing;
using X12.Persistence;
using X12.Persistence.Config;
using X12.Persistence.Sql.Mssql;
using X12.X12Parser.Acknowledge;
using X12.X12Parser.Import;
using X12.X12Parser.Parse;
using X12.X12Parser.Schema;
using X12.X12Parser.Transform;
using X12.X12Parser.Unbundle;

namespace X12.X12Parser
{
  internal class ParserArgs
  {
    [ArgRequired]
    [ArgPosition(0)]
    [ArgDescription("The parser command to perform.")]
    public string Action { get; set; }

    [ArgShortcut("?")]
    [HelpHook]
    public string Help { get; set; }
    
    [ArgIgnore]
    public Type Command { get; private set; }

    [ArgIgnore]
    public object Args { get; private set; }

    [ArgIgnore]
    public string ConfigurationSectionName { get; private set; }

    [ArgIgnore]
    public object Configuration { get; private set; }

    [ArgIgnore]
    public Action<IServiceCollection> ConfigureServices { get; private set; } = 
      sc => {
        sc.AddSingleton(
          sp => ParserSettings.Default.WithParserWarning(
            (__, e) => {
              var lf = sp.GetRequiredService<ILoggerFactory>();
              var log = lf.CreateLogger<ILogger<ParserSettings>>();
              log.LogWarning(
                $"Error parsing interchange {e.InterchangeControlNumber} " +
                $"at position {e.SegmentPositionInInterchange}: {e.Message}");
            }));

        sc.AddSingleton<ISpecificationFinder>();
      };

    [ArgActionMethod]
    public void ParseFile(ParseFileArgs args)
    {
      Command = typeof(FileParserCommand);
      Args = args;
      ConfigurationSectionName = "FileParserSettings";
      Configuration = new FileParserConfiguration();
    }

    [ArgActionMethod]
    public void UnbundleX12(UnbundleArgs args)
    {
      args.Configure();
      Command = typeof(UnbundleParserCommand);
      Args = args;
      ConfigurationSectionName = "UnbundleSettings";
      Configuration = new UnbundleConfiguration();
    }

    [ArgActionMethod]
    public void Xml2X12(XmlToX12Args args)
    {
      Command = typeof(XmlToX12ParserCommand);
      Args = args;
      ConfigurationSectionName = "XmlToX12Settings";
      Configuration = new XmlToX12Configuration();
    }

    [ArgActionMethod]
    public void ImportX12(ImportX12Args args)
    {
      args.Configure();
      Command = typeof(ImportX12ParserCommand);
      Args = args;
      ConfigurationSectionName = "ImportX12Settings";
      Configuration = new ImportX12Configuration();
      ConfigureServices = sc => {
        sc.AddSingleton(
          sp => ParserSettings.Default.WithParserWarning(
            (__, e) => {
              var lf = sp.GetRequiredService<ILoggerFactory>();
              var log = lf.CreateLogger<ILogger<ParserSettings>>();
              log.LogWarning(
                $"Error parsing interchange {e.InterchangeControlNumber} " +
                $"at position {e.SegmentPositionInInterchange}: {e.Message}");
            }));

        sc.AddSingleton<ISpecificationFinder>();
        sc.AddSingleton(
          sp => {
            var config = sp.GetRequiredService<ImportX12Configuration>();
            var cm = args switch {
              { Azure: true } =>
                (ConnectionManagerConfiguration)AzureConnectionConfiguration
                  .Default
                  .WithApplicationId(config.ApplicationId)
                  .WithTenantId(config.TenantId)
                  .WithCertificate(config.Certificate),
              { IntegratedSecurity: true } =>
                MssqlConnectionConfiguration
                  .Default
                  .Using(args.Server, args.InitialCatalog),
              { IntegratedSecurity: false } =>
                MssqlConnectionConfiguration
                  .Default
                  .Using(args.Server, args.InitialCatalog, args.Username, args.Password),
              _ => throw new InvalidOperationException("Unable to determine SQL configuration")
            };

            var identity = config.GetIdentityInstance();
            IdentityProviderConfiguration ip = identity switch {
              long => LongHiLoSequenceIdentityProviderConfiguration.Default,
              int => IntHiLoSequenceIdentityProviderConfiguration.Default,
              Guid => GuidIdentityProviderConfiguration.Default,
              _ => throw new InvalidOperationException($"Unknown identity provider for type `{identity.GetType().FullName}`")
            };

            return PersistenceConfiguration
              .Default
              .Options(
                PersistenceOptionsConfiguration.Default,
                x => {
                  x.Schema = config.SchemaName;
                  x.BatchSize = config.SegmentBatchSize;
                })
              .ConnectionManager(cm)
              .IdentityProvider(ip)
              .BatchPersister(BulkCopyBatchPersisterConfiguration.Default)
              .ColumnMetaBuilder(ColumnMetaBuilderConfiguration.Default)
              .IndexedSegments(
                IndexedSegmentConfiguration
                  .Default
                  .Add(config.IndexedSegments))
              .Build();
          });
      };
    }

    [ArgActionMethod]
    public void AcknowledgeX12(AcknowledgeX12Args args)
    {
      Command = typeof(AcknowledgeX12ParserCommand);
      Args = args;
      ConfigurationSectionName = "AcknowledgeX12Settings";
      Configuration = new AcknowledgeX12Configuration();
    }

    [ArgActionMethod]
    public void GenerateSchema(GenerateSchemaArgs args)
    {
      Command = typeof(GenerateSchemaParserCommand);
      Args = args;
      ConfigurationSectionName = "GenerateSchemaSettings";
      Configuration = new GenerateSchemaConfiguration();
      ConfigureServices = sc => {
        sc.AddSingleton(
          sp => ParserSettings.Default.WithParserWarning(
            (__, e) => {
              var lf = sp.GetRequiredService<ILoggerFactory>();
              var log = lf.CreateLogger<ILogger<ParserSettings>>();
              log.LogWarning(
                $"Error parsing interchange {e.InterchangeControlNumber} " +
                $"at position {e.SegmentPositionInInterchange}: {e.Message}");
            }));

        sc.AddSingleton<ISpecificationFinder>();
        sc.AddSingleton(
          sp => {
            var config = sp.GetRequiredService<ImportX12Configuration>();
            var cm = args switch {
              { Azure: true } =>
                (ConnectionManagerConfiguration)AzureConnectionConfiguration
                  .Default
                  .WithApplicationId(config.ApplicationId)
                  .WithTenantId(config.TenantId)
                  .WithCertificate(config.Certificate),
              { IntegratedSecurity: true } =>
                MssqlConnectionConfiguration
                  .Default
                  .Using(args.Server, args.InitialCatalog),
              { IntegratedSecurity: false } =>
                MssqlConnectionConfiguration
                  .Default
                  .Using(args.Server, args.InitialCatalog, args.Username, args.Password),
              _ => throw new InvalidOperationException("Unable to determine SQL configuration")
            };

            var identity = config.GetIdentityInstance();
            IdentityProviderConfiguration ip = identity switch {
              long => LongHiLoSequenceIdentityProviderConfiguration.Default,
              int => IntHiLoSequenceIdentityProviderConfiguration.Default,
              Guid => GuidIdentityProviderConfiguration.Default,
              _ => throw new InvalidOperationException($"Unknown identity provider for type `{identity.GetType().FullName}`")
            };

            return PersistenceConfiguration
              .Default
              .Options(PersistenceOptionsConfiguration.Default,
                x => {
                  x.Schema = config.SchemaName;
                  x.BatchSize = config.SegmentBatchSize;
                })
              .ConnectionManager(cm)
              .IdentityProvider(ip)
              .BatchPersister(BulkCopyBatchPersisterConfiguration.Default)
              .ColumnMetaBuilder(ColumnMetaBuilderConfiguration.Default)
              .IndexedSegments(
                IndexedSegmentConfiguration
                  .Default
                  .Add(config.IndexedSegments))
              .Build();
          });
      };
    }
  }
}