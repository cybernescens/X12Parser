using System.Text;

namespace X12.Hipaa.Claims.Services
{
  public static class LocalExtensions
  {
    public static string Repeat(this char value, int count)
    {
      var builder = new StringBuilder();
      for (var i = 0; i < count; i++)
        builder.Append(value);

      return builder.ToString();
    }
  }
}