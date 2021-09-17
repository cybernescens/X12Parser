using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;
using NUnit.Framework;
using X12.Persistence;
using X12.Persistence.Config;
using X12.Testing.Persistence.Mssql;
using X12.Testing.Samples;
using Format = ConsoleTables.Format;

namespace X12.Tests.Persistence.Mssql
{
  [TestFixture]
  public class Persist837Tests : IRequirePersistenceSessionFactory
  {
    [OneTimeSetUp]
    public void Setup()
    {
      DatabaseName = $"x12_{DateTime.Now:yyyyMMddHHmmss}";
      GenerateSegments = GenerateSegments.X837;
    }

    [Test]
    public void LoadsHealthInsuranceClaim()
    {
      string filename;

      using (var session = CurrentPersistenceSessionFactory.OpenSession())
      {
        var parser = CurrentPersistenceSessionFactory.CreateParser();
        var (fn, stream) = this.LoadEmbeddedFileStream(
          SampleCategory.INS,
          SampleReferenceNumber._837P,
          "01.HealthInsurance.x12");

        filename = fn;
        var hash = CurrentPersistenceSessionFactory.FileHashService.Compute(stream, filename).GetAwaiter().GetResult();
        var results = parser.Parse(stream);
        session.Persist(results, filename, hash.Hash);
      }

      var queries = new[] { "File", "Loop", "Segment", "SBR", "PAT", "CLM", "ClaimHeader" };
      foreach (var query in queries)
      {
        using var conn = new SqlConnection(CurrentConnectionString);
        using var cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = this.GetQuery(query);
        cmd.Parameters.Add(new SqlParameter("@filename", SqlDbType.VarChar, 255)).Value = filename;

        using var reader = cmd.ExecuteReader();
        reader.Print();
      }
    }

    public GenerateSegments GenerateSegments { get; set; }
    public string DataSource { get; set; }
    public string DatabaseName { get; set; }
    public string Segments { get; set; }
    public string CurrentConnectionString { get; set; }
    public PersistenceConfiguration CurrentPersistenceConfiguration { get; set; }
    public IPersistenceSessionFactory CurrentPersistenceSessionFactory { get; set; }
  }

  public static class DataReaderExtensions
  {
    public static void Print(this IDataReader reader)
    {
      if (reader.IsClosed)
        return;

      var header = new string[reader.FieldCount];
      for (var c = 0; c < reader.FieldCount; c++)
        header[c] = reader.GetName(c);

      var ct = new ConsoleTable(header);

      while (reader.Read())
      {
        var row = new object[reader.FieldCount];
        for (var i = 0; i < reader.FieldCount; i++)
          row[i] = reader[i];

        ct.AddRow(row);
      }

      ct.Write(Format.Minimal);
    }
  }
}