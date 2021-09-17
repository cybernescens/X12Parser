using System;
using System.Text;

namespace X12.Parsing
{
  /// <summary>
  /// Configuration options for the <see cref="IX12Parser"/>
  /// </summary>
  public interface IParserSettings
  {
    /// <summary>
    /// An <see cref="ISpecificationFinder"/> determines how to resolve the correct specification
    /// </summary>
    ISpecificationFinder SpecificationFinder { get; set; }

    /// <summary>
    /// When 'true' the <see cref="IX12Parser"/> will throw an exception when encountering a syntax error.
    /// When 'false' the <see cref="IX12Parser"/> calls the action set in <see cref="OnParserWarning"/>.
    /// </summary>
    bool ThrowExceptionOnSyntaxErrors { get; set; }

    /// <summary>
    /// TODO: not sure what this does
    /// </summary>
    char[] IgnoredCharacters { get; set; }

    /// <summary>
    /// When <see cref="ThrowExceptionOnSyntaxErrors"/> is 'false' this action is called.
    /// </summary>
    Action<object, X12ParserWarningEventArgs> OnParserWarning { get; set; }

    /// <summary>
    /// The default <see cref="Encoding"/> when required and not specified. Defaults to UTF8.
    /// </summary>
    Encoding DefaultEncoding { get; set; }
  }

  /// <summary>
  /// The standard configuration options necessary for the <see cref="IX12Parser"/> to process files.
  /// </summary>
  public class ParserSettings : IParserSettings
  {
    /// <inheritdocs />
    public ISpecificationFinder SpecificationFinder { get; set; }
    
    /// <inheritdocs />
    public bool ThrowExceptionOnSyntaxErrors { get; set; }
    
    /// <inheritdocs />
    public char[] IgnoredCharacters { get; set; }
    
    /// <inheritdocs />
    public Action<object, X12ParserWarningEventArgs> OnParserWarning { get; set; }

    /// <inheritdocs />
    public Encoding DefaultEncoding { get; set; }
    
    /// <summary>
    /// Returns the default implementation with the default <see cref="ISpecificationFinder"/> and
    /// <see cref="ThrowExceptionOnSyntaxErrors"/> set to 'false'.
    /// </summary>
    public static IParserSettings Default =>
      new ParserSettings {
        SpecificationFinder = new SpecificationFinder(),
        ThrowExceptionOnSyntaxErrors = false,
        IgnoredCharacters = new char[0],
        DefaultEncoding = Encoding.UTF8
      };
  }

  public static class ParserSettingsExtensions
  {
    /// <summary>
    /// Adds the specified <see cref="ISpecificationFinder"/>
    /// </summary>
    /// <param name="pc"></param>
    /// <param name="sf">the custom <see cref="ISpecificationFinder"/></param>
    /// <returns></returns>
    public static IParserSettings WithSpecificationFinder(this IParserSettings pc, ISpecificationFinder sf)
    {
      pc.SpecificationFinder = sf;
      return pc;
    }

    /// <summary>
    /// Creates the default <see cref="IParserSettings"/> with the specified <see cref="ISpecificationFinder"/>
    /// </summary>
    /// <param name="pc"></param>
    /// <param name="opw"></param>
    /// <returns></returns>
    public static IParserSettings WithParserWarning(this IParserSettings pc, Action<object, X12ParserWarningEventArgs> opw)
    {
      pc.OnParserWarning = opw;
      return pc;
    }
  }
}