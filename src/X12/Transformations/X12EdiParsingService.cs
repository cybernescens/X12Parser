using System.IO;
using System.Linq;
using System.Text;
using X12.Parsing;

namespace X12.Transformations
{
  public class X12EdiParsingService : ITransformationService
  {
    private readonly X12Parser _parser;
    private readonly bool _suppressComments;

    public X12EdiParsingService(bool suppressComments, X12Parser parser)
    {
      _suppressComments = suppressComments;
      _parser = parser;
    }

    public X12EdiParsingService(bool suppressComments) : this(suppressComments, new X12Parser()) { }

    public X12EdiParsingService(bool suppressComments, ISpecificationFinder specFinder) : this(
      suppressComments,
      new X12Parser(specFinder, true)) { }

    public string Transform(string x12)
    {
      var interchange = _parser.ParseMultiple(new MemoryStream(Encoding.ASCII.GetBytes(x12))).FirstOrDefault();
      return interchange.Serialize(_suppressComments);
    }
  }
}