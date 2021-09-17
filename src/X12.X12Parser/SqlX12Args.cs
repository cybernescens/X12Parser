using System;
using PowerArgs;

namespace X12.X12Parser
{
  public class SqlX12Args : RelativeDirectoryArgs
  {
    [ArgPosition(1)]
    [ArgRequired]
    [ArgDefaultValue("*")]
    [ArgShortcut(ArgShortcutPolicy.NoShortcut)]
    [ArgDescription("Search pattern to resolve files to be unbundled. Defaults to `*`.")]
    public string FilePattern { get; set; } = "*";
    
    [ArgShortcut("i")]
    [ArgShortcut("in")]
    [ArgDescription("The base directory to search in. Defaults to the current working directory.")]
    [ArgDirectoryBaseline]
    public string InputDirectory { get; set; }
    
    [ArgShortcut("a")]
    [ArgShortcut("archive")]
    [ArgRelativeDirectory("archive")]
    [ArgDescription("The base directory to output successfully imported files to. Defaults to the current working directory + `\\archive`.")]
    public string ArchiveDirectory { get; set; }
    
    [ArgShortcut("f")]
    [ArgShortcut("failures")]
    [ArgRelativeDirectory("failures")]
    [ArgDescription("The base directory to output failed import files to. Defaults to the current working directory + `\\failures`.")]
    public string FailureDirectory { get; set; }

    [ArgShortcut("ds")]
    [ArgDescription("Server to connect to. Defaults to local machine.")]
    public string Server { get; set; } = Environment.MachineName;

    [ArgShortcut("db")]
    [ArgShortcut("ic")]
    [ArgShortcut("database")]
    [ArgRequired]
    [ArgDescription("The name of the database catalog to connect to.")]
    public string InitialCatalog { get; set; }

    [ArgShortcut("is")]
    [ArgShortcut("sspi")]
    [ArgDefaultValue("true")]
    [ArgDescription("Determines if integrated security is used when connecting to the data source.")]
    [ArgCantBeCombinedWith(nameof(Username) + "|" + nameof(Password))]
    public bool IntegratedSecurity { get; set; }

    [ArgShortcut("u")]
    [ArgCantBeCombinedWith(nameof(IntegratedSecurity))]
    [ArgDescription("The username to connect to the data source.")]
    public string Username { get; set; }

    [ArgShortcut("p")]
    [ArgCantBeCombinedWith(nameof(IntegratedSecurity))]
    [ArgDescription("The password to connect to the data source.")]
    public string Password { get; set; }

    [ArgShortcut("az")]
    [ArgDescription("Flag indicating the SQL instance is hosted on Azure. Will attempt to read environmental information for authorization.")]
    public bool Azure { get; set; }
  }
}