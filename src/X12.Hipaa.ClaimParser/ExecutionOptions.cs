using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace X12.Hipaa.ClaimParser
{
  public class ExecutionOptions
  {
    private readonly List<string> _options;

    public ExecutionOptions(string[] args)
    {
      if (args.Length > 0)
        Path = args[0];
      else
        Path = Environment.CurrentDirectory;

      if (args.Length > 1)
        SearchPattern = args[1];
      else
        SearchPattern = "*.*";

      if (args.Length > 2)
        OutputPath = args[2];
      else
        OutputPath = Environment.CurrentDirectory;

      _options = new List<string>();
      for (var i = 3; i < args.Length; i++)
        _options.Add(args[i].ToUpper());
    }

    public string Path { get; }
    public string SearchPattern { get; }
    public string OutputPath { get; }
    public bool MakeXml => !_options.Contains("NOXML");
    public bool MakePdf => !_options.Contains("NOPDF");

    public string LogFile => ConfigurationManager.AppSettings["LogFile"];

    public void WriteLine(string content)
    {
      var contents = string.Format("{0}: {1}\r\n", DateTime.Now, content);
      Console.WriteLine(contents);
      File.AppendAllText(LogFile, contents);
    }
  }
}