using System;
using System.IO;
using PowerArgs;

namespace X12.X12Parser.Transform
{
  internal class XmlToX12Args
  {
    private string outputFile;

    [ArgPosition(1)]
    [ArgRequired]
    [ArgShortcut("i")]
    [ArgShortcut("in")]
    [ArgExistingFile]
    [ArgDescription("The input X12 data as XML to transform to X12.")]
    public string InputXml { get; set; }

    [ArgPosition(2)]
    [ArgShortcut("o")]
    [ArgShortcut("out")]
    [ArgDescription("The output file path and name. If omitted defaults to the name of the input file with `.x12` as the extension.")]
    public string OutputX12 
    {
      get =>
        string.IsNullOrEmpty(outputFile) 
          ? Path.Combine(Environment.CurrentDirectory, $"{Path.GetFileNameWithoutExtension(InputXml)}.xml")
          : outputFile.IndexOf('/') < 0 && outputFile.IndexOf('\\') < 0 && !outputFile.EndsWith('/') && !outputFile.EndsWith('\\')
            ? Path.Combine(Environment.CurrentDirectory, outputFile)
            : outputFile;
      set => outputFile = value;
    } 
  }
}