using System;
using System.Text;

namespace X12.Parsing
{
  /// <summary>
  /// The standard configuration options necessary for the <see cref="IX12Parser"/> to process files.
  /// </summary>
  public sealed class ParserSettings
  {
    /// <summary>
    /// An <see cref="ISpecificationFinder"/> determines how to resolve the correct specification
    /// </summary>
    public ISpecificationFinder SpecificationFinder { get; set; }
    
    /// <summary>
    /// When 'true' the <see cref="IX12Parser"/> will throw an exception when encountering a syntax error.
    /// When 'false' the <see cref="IX12Parser"/> calls the action set in <see cref="OnParserWarning"/>.
    /// </summary>
    public bool ThrowExceptionOnSyntaxErrors { get; set; }
    
    /// <summary>
    /// TODO: not sure what this does
    /// </summary>
    public char[] IgnoredCharacters { get; set; }
    
    /// <summary>
    /// When <see cref="ThrowExceptionOnSyntaxErrors"/> is 'false' this action is called.
    /// </summary>
    public Action<object, X12ParserWarningEventArgs> OnParserWarning { get; set; }
    
    /// <summary>
    /// The default <see cref="Encoding"/> when required and not specified. Defaults to UTF8.
    /// </summary>
    public Encoding DefaultEncoding { get; set; }
    
    /// <summary>
    /// Returns the default implementation with the default <see cref="ISpecificationFinder"/> and
    /// <see cref="ThrowExceptionOnSyntaxErrors"/> set to 'false'.
    /// </summary>
    public static ParserSettings Default =>
      new() {
        SpecificationFinder = new SpecificationFinder(),
        ThrowExceptionOnSyntaxErrors = false,
        IgnoredCharacters = new char[0],
        DefaultEncoding = Encoding.UTF8
      };

    /// <summary>
    /// Sets the specified <see cref="ISpecificationFinder"/>
    /// </summary>
    /// <param name="sf">the custom <see cref="ISpecificationFinder"/></param>
    /// <returns></returns>
    public ParserSettings WithSpecificationFinder(ISpecificationFinder sf)
    {
      SpecificationFinder = sf;
      return this;
    }

    /// <summary>
    /// Sets the specified <see cref="OnParserWarning"/>
    /// </summary>
    /// <param name="opw"></param>
    /// <returns></returns>
    public ParserSettings WithParserWarning(Action<object, X12ParserWarningEventArgs> opw)
    {
      OnParserWarning = opw;
      return this;
    }
  }
}