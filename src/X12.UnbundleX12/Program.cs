using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X12.Parsing;
using X12.Parsing.Model;

namespace X12.UnbundleX12
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var opts = new ExecutionOptions();
      try
      {
        opts.LoadOptions(args);
      }
      catch (ArgumentException exc)
      {
        Console.Write(exc.Message);
        return;
      }

      var parser = new X12Parser();

      foreach (var filename in Directory.GetFiles(opts.InputDirectory, opts.FilenamePattern))
      {
        var inputFile = new FileInfo(filename);
        var list = new List<Interchange>();
        using (var fs = new FileStream(inputFile.FullName, FileMode.Open, FileAccess.Read))
        {
          var reader = new X12StreamReader(fs, Encoding.UTF8);
          var transaction = reader.ReadNextTransaction();
          while (!string.IsNullOrEmpty(transaction.Transactions.First()))
          {
            var x12 = transaction.ToString();
            var interchange = parser.ParseMultiple(x12).First();
            if (opts.LoopId == "ST")
              list.Add(interchange);
            else
              list.AddRange(parser.UnbundleByLoop(interchange, opts.LoopId));

            transaction = reader.ReadNextTransaction();
          }
        }

        var interchanges = parser.ParseMultiple(new FileStream(filename, FileMode.Open, FileAccess.Read));
        for (var i = 0; i < list.Count; i++)
        {
          var outputFilename = string.Format(
            opts.FormatString,
            opts.OutputDirectory,
            inputFile.Name,
            i + 1,
            inputFile.Extension);

          using (var outputFilestream = new FileStream(outputFilename, FileMode.Create, FileAccess.Write))
          {
            using (var writer = new StreamWriter(outputFilestream))
            {
              writer.Write(list[i].SerializeToX12(opts.IncludeWhitespace));
              writer.Close();
            }

            outputFilestream.Close();
          }
        }
      }
    }
  }
}