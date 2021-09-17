using System.Collections.Generic;

namespace X12.Persistence.File
{
  /// <summary>
  /// Equality Comparer for <see cref="FileHash"/> objects
  /// </summary>
  public class FileHashEqualityComparer : EqualityComparer<FileHash>
  {
    /// <inheritdoc />
    public override bool Equals(FileHash x, FileHash y) => x?.Hash == y?.Hash;

    /// <inheritdoc />
    public override int GetHashCode(FileHash obj) => obj?.Hash.GetHashCode() ?? 0;
  }
}