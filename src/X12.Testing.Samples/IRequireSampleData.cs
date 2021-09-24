using System.IO;

namespace X12.Testing.Samples
{
  public interface IRequireSampleData { }

  public static class RequireSampleDataExtensions
  {
    public static (string File, Stream Stream) LoadEmbeddedFileStream(
      this IRequireSampleData fixture,
      SampleCategory category,
      SampleReferenceNumber number,
      string name)
    {
      var filename = $"X12.Testing.Samples.{category}.{number}.{name}";
      var stream = typeof(RequireSampleDataExtensions).Assembly.GetManifestResourceStream(filename);
      return (File: filename, Stream: stream);
    }

    public static (string File, string Contents) LoadEmbeddedFileContents(
      this IRequireSampleData fixture,
      SampleCategory category,
      SampleReferenceNumber number,
      string name)
    {
      var filename = $"X12.Testing.Samples.{category}.{number}.{name}";
      using var stream = typeof(RequireSampleDataExtensions).Assembly.GetManifestResourceStream(filename);
      using var reader = new StreamReader(stream!);
      return (File: filename, Contents: reader.ReadToEnd());
    }
  }
}