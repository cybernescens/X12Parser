using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using X12.Parsing;
using X12.Persistence;

namespace X12.X12Parser.Import
{
  internal class ImportX12ParserCommand : ParserCommand
  {
    private readonly ImportX12Args args;
    private readonly IX12Parser parser;
    private readonly IPersistenceSessionFactory sessionFactory;

    public ImportX12ParserCommand(ImportX12Args args, IX12Parser parser, IPersistenceSessionFactory sessionFactory)
    {
      this.args = args;
      this.parser = parser;
      this.sessionFactory = sessionFactory;
    }

    public override async Task<int> Execute(CancellationToken ct)
    {
      foreach (var filename in Directory.GetFiles(args.InputDirectory, args.FilePattern, SearchOption.AllDirectories))
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
        using (var session = sessionFactory.OpenPersistence())
        {
          try
          {
            var hash = await sessionFactory.FileHashService.Compute(fs, filename);
            var interchanges = parser.Parse(fs, encoding);
            session.Persist(interchanges, new FileHash(hash.File, hash.Hash));
            
            if (!string.IsNullOrWhiteSpace(args.ArchiveDirectory))
              MoveTo(fi, args.InputDirectory, args.ArchiveDirectory);
          }
          catch (Exception exc)
          {
            Log.Error(exc, $"Error parsing {fi.FullName}");
            if (!string.IsNullOrEmpty(args.FailureDirectory))
              MoveTo(fi, args.InputDirectory, args.FailureDirectory);
          }
        }
      }

      return 0;
    }

    private static void MoveTo(FileInfo fi, string sourceDirectory, string targetDirectory)
    {
      var targetFilename = $"{targetDirectory}{fi.FullName.Replace(sourceDirectory, string.Empty)}";
      var targetFile = new FileInfo(targetFilename);
      try
      {
        if (!targetFile.Directory!.Exists)
          targetFile.Directory.Create();

        fi.MoveTo(targetFilename);
      }
      catch (Exception exc2)
      {
        Log.Error(exc2, $"Error moving {fi.FullName} to {targetFilename}");
      }
    }
  }
}