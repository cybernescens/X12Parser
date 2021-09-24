using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace X12.Persistence.Model
{
  [Table("File")]
  public class FileEntity : Entity
  {
    public FileEntity(string filepath, string filehash, string? username = null)
    {
      PersistUser = username ?? $"{Environment.UserDomainName}\\{Environment.UserName}";
      Filename = Path.GetFileName(filepath);
      PersistMoment = DateTime.Now;
      FileHash = filehash;
    }

    [MaxLength(255)]
    [Required]
    public string Filename { get; }

    [MaxLength(96)]
    [Required]
    public string FileHash { get; }

    [MaxLength(100)]
    [Required]
    public string PersistUser { get; }

    [DataType(DataType.DateTime)]
    [Required]
    public DateTime PersistMoment { get; }

    public static explicit operator FileEntity(FileHash fileHash) =>
      new FileEntity(fileHash.File, fileHash.Hash, fileHash.Owner);
  }
}