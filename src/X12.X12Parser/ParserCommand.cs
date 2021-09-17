using System.Threading;
using System.Threading.Tasks;

namespace X12.X12Parser
{
  /// <summary>
  /// Default Implementation for available X12 Command Line Actions
  /// </summary>
  internal abstract class ParserCommand
  {
    /// <summary>
    /// The implementation of the command line action
    /// </summary>
    /// <param name="ct">the <see cref="CancellationToken"/></param>
    /// <returns>an awaitable task that ultimately returns an integer return code</returns>
    public abstract Task<int> Execute(CancellationToken ct);
  }
}