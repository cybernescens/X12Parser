using System;
using System.Data.SqlClient;
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
    private SqlConnectionStringBuilder _connectionString;

    public override void BeforeTest(ITest test)
    {
      if (test.Fixture is not IRequireDatabase fixture)
        throw new InvalidOperationException($"Expected Fixture to implement {nameof(IRequireDatabase)}");

      if (string.IsNullOrEmpty(fixture.DatabaseName))
        throw new InvalidOperationException($"Must specify {nameof(fixture.DatabaseName)}");
        
      var now = DateTime.Now;

      SetDsn(fixture);

      fixture.CurrentPersistenceConfiguration = SchemaGenerationConfiguration.Schema
        .SchemaOptions(MssqlSchemaGenerationOptionsConfiguration.Default)
        .Logging(sb => sb.AddSerilog(Log.Logger))
        .ConnectionManager(MssqlConnectionConfiguration.Default.Using(_connectionString.ConnectionString))
        .IdentityProvider(LongHiLoSequenceIdentityProviderConfiguration.Default)
        .IndexedSegments(ToSegmentConfiguration(fixture.GenerateSegments, fixture.Segments))
        .ColumnMetaBuilder(ColumnMetaBuilderConfiguration.Default)
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

    public IndexedSegmentConfiguration ToSegmentConfiguration(GenerateSegments gs, string segmentsraw = null) =>
      gs switch {
        GenerateSegments.None     => IndexedSegmentConfiguration.Default,
        GenerateSegments.Property => IndexedSegmentConfiguration.Default.Parse(segmentsraw!),
        GenerateSegments.X820     => IndexedSegmentConfiguration.X820,
        GenerateSegments.X834     => IndexedSegmentConfiguration.X834,
        GenerateSegments.X837     => IndexedSegmentConfiguration.X837,
        _                         => throw new ArgumentOutOfRangeException(nameof(gs), gs, null)
      };

    public override ActionTargets Targets => ActionTargets.Test;
  }
}