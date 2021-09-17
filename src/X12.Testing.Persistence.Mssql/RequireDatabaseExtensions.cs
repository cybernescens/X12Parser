using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace X12.Testing.Persistence.Mssql
{
  public static class RequireDatabaseExtensions
  {
    public static string GetQuery(this IRequireDatabase fixture, string name)
    {
      var type = fixture.GetType();
      using var stream = type.Assembly.GetManifestResourceStream($"{type.Namespace}.Queries.{name}.sql");
      Debug.Assert(stream != null, nameof(stream) + " != null");
      return new StreamReader(stream).ReadToEnd();
    }
  }
}