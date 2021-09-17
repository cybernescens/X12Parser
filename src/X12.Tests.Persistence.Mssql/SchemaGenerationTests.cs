using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DbUp;
using NUnit.Framework;
using Serilog;
using X12.Persistence.Config;
using X12.Persistence.Sql.Mssql;
using X12.Persistence.Sql.Schema;

namespace X12.Tests.Persistence.Mssql
{
  [Category("integration")]
  public class SchemaGenerationTests 
  {
    private string _dsn;

    private static string GetDsn(DateTime date) =>
      new SqlConnectionStringBuilder {
          DataSource = "(localdb)\\.", 
          InitialCatalog = $"x12_{date:yyyyMMddHHmm}", 
          IntegratedSecurity = true
        }
        .ConnectionString;

    [SetUp]
    public void Setup()
    {
      _dsn = GetDsn(DateTime.Now);
      EnsureDatabase.For.SqlDatabase(_dsn);
    }

    [TearDown]
    public void Teardown()
    {
      DropDatabase.For.SqlDatabase(_dsn);
    }

    [TestCase(
      "ADX,BPR,DTM,ENT,N1,NM1,REF,RMR,TRN",
      TestName = "820")]
    [TestCase(
      "AMT,BGN,COB,DMG,DSB,DTP,HD,INS,LS,LUI,LX,N1,N3,N4,NM1,PER,REF",
      TestName = "834")]
    [TestCase(
      "AMT,BHT,CAS,CL1,CLM,CN1,CR1,CR2,CR3,CR4,CR5,CR6,CR7,CR8,CRC,CTP,DMG,DN1,DN2,DSB,DTP,FRM,HCP,HI,HL,HSD,IMM,K3,LIN,LQ,LX,MEA,MIA,MOA,N1,N3,N4,NM1,NTE,OI,PAT,PER,PRV,PS1,QTY,RAS,REF,SBR,SV1,SV2,SV3,SV4,SV7,SVD,TOO",
      TestName = "837")]
    public void GenerateSchema(string segmentsraw)
    {
      var segments = segmentsraw.Split(',');

      var generator = SchemaGenerationConfiguration.Schema
        .SchemaOptions(MssqlSchemaGenerationOptionsConfiguration.Default)
        .Logging(lb => lb.AddSerilog(Log.Logger))
        .ConnectionManager(MssqlConnectionConfiguration.Default.Using(_dsn))
        .IdentityProvider(LongHiLoSequenceIdentityProviderConfiguration.Default)
        .IndexedSegments(IndexedSegmentConfiguration.Default.Parse(segmentsraw))
        .ColumnMetaBuilder(ColumnMetaBuilderConfiguration.Default)
        .Options(PersistenceOptionsConfiguration.Default)
        .Prepare();

      var result = generator.Upgrade();

      if(!result.Successful)
        Assert.Fail(
          $"Error Script `{result.ErrorScript.Name}`:" +
          Environment.NewLine +
          Environment.NewLine +
          result.ErrorScript.Contents);

      foreach(var script in result.Scripts)
      {
        Log.Logger.Information($"Executed Script `{script.Name}`");
        Log.Logger.Information(Environment.NewLine + script.Contents);
      }
      
      var results = segments.Select(x => (Segment: x, Exists: TableExists(x), CanBeQueried: TableCanBeQueried(x))).ToList();
      var fails = results.Where(x => !x.Exists).ToList();
      var notqueried = results.Where(x => !x.CanBeQueried).ToList();

      Assert.IsFalse(
        fails.Any(), 
        $"The following expected tables were not found in the generated schema:" +
        $"{Environment.NewLine}{string.Join(", ", fails.Select(x => x.Segment))}");

      Assert.IsFalse(
        notqueried.Any(), 
        $"The following expected tables were not successfully queried:" +
        $"{Environment.NewLine}{string.Join(", ", notqueried.Select(x => x.Segment))}");
    }

    private bool TableExists(string segment)
    {
      try
      {
        using var conn = new SqlConnection(_dsn);
        using var cmd = conn.CreateCommand();
        conn.Open();

        cmd.CommandText = "select top (@top) TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_NAME = @table";
        cmd.Parameters.Add(new SqlParameter("@top", SqlDbType.Int)).Value = 1;
        cmd.Parameters.Add(new SqlParameter("@table", SqlDbType.VarChar, 128)).Value = segment;

        Log.Logger.Information($"{Environment.NewLine}{cmd.CommandText};{Environment.NewLine}  @top: `1` \\ @table: `{segment}`");

        var result = Convert.ToString(cmd.ExecuteScalar());
        Log.Logger.Information("PASS");
        return !string.IsNullOrEmpty(result);
      }
      catch
      {
        Log.Logger.Error("FAIL");
        return false;
      }
    }

    private bool TableCanBeQueried(string segment)
    {
      try
      {
        using var conn = new SqlConnection(_dsn);
        using var cmd = conn.CreateCommand();
        conn.Open();

        cmd.CommandText = $"select top 0 * from x12.{segment}";

        Log.Logger.Information($"{Environment.NewLine}{cmd.CommandText}");

        using var reader = cmd.ExecuteReader();
        while (reader.Read()) 
          ;

        Log.Logger.Information("PASS");
        return true;
      }
      catch
      {
        Log.Logger.Error("FAIL");
        return false;
      }
    }
  }
}