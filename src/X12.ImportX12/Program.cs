using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using X12.Parsing;
using X12.Repositories;

namespace X12.ImportX12
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var dsn = ConfigurationManager.ConnectionStrings["X12"].ConnectionString;

      var throwExceptionOnSyntaxErrors = ConfigurationManager.AppSettings["ThrowExceptionOnSyntaxErrors"] == "true";
      var segments = ConfigurationManager.AppSettings["IndexedSegments"].Split(',');
      var parseDirectory = ConfigurationManager.AppSettings["ParseDirectory"];
      var parseSearchPattern = ConfigurationManager.AppSettings["ParseSearchPattern"];
      var archiveDirectory = ConfigurationManager.AppSettings["ArchiveDirectory"];
      var failureDirectory = ConfigurationManager.AppSettings["FailureDirectory"];
      var sqlDateType = ConfigurationManager.AppSettings["SqlDateType"];
      var segmentBatchSize = Convert.ToInt32(ConfigurationManager.AppSettings["SqlSegmentBatchSize"]);

      var specFinder = new SpecificationFinder();
      var parser = new X12Parser(throwExceptionOnSyntaxErrors);
      parser.ParserWarning += parser_ParserWarning;
      var repo = new SqlTransactionRepository<int>(
        dsn,
        specFinder,
        segments,
        ConfigurationManager.AppSettings["schema"],
        ConfigurationManager.AppSettings["containerSchema"],
        segmentBatchSize,
        sqlDateType);

      foreach (var filename in Directory.GetFiles(parseDirectory, parseSearchPattern, SearchOption.AllDirectories))
      {
        var header = new byte[6];
        using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
          // peak at first 6 characters to determine if this is a unicode file
          fs.Read(header, 0, 6);
          fs.Close();
        }

        var encoding = header[1] == 0 && header[3] == 0 && header[5] == 0 ? Encoding.Unicode : Encoding.UTF8;

        var fi = new FileInfo(filename);
        using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
          try
          {
            var interchanges = parser.ParseMultiple(fs, encoding);

            foreach (var interchange in interchanges)
              repo.Save(interchange, filename, Environment.UserName);

            if (!string.IsNullOrWhiteSpace(archiveDirectory))
              MoveTo(fi, parseDirectory, archiveDirectory);
          }
          catch (Exception exc)
          {
            Trace.TraceError("Error parsing {0}: {1}\n{2}", fi.FullName, exc.Message, exc.StackTrace);
            if (!string.IsNullOrEmpty(failureDirectory))
              MoveTo(fi, parseDirectory, failureDirectory);
          }
        }
      }
    }

    private static void MoveTo(FileInfo fi, string sourceDirectory, string targetDirectory)
    {
      var targetFilename = string.Format("{0}{1}", targetDirectory, fi.FullName.Replace(sourceDirectory, ""));
      var targetFile = new FileInfo(targetFilename);
      try
      {
        if (!targetFile.Directory.Exists)
          targetFile.Directory.Create();

        fi.MoveTo(targetFilename);
      }
      catch (Exception exc2)
      {
        Trace.TraceError(
          "Error moving {0} to {1}: {2}\n{3}",
          fi.FullName,
          targetFilename,
          exc2.Message,
          exc2.StackTrace);
      }
    }

    private static void parser_ParserWarning(object sender, X12ParserWarningEventArgs args)
    {
      Trace.TraceWarning(
        "Error parsing interchange {0} at position {1}: {2}",
        args.InterchangeControlNumber,
        args.SegmentPositionInInterchange,
        args.Message);
    }
  }
}