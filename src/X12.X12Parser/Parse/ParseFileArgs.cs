using PowerArgs;

namespace X12.X12Parser.Parse
{
  internal class ParseFileArgs
  {
    [ArgPosition(1)]
    [ArgRequired]
    [ArgShortcut("i")]
    [ArgShortcut("x12")]
    [ArgExistingFile]
    public string X12File { get; set; }

    [ArgPosition(2)]
    [ArgShortcut("o")]
    [ArgShortcut("xml")]
    public string XmlOutput { get; set; }

    [ArgShortcut("s")]
    [ArgShortcut("size")]
    [ArgDefaultValue(int.MaxValue)]
    [ArgDescription(
      "The maximum byte size that can be parsed as one file. When a file is large than this size it will be split into smaller files.")]
    public int MaxBatchSize { get; set; }

    [ArgShortcut("e")]
    [ArgShortcut("errors")]
    [ArgDefaultValue(false)]
    [ArgDescription("When 'true' will throw exceptions when syntax errors are encountered.")]
    public bool ThrowExceptionOnSyntaxErrors { get; set; }
  }
}