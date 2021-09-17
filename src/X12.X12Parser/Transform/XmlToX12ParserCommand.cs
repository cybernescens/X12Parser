using System.IO;
using System.Threading;
using System.Threading.Tasks;
using X12.Parsing;

namespace X12.X12Parser.Transform
{
  internal class XmlToX12ParserCommand : ParserCommand
  {
    private readonly XmlToX12Args args;
    private readonly IX12ParserExtension parser;

    public XmlToX12ParserCommand(XmlToX12Args args, IX12ParserExtension parser)
    {
      this.args = args;
      this.parser = parser;
    }

    public override Task<int> Execute(CancellationToken ct)
    {
      var inputFs = new StreamReader(args.InputXml);
      var xmltext = inputFs.ReadToEnd();
      var x12 = parser.TransformToX12(xmltext);
      inputFs.Close();
      
      var outputFs = new FileStream(args.OutputX12, FileMode.Create);
      var writer = new StreamWriter(outputFs);
      writer.Write(x12);
      writer.Close();
      return Task.FromResult(0);
    }
  }
}