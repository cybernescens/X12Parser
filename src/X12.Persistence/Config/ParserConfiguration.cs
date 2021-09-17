using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using X12.Parsing;

namespace X12.Persistence.Config
{
  public class ParserConfiguration
  {
    public static ParserConfiguration Default = new();

    public bool ThrowExceptionOnSyntaxErrors { get; set; } = true;
    public char[] IgnoredCharacters { get; set; } = Array.Empty<char>();
    public Action<object, X12ParserWarningEventArgs> OnParserWarning { get; set; }
    public Encoding DefaultEncoding { get; set; } = Encoding.ASCII;

    internal IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton<IParserSettings>(
        sp =>
          new ParserSettings {
            DefaultEncoding = DefaultEncoding,
            IgnoredCharacters = IgnoredCharacters,
            OnParserWarning = OnParserWarning,
            ThrowExceptionOnSyntaxErrors = ThrowExceptionOnSyntaxErrors,
            SpecificationFinder = sp.GetRequiredService<ISpecificationFinder>()
          });

      sc.AddTransient<IX12Parser, X12Parser>();
      return sc;
    }
  }
}