using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;
using X12.Parsing;

namespace X12.Hipaa.Eligibility.Services
{
  public class EligibilityTransformationService
  {
    public EligibilityBenefitDocument Transform271ToBenefitResponse(Stream stream)
    {
      var fullResponse = new EligibilityBenefitDocument();

      var parser = new X12Parser(ParserSettings.Default);
      var interchanges = parser.Parse(stream);
      foreach (var interchange in interchanges)
      {
        var xml = interchange.Serialize();

        var transformStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
          "X12.Hipaa.Eligibility.Services.Xsl.X12-271-To-BenefitResponse.xslt");

        var transform = new XslCompiledTransform();
        if (transformStream != null) transform.Load(XmlReader.Create(transformStream));

        var outputStream = new MemoryStream();

        transform.Transform(XmlReader.Create(new StringReader(xml)), new XsltArgumentList(), outputStream);
        outputStream.Position = 0;
        var responseXml = new StreamReader(outputStream).ReadToEnd();
        var response = EligibilityBenefitDocument.Deserialize(responseXml);
        fullResponse.EligibilityBenefitInquiries.AddRange(response.EligibilityBenefitInquiries);
        fullResponse.EligibilityBenefitResponses.AddRange(response.EligibilityBenefitResponses);
        fullResponse.RequestValidations.AddRange(response.RequestValidations);
      }

      return fullResponse;
    }

    public string TransformBenefitResponseToHtml(EligibilityBenefitResponse response)
    {
      var xml = response.Serialize();

      var transformStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
        "X12.Hipaa.Eligibility.Services.Xsl.BenefitResponse-To-Html.xslt");

      var transform = new XslCompiledTransform();
      if (transformStream != null) transform.Load(XmlReader.Create(transformStream));

      var outputStream = new MemoryStream();
      var args = new XsltArgumentList();

      transform.Transform(XmlReader.Create(new StringReader(xml)), new XsltArgumentList(), outputStream);
      outputStream.Position = 0;
      return new StreamReader(outputStream).ReadToEnd();
    }
  }
}