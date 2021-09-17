using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using NUnit.Framework;
using X12.Parsing;
using X12.Transformations;

namespace X12.Tests.Parsing
{
  /// <summary>
  ///   Summary description for ParsingTester
  /// </summary>
  [TestFixture]
  [Ignore("These tests need rewritten as they were utilizing an interesting extension method to TestContext")]
  public class ParsingTester
  {
    private Stream GetEdi(string resourcePath) =>
      Assembly.GetExecutingAssembly()
        .GetManifestResourceStream("X12.Tests.Unit.Parsing.SampleEdiFiles." + resourcePath);

    private string GetXPathQuery(int index)
    {
      //if (TestContext.DataRow.Table.Columns.Contains(string.Format("Query{0}", index)))
      //  return Convert.ToString(TestContext.DataRow[string.Format("Query{0}", index)]);

      return null;
    }

    private string GetExpectedValue(int index)
    {
      //if (TestContext.DataRow.Table.Columns.Contains(string.Format("Expected{0}", index)))
      //  return Convert.ToString(TestContext.DataRow[string.Format("Expected{0}", index)]);

      return null;
    }

    //[DeploymentItem("tests\\X12.Tests.Unit\\Parsing\\_SampleEdiFiles\\SampleEdiFileInventory.xml")]
    //[DataSource(
    //  "Microsoft.VisualStudio.TestTools.DataSource.XML",
    //  "|DataDirectory|\\SampleEdiFileInventory.xml",
    //  "EdiFile",
    //  DataAccessMethod.Sequential)]
    [Test]
    public void ParseToXml()
    {
      var resourcePath = Convert.ToString(TestContext.CurrentContext.Test.Properties["ResourcePath"]);
      Trace.WriteLine(resourcePath);
      var stream = GetEdi(resourcePath);

      var parser = new X12Parser(ParserSettings.Default);
      var interchange = parser.Parse(stream).First();
      var xml = interchange.Serialize();
      #if DEBUG
      new FileStream(resourcePath.Replace(".txt", ".xml"), FileMode.Create).PrintToFile(xml);
      #endif
      var doc = new XmlDocument();
      doc.LoadXml(xml);
      var index = 1;
      var query = GetXPathQuery(index);
      while (!string.IsNullOrWhiteSpace(query))
      {
        var expected = GetExpectedValue(index);
        var node = doc.SelectSingleNode(query);
        Assert.IsNotNull(node, "Query '{0}' not found in {1}.", query, resourcePath);
        Assert.AreEqual(
          expected,
          node.InnerText,
          "Value {0} not expected from query {1} in {2}.",
          node.InnerText,
          query,
          resourcePath);

        Trace.WriteLine(string.Format("Query '{0}' succeeded.", query));
        query = GetXPathQuery(++index);
      }

      if (resourcePath.Contains("_837D"))
      {
        stream = GetEdi(resourcePath);
        parser = new X12Parser(ParserSettings.Default.WithSpecificationFinder(new DentalClaimSpecificationFinder()));
        interchange = parser.Parse(stream).First();
        xml = interchange.Serialize();
        #if DEBUG
        new FileStream(resourcePath.Replace(".txt", "_837D.xml"), FileMode.Create).PrintToFile(xml);
        #endif
      }

      if (resourcePath.Contains("_837I"))
      {
        stream = GetEdi(resourcePath);
        parser = new X12Parser(ParserSettings.Default.WithSpecificationFinder(new InstitutionalClaimSpecificationFinder()));
        interchange = parser.Parse(stream).First();
        xml = interchange.Serialize();
        #if DEBUG
        new FileStream(resourcePath.Replace(".txt", "_837I.xml"), FileMode.Create).PrintToFile(xml);
        #endif
      }
    }

    //[DeploymentItem("tests\\X12.Tests.Unit\\Parsing\\_SampleEdiFiles\\SampleEdiFileInventory.xml")]
    //[DataSource(
    //  "Microsoft.VisualStudio.TestTools.DataSource.XML",
    //  "|DataDirectory|\\SampleEdiFileInventory.xml",
    //  "EdiFile",
    //  DataAccessMethod.Sequential)]
    [Test]
    public void ParseAndUnparse()
    {
      var resourcePath = Convert.ToString(TestContext.CurrentContext.Test.Properties["ResourcePath"]);
      Trace.WriteLine(resourcePath);
      var stream = GetEdi(resourcePath);
      var orignalX12 = new StreamReader(stream).ReadToEnd();
      stream = GetEdi(resourcePath);
      var pc = ParserSettings.Default;
      pc.ThrowExceptionOnSyntaxErrors = false;
      pc.OnParserWarning = parser_ParserWarning;
      var parser = new X12Parser(pc);
      var interchanges = parser.Parse(stream);

      if (resourcePath.Contains("_811"))
        Trace.Write("");

      var x12 = new StringBuilder();
      foreach (var interchange in interchanges)
        x12.AppendLine(interchange.SerializeToX12(true));

      Assert.AreEqual(orignalX12, x12.ToString().Trim());
      Trace.Write(x12.ToString());
    }

    private void parser_ParserWarning(object sender, X12ParserWarningEventArgs args) { Trace.Write(args.Message); }

    //[DeploymentItem("tests\\X12.Tests.Unit\\Parsing\\_SampleEdiFiles\\SampleEdiFileInventory.xml")]
    //[DataSource(
    //  "Microsoft.VisualStudio.TestTools.DataSource.XML",
    //  "|DataDirectory|\\SampleEdiFileInventory.xml",
    //  "EdiFile",
    //  DataAccessMethod.Sequential)]
    [Test]
    public void ParseAndTransformToX12()
    {
      var resourcePath =
        Convert.ToString(TestContext.CurrentContext.Test.Properties["ResourcePath"]); // "INS._837P._4010.Spec_4.1.1_PatientIsSubscriber.txt";

      if (!resourcePath.Contains("_0x1D"))
      {
        Trace.WriteLine(resourcePath);
        var stream = GetEdi(resourcePath);

        var parser = new X12ParserExtension(ParserSettings.Default);
        var interchange = parser.Parse(stream).First();
        var originalX12 = interchange.SerializeToX12(true);

        var xml = interchange.Serialize();
        var x12 = parser.TransformToX12(xml);

        var newInterchange = parser.Parse(x12).First();
        var newX12 = newInterchange.SerializeToX12(true);

        Assert.AreEqual(originalX12, newX12);
        Trace.Write(x12);
      }
    }

    [Test]
    public void ParseModifyAndTransformBackToX12()
    {
      var stream = GetEdi("INS._270._4010.Example1_DHHS.txt");

      var parser = new X12ParserExtension(ParserSettings.Default);
      var interchange = parser.Parse(stream).First();
      var originalX12 = interchange.SerializeToX12(true);

      var xml = interchange.Serialize();

      var doc = new XmlDocument();
      doc.PreserveWhitespace = true;
      doc.LoadXml(xml);

      var dmgElement = (XmlElement) doc.GetElementsByTagName("DMG")[0];
      dmgElement.ParentNode.RemoveChild(dmgElement);

      Console.WriteLine(doc.OuterXml);
      var x12 = parser.TransformToX12(doc.OuterXml);

      Console.WriteLine("ISA Segmemt:");
      Console.WriteLine(x12.Substring(0, 106));
      Console.WriteLine("Directly from XML:");
      Console.WriteLine(x12);

      var modifiedInterchange = parser.Parse(x12).First();

      var newX12 = modifiedInterchange.SerializeToX12(true);

      Console.WriteLine("After passing through interchange object:");
      Console.WriteLine(newX12);

      var seSegment = modifiedInterchange.FunctionGroups.First().Transactions.First().TrailerSegments
        .FirstOrDefault(ts => ts.SegmentId == "SE");

      Assert.IsNotNull(seSegment);
      Assert.AreEqual("0001", seSegment.GetElement(2));
      Assert.AreEqual("15", seSegment.GetElement(1));
    }

    //[DeploymentItem("tests\\X12.Tests.Unit\\Parsing\\_SampleEdiFiles\\SampleEdiFileInventory.xml")]
    //[DataSource(
    //  "Microsoft.VisualStudio.TestTools.DataSource.XML",
    //  "|DataDirectory|\\SampleEdiFileInventory.xml",
    //  "EdiFile",
    //  DataAccessMethod.Sequential)]
    [Test]
    public void ParseToHtml()
    {
      var resourcePath = Convert.ToString(TestContext.CurrentContext.Test.Properties["ResourcePath"]);
      Trace.WriteLine(resourcePath);
      var stream = GetEdi(resourcePath);
      if (!resourcePath.Contains("MultipleInterchanges"))
      {
        var service = new X12HtmlTransformationService(new X12EdiParsingService(false));
        var html = service.Transform(new StreamReader(stream).ReadToEnd());

        Trace.Write(html);
        #if DEBUG
        new FileStream(resourcePath.Replace(".txt", ".htm"), FileMode.Create).PrintHtmlToFile(html);
        #endif
      }
    }

    [Test]
    [Ignore("Test needs updated.")]
    public void CreateTestFile()
    {
      var filename =
        @"C:\Projects\Codeplex\X12Parser\trunk\tests\X12.Tests.Unit\Parsing\_SampleEdiFiles\INS\_270\_5010\Example1_IG_0x1D.txt";

      var edi = File.ReadAllText(filename);

      edi = edi.Replace('~', '\x1D');
      File.WriteAllText(filename, edi);
    }

    [Test]
    [Ignore("Test needs updated.")]
    public void CreateTestFileWithTrailingBlanks()
    {
      var filename =
        @"C:\Projects\Codeplex\X12Parser\trunk\tests\X12.Tests.Unit\Parsing\_SampleEdiFiles\INS\_837P\_5010\MedicaidExample_WithTrailingBlanks.txt";

      var edi = new StringBuilder(File.ReadAllText(filename));

      edi.Append((char) 0);
      edi.Append((char) 0);
      edi.Append((char) 0);
      edi.Append((char) 0);
      edi.Append((char) 0);
      edi.Append((char) 0);
      File.WriteAllText(filename, edi.ToString());
    }

    [Test]
    public void ParseUnicodeFile()
    {
      var fs = Assembly.GetExecutingAssembly().GetManifestResourceStream(
        "X12.Tests.Unit.Parsing.SampleEdiFiles.INS._837P._5010.UnicodeExample.txt");

      var parser = new X12Parser(ParserSettings.Default);
      var interchange = parser.Parse(fs, Encoding.Unicode);
      Trace.Write(interchange.First().Serialize());
    }

    #region TestContext

    /// <summary>
    ///   Gets or sets the test context which provides
    ///   information about and functionality for the current test run.
    /// </summary>
    public TestContext TestContext { get; set; }

    #endregion
  }
}