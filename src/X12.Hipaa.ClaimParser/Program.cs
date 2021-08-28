using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;
using Fonet;
using X12.Hipaa.Claims.Services;
using X12.Parsing;

namespace X12.Hipaa.ClaimParser
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var throwException = Convert.ToBoolean(ConfigurationManager.AppSettings["ThrowExceptionOnSyntaxErrors"]);

      var opts = new ExecutionOptions(args);
      var institutionalClaimToUB04ClaimFormTransformation =
        new InstitutionalClaimToUB04ClaimFormTransformation("UB04_Red.gif");

      var service = new ClaimFormTransformationService(
        new ProfessionalClaimToHcfa1500FormTransformation("HCFA1500_Red.gif"),
        institutionalClaimToUB04ClaimFormTransformation,
        new DentalClaimToJ400FormTransformation("ADAJ400_Red.gif"),
        new X12Parser(throwException));

      foreach (var filename in Directory.GetFiles(opts.Path, opts.SearchPattern, SearchOption.TopDirectoryOnly))
        try
        {
          #if DEBUG
          var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
          var parser = new X12Parser();
          var interchange = parser.ParseMultiple(stream).First();
          File.WriteAllText(filename + ".dat", interchange.SerializeToX12(true));
          stream.Close();
          #endif
          var start = DateTime.Now;
          var inputFilestream = new FileStream(filename, FileMode.Open, FileAccess.Read);

          var revenueDictionary = new Dictionary<string, string>();
          revenueDictionary["0572"] = "Test Code";
          service.FillRevenueCodeDescriptionMapping(revenueDictionary);
          var claimDoc = service.Transform837ToClaimDocument(inputFilestream);
          institutionalClaimToUB04ClaimFormTransformation.PerPageTotalChargesView = true;
          var fi = new FileInfo(filename);
          var di = new DirectoryInfo(opts.OutputPath);

          if (opts.MakeXml)
          {
            var outputFilename = string.Format("{0}\\{1}.xml", di.FullName, fi.Name);

            var xml = claimDoc.Serialize();
            xml = xml.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
            File.WriteAllText(outputFilename, xml);
          }

          if (opts.MakePdf)
          {
            var outputFilename = string.Format("{0}\\{1}.pdf", di.FullName, fi.Name);
            using (var pdfOutput = new FileStream(outputFilename, FileMode.Create, FileAccess.Write))
            {
              var foDoc = new XmlDocument();
              var foXml = service.TransformClaimDocumentToFoXml(claimDoc);
              foDoc.LoadXml(foXml);

              var driver = FonetDriver.Make();
              driver.Render(foDoc, pdfOutput);
              pdfOutput.Close();
            }
          }

          opts.WriteLine(string.Format("{0} parsed in {1}.", filename, DateTime.Now - start));
        }
        catch (Exception exc)
        {
          opts.WriteLine(
            string.Format("Exception occurred: {0}.  {1}.  {2}", exc.GetType().FullName, exc.Message, exc.StackTrace));
        }
    }
  }
}