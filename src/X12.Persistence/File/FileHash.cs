using System.IO;

namespace X12.Persistence.File
{
  /// <summary>
  /// Small wrapper around File with <see cref="System.IO.FileInfo"/> and the provided Hash
  /// (currently SHA384)
  /// </summary>
  public class FileHash
  {
    public FileHash(string file, string hash)
    {
      File = file;
      Hash = hash;
    }

    public string File { get; }
    public string Hash { get; }

    public override string ToString() => File;
  }
}