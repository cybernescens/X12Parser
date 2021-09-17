using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PowerArgs;
using X12.Model;
using X12.Parsing;

namespace X12.X12Parser.Unbundle
{
  internal class UnbundleParserCommand : ParserCommand
  {
    private readonly UnbundleArgs args;
    private readonly IX12ParserExtension parser;

    public UnbundleParserCommand(UnbundleArgs args, IX12ParserExtension parser)
    {
      this.args = args;
      this.parser = parser;
    }

    public override Task<int> Execute(CancellationToken ct)
    {
      var fileEnumerator = Directory.GetFiles(
        args.InputDirectory,
        args.FilePattern,
        args.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

      foreach (var filename in fileEnumerator)
      {
        var inputFile = new FileInfo(filename);
        var list = new List<Interchange>();
        using var fs = new FileStream(inputFile.FullName, FileMode.Open, FileAccess.Read);
        var reader = new X12StreamReader(fs, Encoding.UTF8);
        var transaction = reader.ReadNextTransaction();

        while (!string.IsNullOrEmpty(transaction.Transactions.FirstOrDefault()))
        {
          var x12 = transaction.ToString();
          var interchange = parser.Parse(x12).First();

          if (args.LoopId == "ST")
            list.Add(interchange);
          else
            list.AddRange(parser.UnbundleByLoop(interchange, args.LoopId));

          transaction = reader.ReadNextTransaction();
        }

        //var interchanges = parser.Parse(new FileStream(filename, FileMode.Open, FileAccess.Read));

        for (var i = 0; i < list.Count; i++)
        {
          var outputFilename = string.Format(
            args.OutputFileFormat.Replace("{name}", "{0}").Replace("{index}", "{1}").Replace("{ext}", "{2}"),
            inputFile.Name,
            i + 1,
            inputFile.Extension);

          var outputFilepath = Path.Combine(args.OutputDirectory, outputFilename);

          using var outfs = new FileStream(outputFilepath, FileMode.Create, FileAccess.Write);
          using var writer = new StreamWriter(outfs);
          writer.Write(list[i].SerializeToX12(args.IncludeWhitespaceInOutput));
          writer.Close();
          outfs.Close();
        }
      }

      return Task.FromResult(0);
    }
  }

  public class OutputFileFormatValidatorAttribute : ArgValidator
  {
    private string[] args = new[] { "name", "index", "ext" };

    public override void Validate(string name, ref string arg)
    {
      var y = new char[arg.Length];
      arg.CopyTo(0, y, 0, arg.Length);

      if (!args.All(x => new string(y).Contains($"{{{x}}}")))
        throw new ValidationArgException(
          $"OutputFileFormat must contain the following three template parameters: " +
          $"{string.Join(", ", args.Select(x => $"{{{x}}}"))}");
    } 
  }
}