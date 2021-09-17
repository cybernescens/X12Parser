using System.IO;
using System.Reflection;

namespace X12.Tests
{
  public static class Extensions
  {
    public static Stream GetEdi(string resourcePath) =>
      Assembly.GetExecutingAssembly()
        .GetManifestResourceStream("X12.Tests.Unit.Parsing.SampleEdiFiles." + resourcePath);

    public static void PrintToFile(this FileStream fs, string content)
    {
      var writer = new StreamWriter(fs);
      writer.WriteLine(content);
      writer.Close();
      fs.Close();
    }

    public static void PrintHtmlToFile(this FileStream fs, string html)
    {
      var writer = new StreamWriter(fs);
      writer.WriteLine("<html><body>");
      writer.WriteLine(html);
      writer.WriteLine("</body></html>");
      writer.Close();
      fs.Close();
    }
  }
}