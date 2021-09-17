using System.Security.Cryptography;

namespace X12.Persistence.File
{
  /// <summary>
  ///   Hashes a file using the <see cref="SHA384Managed" /> class
  /// </summary>
  public class SHA384FileHashService : FileHashService
  {
    /// <inheritdoc />
    protected override HashAlgorithm GetHashAlgorithm() => SHA384Managed.Create();
  }
}