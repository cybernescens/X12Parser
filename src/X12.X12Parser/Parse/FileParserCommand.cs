using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using X12.Parsing;

namespace X12.X12Parser.Parse
{
  internal class FileParserCommand : ParserCommand
  {
    private readonly ParseFileArgs args;
    private readonly ParserSettings config;
    private readonly ILogger<FileParserCommand> logger;

    public FileParserCommand(ParseFileArgs args, ParserSettings config, ILoggerFactory lf)
    {
      this.args = args;
      this.config = config;
      this.logger = lf.CreateLogger<FileParserCommand>();
    }

    public override async Task<int> Execute(CancellationToken ct)
    {
      config.WithParserWarning(ParserWarning);
      var parser = new Parsing.X12Parser(config);

      var header = new byte[6];
      using var fs = new FileStream(args.X12File, FileMode.Open, FileAccess.Read);
      // peak at first 6 characters to determine if this is a unicode file
      fs.Read(header, 0, 6);
      fs.Close();

      var encoding = header[1] == 0 && header[3] == 0 && header[5] == 0 
        ? Encoding.Unicode 
        : Encoding.UTF8;

      return await (new FileInfo(args.X12File).Length <= args.MaxBatchSize 
        ? ProcessSingleFile(parser, encoding) 
        : ProcessMultipleFiles(encoding, parser));
    }
    
    private void ParserWarning(object sender, X12ParserWarningEventArgs e)
    {
      logger.LogInformation(e.Message);
    }

    private Task<int> ProcessMultipleFiles(Encoding encoding, Parsing.X12Parser parser)
    {
      using var fs = new FileStream(args.X12File, FileMode.Open, FileAccess.Read);
      // Break up output files by batch size
      var reader = new X12StreamReader(fs, encoding);
      var currentTransactions = reader.ReadNextTransaction();
      var nextTransaction = reader.ReadNextTransaction();
      var i = 1;

      while (!string.IsNullOrEmpty(nextTransaction.Transactions.First()))
      {
        if (currentTransactions.GetSize() + nextTransaction.GetSize() < args.MaxBatchSize &&
          currentTransactions.IsaSegment == nextTransaction.IsaSegment &&
          currentTransactions.GsSegment == nextTransaction.GsSegment)
        {
          currentTransactions.Transactions.AddRange(nextTransaction.Transactions);
        }
        else
        {
          var outputFilename = $"{args.X12File}_{i++}.xml";
          using var outputFs = new FileStream(outputFilename, FileMode.Create);
          parser.Parse(currentTransactions.ToString()).First().Serialize(outputFs);

          currentTransactions = nextTransaction;
        }

        nextTransaction = reader.ReadNextTransaction();
      }

      var finalFilename = $"{args.X12File}_{i++}.xml";
      using var finalFs = new FileStream(finalFilename, FileMode.Create);
      parser.Parse(currentTransactions.ToString()).First().Serialize(finalFs);
      return Task.FromResult(1);
    }

    private Task<int> ProcessSingleFile(Parsing.X12Parser parser, Encoding encoding)
    {
      using var fs = new FileStream(args.X12File, FileMode.Open, FileAccess.Read);
      var interchanges = parser.Parse(fs, encoding);
      if (interchanges.Count >= 1)
      {
        using var outputFs = new FileStream(args.XmlOutput, FileMode.Create);
        interchanges.First().Serialize(outputFs);
      }

      if (interchanges.Count > 1)
      {
        for (var i = 1; i < interchanges.Count; i++)
        {
          var outputFilename = $"{args.X12File}_{i + 1}.xml";
          using var outputFs = new FileStream(outputFilename, FileMode.Create);
          interchanges[i].Serialize(outputFs);
        }
      }

      return Task.FromResult(1);
    }
  }
}