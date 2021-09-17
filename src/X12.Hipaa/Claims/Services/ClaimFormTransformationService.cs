using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;
using X12.Hipaa.Claims.Forms;
using X12.Parsing;

namespace X12.Hipaa.Claims.Services
{
  public class ClaimFormTransformationService : ClaimTransformationService
  {
    private readonly IClaimToClaimFormTransfomation _dentalTransformation;
    private readonly IClaimToClaimFormTransfomation _institutionalTransformation;
    private readonly IClaimToClaimFormTransfomation _professionalTransformation;

    public ClaimFormTransformationService(
      IClaimToClaimFormTransfomation professionalTransformation,
      IClaimToClaimFormTransfomation institutionalTransformation,
      IClaimToClaimFormTransfomation dentalTransformation,
      X12Parser parser
    )
      : base(parser)
    {
      _professionalTransformation = professionalTransformation;
      _institutionalTransformation = institutionalTransformation;
      _dentalTransformation = dentalTransformation;
    }

    public ClaimFormTransformationService(
      IClaimToClaimFormTransfomation professionalTransformation,
      IClaimToClaimFormTransfomation institutionalTransformation,
      IClaimToClaimFormTransfomation dentalTransformation)
      : this(professionalTransformation, institutionalTransformation, dentalTransformation, new X12Parser(ParserSettings.Default)) { }

    public string TransformClaimDocumentToFoXml(ClaimDocument document)
    {
      var form = new FormDocument();

      foreach (var claim in document.Claims)
        if (claim.Type == ClaimTypeEnum.Professional)
        {
          var pages = _professionalTransformation.TransformClaimToClaimFormFoXml(claim);
          form.Pages.AddRange(pages);
        }
        else if (claim.Type == ClaimTypeEnum.Institutional)
        {
          var pages = _institutionalTransformation.TransformClaimToClaimFormFoXml(claim);
          form.Pages.AddRange(pages);
        }
        else
        {
          form.Pages.AddRange(_dentalTransformation.TransformClaimToClaimFormFoXml(claim));
        }

      var xml = form.Serialize();

      var transformStream = Assembly.GetExecutingAssembly()
        .GetManifestResourceStream("X12.Hipaa.Claims.Services.Xsl.FormDocument-To-FoXml.xslt");

      var transform = new XslCompiledTransform();
      if (transformStream != null) transform.Load(XmlReader.Create(transformStream));

      var outputStream = new MemoryStream();

      transform.Transform(XmlReader.Create(new StringReader(xml)), new XsltArgumentList(), outputStream);
      outputStream.Position = 0;
      return new StreamReader(outputStream).ReadToEnd();
    }
  }
}