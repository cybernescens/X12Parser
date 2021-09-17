using System.IO;
using System.Threading.Tasks;
using X12.Persistence.File;

namespace X12.Persistence
{
  /// <summary>
  ///   Service that Manages file hashes
  /// </summary>
  public interface IFileHashService
  {
    /// <summary>
    ///   Computes the hash of the provided file at file path provided in <paramref name="file" />
    /// </summary>
    /// <param name="file">the path to the file to hash</param>
    Task<FileHash> Compute(string file);

    /// <summary>
    ///   Computes the hash of the provided file at file path provided in <paramref name="stream" />
    /// </summary>
    /// <param name="stream">the stream of the file</param>
    /// <param name="filename">the name of the stream</param>
    Task<FileHash> Compute(Stream stream, string filename);
  }
}