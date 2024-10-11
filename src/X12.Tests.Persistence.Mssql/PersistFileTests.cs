using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using X12.Model;
using X12.Parsing;
using X12.Persistence;
using X12.Persistence.Config;
using X12.Persistence.Impl;
using X12.Testing.Persistence.Mssql;
using X12.Testing.Samples;

namespace X12.Tests.Persistence.Mssql
{
  [TestFixture]
  public class PersistFileTests : IRequirePersistenceSessionFactory, IRequireSampleData
  {
    private static readonly Regex BeginningWhitespaceRegex = new(@"^\s*", RegexOptions.Compiled | RegexOptions.Multiline);
    private static readonly Regex NewLineRegex = new(@"(?:\r\n|\r|\n)", RegexOptions.Compiled);

    [OneTimeSetUp]
    public void Setup()
    {
      DatabaseName = $"x12_{DateTime.Now:yyyyMMddHHmmss}";
      GenerateSegments = GenerateSegments.FromName;
    }

    public static IEnumerable<TestCaseData> SampleFilesPqr() =>
      Samples.SampleFiles(x => $"Parse_Query_Reserialize-{x.Replace("X12.Testing.Samples.", string.Empty)}");

    public static IEnumerable<TestCaseData> SampleFilesPqis() =>
      Samples.SampleFiles(x => $"Parse_Query_IndexedSegments-{x.Replace("X12.Testing.Samples.", string.Empty)}");

    [Test]
    [TestCaseSource(nameof(SampleFilesPqr))]
    public void Parse_Query_Reserialize((string File, Stream Stream) file)
    {
      FileHash hash;
      string x12;

      using var sr = new StreamReader(file.Stream, leaveOpen: true);
      var originalX12 = 
        BeginningWhitespaceRegex.Replace(
          NewLineRegex.Replace(sr.ReadToEnd(), Environment.NewLine), string.Empty).TrimEnd();

      using (var session = CurrentPersistenceSessionFactory.OpenPersistence())
      {
        var parser = CurrentPersistenceSessionFactory.CreateParser();
      
        hash = CurrentPersistenceSessionFactory.FileHashService.Compute(file.Stream, file.File).GetAwaiter().GetResult();
        var results = parser.Parse(file.Stream);
        session.Persist(results, hash);
      }

      using (var conn = new SqlConnection(CurrentConnectionString))
      using (var cmd = conn.CreateCommand())
      {
        conn.Open();
        cmd.CommandText = this.GetQuery("FileSegments");
        cmd.Parameters.Add(new SqlParameter("@hash", SqlDbType.VarChar, 96)).Value = hash.Hash;

        using (var reader = cmd.ExecuteReader())
        {
          var sb = new StringBuilder();

          while (reader.Read())
          {
            sb.AppendLine();
            sb.Append(reader.Get("SegmentText"));
            var terminator = reader.Get<char>("SegmentTerminator");
            if (terminator != '\r' && terminator != '\n')
              sb.Append(terminator);
          }

          x12 = sb.ToString().Trim();
        }

        using (var printer = cmd.ExecuteReader())
          printer.Print();
      }

      Assert.AreEqual(originalX12, x12, $"Generated X12:{Environment.NewLine}{x12}");
    }

    [Test]
    [TestCaseSource(nameof(SampleFilesPqis))]
    public void Parse_Query_IndexedSegments((string File, Stream Stream) file)
    {
      FileHash hash;

      using (var session = CurrentPersistenceSessionFactory.OpenPersistence())
      {
        var parser = CurrentPersistenceSessionFactory.CreateParser();
      
        hash = CurrentPersistenceSessionFactory.FileHashService.Compute(file.Stream, file.File).GetAwaiter().GetResult();
        var results = parser.Parse(file.Stream);
        session.Persist(results, hash);
      }

      using (var conn = new SqlConnection(CurrentConnectionString))
      {
        var sf = (PersistenceSessionFactory)CurrentPersistenceSessionFactory;
        var validIndexes = new Dictionary<int, HashSet<string>>();
        conn.Open();

        using (var cmd = conn.CreateCommand())
        {
          cmd.Parameters.Add(new SqlParameter("@hash", SqlDbType.VarChar, 96)).Value = hash.Hash;
          cmd.CommandText =
            "select s.InterchangeId, s.Segment " +
            "from X12.Segment s " +
            $"inner join X12.Interchange isa on isa.Id = s.InterchangeId " +
            $"inner join X12.[File] f on f.Id = isa.FileId " +
            "where f.Filehash = @hash " +
            "group by s.InterchangeId, s.Segment";

          using var reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            var isaId = reader.Get<int>("InterchangeId");
            if (!validIndexes.ContainsKey(isaId))
              validIndexes.Add(isaId, new HashSet<string>());
            
            validIndexes[isaId].Add(reader.Get("Segment"));
          }
        }

        var totalElementsChecked = 0;

        foreach (var (isaId, va) in validIndexes)
        {
          var assertableIndexes = sf.IndexedSegmentSegmentTypeMap.Values
            .Join(va, x => x.Id, y => y, (x, y) => y)
            .ToList();

          if (!assertableIndexes.Any())
            Assert.Pass();

          foreach (var index in assertableIndexes)
          {
            using (var cmd = conn.CreateCommand())
            {
              cmd.CommandText =
                $"select top 1 isa.* " +
                $"from X12.Interchange isa " +
                $"inner join X12.[File] f on f.Id = isa.FileId " +
                $"where f.Filehash = @hash and isa.Id = @isaId " +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"select s.* from X12.Segment s " +
                $"inner join X12.Interchange isa on isa.Id = s.InterchangeId " +
                $"inner join X12.[File] f on f.Id = isa.FileId " +
                $"where f.Filehash = @hash and s.Segment = @segment and isa.Id = @isaId " +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"select s.* " +
                $"from X12.[{index}] s " +
                $"inner join X12.Interchange isa on isa.Id = s.InterchangeId " +
                $"inner join X12.[File] f on f.Id = isa.FileId " +
                $"where f.Filehash = @hash and isa.Id = @isaId ";

              cmd.Parameters.Add(new SqlParameter("@hash", SqlDbType.VarChar, 96)).Value = hash.Hash;
              cmd.Parameters.Add(new SqlParameter("@segment", SqlDbType.VarChar, 3)).Value = index;
              cmd.Parameters.Add(new SqlParameter("@isaId", SqlDbType.BigInt)).Value = isaId;

              using var reader = cmd.ExecuteReader();
              X12DelimiterSet delims = null;
              var elementsChecked = 0;
              IDictionary<int, Segment> segments = new Dictionary<int, Segment>();

              while (reader.Read())
                delims = new X12DelimiterSet(
                  reader.Get<char>("SegmentTerminator"),
                  reader.Get<char>("ElementSeparator"),
                  reader.Get<char>("ComponentSeparator"));

              reader.NextResult();

              while (reader.Read())
                segments.Add(
                  reader.Get<int>("PositionInInterchange"),
                  new Segment(null, delims, reader.Get("SegmentText")));

              reader.NextResult();

              while (reader.Read())
              {
                var pii = reader.Get<int>("PositionInInterchange");
                var expected = segments[pii];
                Type fieldType = null;
                elementsChecked = expected.ElementCount;

                for (var i = 1; i <= expected.ElementCount; i++)
                {
                  try
                  {
                    fieldType = reader.GetFieldType($"{i:D2}");
                  }
                  catch
                  {
                    Assert.Fail(
                      $"Unable to find reader column named `{i:D2}` on table `{index}`. " +
                      $"Available columns are {reader.GetColumnSchema().Select(x => x.ColumnName).Aggregate((acc, x) => $"{acc}, {x}")}");
                  }

                  Func<object> ef = fieldType.Name switch {
                    nameof(String)   => () => expected.GetElement(i),
                    nameof(DateTime) => () => expected.GetDate8Element(i),
                    nameof(Decimal)  => () => expected.GetDecimalElement(i),
                    nameof(Int32)    => () => expected.GetIntElement(i),
                    nameof(Int64)    => () => expected.GetLongElement(i),
                    nameof(TimeSpan) => () => expected.GetTimeElement(i),
                    "Byte[]"         => () => expected.GetBinaryElement(i),
                    _                => () => expected.GetElement(i),
                  };

                  Func<object> af = fieldType.Name switch {
                    nameof(String)   => () => reader.Get($"{i:D2}"),
                    nameof(DateTime) => () => reader.Get<DateTime?>($"{i:D2}"),
                    nameof(Decimal)  => () => reader.Get<decimal?>($"{i:D2}"),
                    nameof(Int32)    => () => reader.Get<int?>($"{i:D2}"),
                    nameof(Int64)    => () => reader.Get<long?>($"{i:D2}"),
                    nameof(TimeSpan) => () => reader.Get<TimeSpan?>($"{i:D2}"),
                    "Byte[]"         => () => reader.Get<byte[]?>($"{i:D2}"),
                    _                => () => reader.Get($"{i:D2}"),
                  };

                  Assert.AreEqual(
                    ef(),
                    af(),
                    $"Data Element does not match for Segment `{index}` at Interchange Position `{pii}` (`{fieldType.Name}`)");
                }
              }

              totalElementsChecked += elementsChecked * segments.Count;
            }
          }
        }

        Assert.Pass($"Compared a total of {totalElementsChecked:n0} segment data elements.");
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
}