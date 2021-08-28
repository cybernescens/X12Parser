using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X12.Parsing;

namespace X12.Tests.Unit.Flattening
{
  [TestClass]
  public class Flatten837Tester
  {
    [TestMethod]
    public void FlattenUsingXslt()
    {
      var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
        "X12.Tests.Unit.Parsing._SampleEdiFiles.INS._837P._4010.FromNth.837_DeIdent_01.dat");

      var parser = new X12Parser();
      var interchange = parser.ParseMultiple(stream).First();
      var xml = interchange.Serialize();

      var transform = new XslCompiledTransform();
      transform.Load(
        XmlReader.Create(
          Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("X12.Tests.Unit.Flattening.837-XML-to-claim-level-csv.xslt")));

      var writer = new StringWriter();

      transform.Transform(XmlReader.Create(new StringReader(xml)), new XsltArgumentList(), writer);
      Trace.WriteLine(writer.GetStringBuilder().ToString());
    }
  }
}