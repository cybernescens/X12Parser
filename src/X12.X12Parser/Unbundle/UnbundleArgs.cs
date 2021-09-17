using System;
using System.IO;
using PowerArgs;

namespace X12.X12Parser.Unbundle
{
  internal class UnbundleArgs : RelativeDirectoryArgs
  {
    [ArgPosition(1)]
    [ArgRequired]
    [ArgDefaultValue("*")]
    [ArgShortcut(ArgShortcutPolicy.NoShortcut)]
    [ArgDescription("Search pattern to resolve files to be unbundled. Defaults to `*`.")]
    public string FilePattern { get; set; } = "*";

    [ArgDefaultValue(false)]
    [ArgShortcut("r")]
    [ArgDescription("When `true` recursively searches using `FilePattern` in `InputDirectory`")]
    public bool Recursive { get; set; }

    [ArgShortcut("i")]
    [ArgShortcut("in")]
    [ArgExistingDirectory]
    [ArgDirectoryBaseline]
    [ArgDescription("The base directory to search in. Defaults to the current working directory.")]
    public string InputDirectory { get; set; }

    [ArgShortcut("o")]
    [ArgShortcut("out")]
    [ArgRelativeDirectory("out")]
    [ArgDescription("The base directory to output to. Defaults to the current working directory + `\\out`.")]
    public string OutputDirectory { get; set; } = Path.Combine(Environment.CurrentDirectory, "out");

    [ArgShortcut("l")]
    [ArgShortcut("loop")]
    [ArgDescription("Hierarchical Loop to unbundle by.")]
    public string LoopId { get; set; }

    [ArgShortcut("f")]
    [ArgShortcut("format")]
    [ArgDefaultValue("{name}_{index}.{ext}")]
    [OutputFileFormatValidator]
    [ArgDescription(
      "Output File format contains three parameters: {name}, {index}, and {ext} and the default format is: `{name}_{index}.{ext}`")]
    public string OutputFileFormat { get; set; } = "{name}_{index}.{ext}";

    [ArgShortcut("w")]
    [ArgShortcut("whitespace")]
    [ArgDefaultValue("true")]
    [ArgDescription("Should we include whitespace in the output X12. Default value is `true`.")]
    public bool IncludeWhitespaceInOutput { get; set; } = true;
  }
}