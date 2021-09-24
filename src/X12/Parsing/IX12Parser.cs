using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using X12.Model;

namespace X12.Parsing
{
  /// <summary>
  /// Both Sync and Async methods available to an X12 Parser
  /// </summary>
  public interface IX12Parser
  {
    /// <summary>
    /// Parses an X12 file
    /// </summary>
    /// <param name="x12">the contents of an X12 file as a string</param>
    /// <param name="encoding">the document encoding or null for the default encoding</param>
    /// <returns>a list of processed <see cref="Interchange"/>s</returns>
    IList<Interchange> Parse(string x12, Encoding encoding = null);

    /// <summary>
    /// Parses an X12 file
    /// </summary>
    /// <param name="stream">the X12 file as a stream</param>
    /// <param name="encoding">the document encoding or null for the default encoding</param>
    /// <returns>a list of processed <see cref="Interchange"/>s</returns>
    IList<Interchange> Parse(Stream stream, Encoding encoding = null);
    
    /// <summary>
    /// Parses an X12 file
    /// </summary>
    /// <param name="stream">the X12 file as a stream</param>
    /// <param name="encoding">the document encoding or null for the default encoding</param>
    /// <returns>a list of processed <see cref="Interchange"/>s</returns>
    Task<IList<Interchange>> ParseAsync(Stream stream, Encoding encoding = null);

    /// <summary>
    /// The current <see cref="ParserSettings"/>
    /// </summary>
    ParserSettings Settings { get; }
  }
}