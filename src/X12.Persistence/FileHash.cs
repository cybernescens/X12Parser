using System;

namespace X12.Persistence
{
  /// <summary>
  /// Small wrapper around File with <see cref="System.IO.FileInfo"/> and the provided Hash
  /// (currently SHA384)
  /// </summary>
  public class FileHash
  {
    public FileHash(string file, string hash, string? owner = null)
    {
      File = file;
      Hash = hash;
      Owner = owner ?? $"{Environment.UserDomainName}\\{Environment.UserName}";
    }
  
    public string File { get; }
    public string Hash { get; }
    public string Owner { get; }

    public override string ToString() => File;
  }
}