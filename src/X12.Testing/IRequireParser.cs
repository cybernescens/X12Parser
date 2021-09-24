using X12.Config;
using X12.Parsing;

namespace X12.Testing
{
  [RequireParser]
  public interface IRequireParser
  {
    ParserConfiguration CurrentParserConfiguration { get; set; }
    IX12Parser Parser { get; set; }
    void ApplySettings(ParserSettings settings);
  }
}