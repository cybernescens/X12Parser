using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DbUp;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Serilog;
using X12.Persistence.Config;
using X12.Persistence.Sql.Mssql;
using X12.Persistence.Sql.Schema;

namespace X12.Testing.Persistence.Mssql
{
  public class RequireDatabaseAttribute : TestActionAttribute
  {
    private static readonly Regex SpecificationRegex = new(@"\._(?<tsc>\w+)\._(?<v>\d+)\.", RegexOptions.Compiled);

    private SqlConnectionStringBuilder _connectionString;

    public override void BeforeTest(ITest test)
    {
      if (test.Fixture is not IRequireDatabase fixture)
        throw new InvalidOperationException($"Expected Fixture to implement {nameof(IRequireDatabase)}");

      if (string.IsNullOrEmpty(fixture.DatabaseName))
        throw new InvalidOperationException($"Must specify {nameof(fixture.DatabaseName)}");
        
      SetDsn(fixture);

      fixture.CurrentPersistenceConfiguration = SchemaGenerationConfiguration.Schema
        .SchemaOptions(MssqlSchemaGenerationOptionsConfiguration.Default)
        .Logging(sb => sb.AddSerilog(Log.Logger))
        .ConnectionManager(MssqlConnectionConfiguration.Default.Using(_connectionString.ConnectionString))
        .IdentityProvider(LongHiLoSequenceIdentityProviderConfiguration.Default)
        .IndexedSegments(ToSegmentConfiguration(test, fixture))
        .ColumnMetaBuilder(PropertyMetaBuilderConfiguration.Default)
        .Options(PersistenceOptionsConfiguration.Default);
        
      var generator = fixture.CurrentPersistenceConfiguration.Prepare();

      var result = generator.Upgrade();
      if (!result.Successful)
        Assert.Fail(
          $"Error Generating Schema in: `{result.ErrorScript.Name}`:" +
          Environment.NewLine +
          Environment.NewLine +
          result.ErrorScript.Contents);
    }

    public override void AfterTest(ITest test)
    {
      DropDatabase.For.SqlDatabase(_connectionString.ConnectionString);
    }

    private void SetDsn(IRequireDatabase fixture)
    {
      _connectionString = new SqlConnectionStringBuilder {
        DataSource = fixture.DataSource ?? "(localdb)\\.",
        InitialCatalog = fixture.DatabaseName,
        IntegratedSecurity = true
      };

      EnsureDatabase.For.SqlDatabase(_connectionString.ConnectionString);
      fixture.CurrentConnectionString = _connectionString.ConnectionString;
    }

    private IndexedSegmentConfiguration IndexedSegmentConfigurationFromName(string name)
    {
      var match = SpecificationRegex.Match(name);
      if (!match.Success)
        return IndexedSegmentConfiguration.Default;

      var version = match.Groups["v"].Value;
      var tsc = match.Groups["tsc"].Value;
      return IndexedSegmentConfiguration.Default.TransactionSet(version, tsc, false);
    }

    private IndexedSegmentConfiguration ToSegmentConfiguration(ITest test, IRequireDatabase fixture) =>
      fixture.GenerateSegments switch {
        GenerateSegments.None     => IndexedSegmentConfiguration.Default,
        GenerateSegments.Property => IndexedSegmentConfiguration.Default.Parse(fixture.Segments),
        GenerateSegments.X820     => IndexedSegmentConfiguration.X820,
        GenerateSegments.X834     => IndexedSegmentConfiguration.X834,
        GenerateSegments.X837     => IndexedSegmentConfiguration.X837,
        GenerateSegments.FromName => IndexedSegmentConfigurationFromName(test.Name),
        _                         => throw new ArgumentOutOfRangeException(nameof(fixture.GenerateSegments), fixture.GenerateSegments, null)
      };

    public override ActionTargets Targets => ActionTargets.Test;
  }
}