using PowerArgs;

namespace X12.X12Parser.Acknowledge
{
  internal class AcknowledgeX12Args
  {
    [ArgPosition(1)]
    [ArgRequired]
    [ArgShortcut("i")]
    [ArgShortcut("in")]
    [ArgExistingFile]
    [ArgDescription("The input X12 data as XML to transform to X12.")]
    public string InputXml { get; set; }

    [ArgPosition(2)]
    [ArgRequired]
    [ArgShortcut("o")]
    [ArgShortcut("out")]
    [ArgDescription("The output acknowledge file path and name.")]
    public string OutputX12 { get; set; } 

    [ArgShortcut("isa")]
    [ArgShortcut(ArgShortcutPolicy.ShortcutsOnly)]
    [ArgDefaultValue("999")]
    [ArgDescription("The value to use for the ISA control number. Defaults to `999`.")]
    public int IsaControlNumber { get; set; }

    [ArgShortcut("gs")]
    [ArgShortcut(ArgShortcutPolicy.ShortcutsOnly)]
    [ArgDefaultValue("99")]
    [ArgDescription("The value to use for the GS control number. Defaults to `99`.")]
    public int GsControlNumber { get; set; }
  }
}