using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace X12.Persistence.File
{
  /// <summary>
  ///   Generic Service for hashing files asynchronously
  /// </summary>
  public abstract class FileHashService : IFileHashService
  {
    private const int BufferSize = 4096;

    /// <summary>
    /// Gets the concrete <see cref="SHA1"/>, i.e. <see cref="MD5"/> or <see cref="HashAlgorithm"/>
    /// </summary>
    protected abstract HashAlgorithm GetHashAlgorithm();

    /// <inheritdoc />
    public Task<FileHash> Compute(string file) =>
      ComputeHash(file).ContinueWith(
        cw =>
          new FileHash(file, BitConverter.ToString(cw.Result).Replace("-", string.Empty)));

    /// <inheritdoc />
    public Task<FileHash> Compute(Stream stream, string filename) =>
      ComputeHash(stream).ContinueWith(
        cw =>
          new FileHash(filename, BitConverter.ToString(cw.Result).Replace("-", string.Empty)));

    private Task<byte[]> ComputeHash(string path)
    {
      using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
      return ComputeHash(stream);
    }

    private async Task<byte[]> ComputeHash(Stream stream)
    {
      using var hash = GetHashAlgorithm();
      var buffer = new byte[BufferSize];
      var streamLength = stream.Length;
      hash.Initialize();

      while (true)
      {
        var read = await stream.ReadAsync(buffer, 0, BufferSize).ConfigureAwait(false);
        if (stream.Position == streamLength)
        {
          hash.TransformFinalBlock(buffer, 0, read);
          break;
        }

        hash.TransformBlock(buffer, 0, read, default, default);
      }

      return hash.Hash!;
    }
  }
}