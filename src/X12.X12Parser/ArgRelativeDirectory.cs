using System;

namespace X12.X12Parser
{
  internal class ArgRelativeDirectory : Attribute
  {
    public ArgRelativeDirectory(string appendDirectory)
    {
      AppendDirectory = appendDirectory;
    }

    public string AppendDirectory { get; }
  }
}