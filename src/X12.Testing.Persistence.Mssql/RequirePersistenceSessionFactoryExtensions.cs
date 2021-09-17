using System.IO;
using System.Reflection;
using X12.Testing.Samples;

namespace X12.Testing.Persistence.Mssql
{
  public static class RequirePersistenceSessionFactoryExtensions
  {
    public static (string File, Stream Stream) LoadEmbeddedFileStream(
      this IRequirePersistenceSessionFactory _,
      SampleCategory category,
      SampleReferenceNumber number,
      string name)
    {
      var filename = $"X12.Testing.Samples.{category}.{number}.{name}";
      var stream = typeof(SampleCategory).Assembly.GetManifestResourceStream(filename);
      return (File: filename, Stream: stream);
    }
  }
}