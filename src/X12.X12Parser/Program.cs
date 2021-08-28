using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using X12.Parsing;

namespace X12.X12Parser
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var maxBatchSize = 10 * 1012 * 1012; // 10 Mbytes
      if (ConfigurationManager.AppSettings["MaxBatchSize"] != null)
        maxBatchSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxBatchSize"]);

      var throwException = Convert.ToBoolean(ConfigurationManager.AppSettings["ThrowExceptionOnSyntaxErrors"]);

      var x12Filename = args[0];
      var outputFilename = args.Length > 1 ? args[1] : x12Filename + ".xml";

      var parser = new Parsing.X12Parser(throwException);
      parser.ParserWarning += parser_ParserWarning;

      var header = new byte[6];
      using (var fs = new FileStream(x12Filename, FileMode.Open, FileAccess.Read))
      {
        // peak at first 6 characters to determine if this is a unicode file
        fs.Read(header, 0, 6);
        fs.Close();
      }

      var encoding = header[1] == 0 && header[3] == 0 && header[5] == 0 ? Encoding.Unicode : Encoding.UTF8;

      if (new FileInfo(x12Filename).Length <= maxBatchSize)
        using (var fs = new FileStream(x12Filename, FileMode.Open, FileAccess.Read))
        {
          var interchanges = parser.ParseMultiple(fs, encoding);
          if (interchanges.Count >= 1)
            using (var outputFs = new FileStream(outputFilename, FileMode.Create))
            {
              interchanges.First().Serialize(outputFs);
            }

          if (interchanges.Count > 1)
            for (var i = 1; i < interchanges.Count; i++)
            {
              outputFilename = string.Format("{0}_{1}.xml", args.Length > 1 ? args[1] : x12Filename, i + 1);
              using (var outputFs = new FileStream(outputFilename, FileMode.Create))
              {
                interchanges[i].Serialize(outputFs);
              }
            }
        }
      else
        using (var fs = new FileStream(x12Filename, FileMode.Open, FileAccess.Read))
        {
          // Break up output files by batch size
          var reader = new X12StreamReader(fs, encoding);
          var currentTransactions = reader.ReadNextTransaction();
          var nextTransaction = reader.ReadNextTransaction();
          var i = 1;
          while (!string.IsNullOrEmpty(nextTransaction.Transactions.First()))
          {
            if (currentTransactions.GetSize() + nextTransaction.GetSize() < maxBatchSize &&
              currentTransactions.IsaSegment == nextTransaction.IsaSegment &&
              currentTransactions.GsSegment == nextTransaction.GsSegment)
            {
              currentTransactions.Transactions.AddRange(nextTransaction.Transactions);
            }
            else
            {
              outputFilename = string.Format("{0}_{1}.xml", args.Length > 1 ? args[1] : x12Filename, i++);
              using (var outputFs = new FileStream(outputFilename, FileMode.Create))
              {
                parser.ParseMultiple(currentTransactions.ToString()).First().Serialize(outputFs);
              }

              currentTransactions = nextTransaction;
            }

            nextTransaction = reader.ReadNextTransaction();
          }

          outputFilename = string.Format("{0}_{1}.xml", args.Length > 1 ? args[1] : x12Filename, i++);
          using (var outputFs = new FileStream(outputFilename, FileMode.Create))
          {
            parser.ParseMultiple(currentTransactions.ToString()).First().Serialize(outputFs);
          }
        }
    }

    private static void parser_ParserWarning(object sender, X12ParserWarningEventArgs args)
    {
      Console.WriteLine(args.Message);
    }
  }
}