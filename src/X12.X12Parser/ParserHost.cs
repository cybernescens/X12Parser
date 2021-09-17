using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace X12.X12Parser
{
  internal class ParserHostedService : IHostedService
  {
    private readonly ParserCommand command;
    private CancellationTokenSource cts;
    private Task<int> task;

    public ParserHostedService(ParserCommand command) { this.command = command; }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
      task = command.Execute(cts.Token);
      return task.IsCompleted ? task : Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
      if (task == null)
      {
        Environment.ExitCode = (int) ReturnCodes.NoTaskInitiated;
        return;
      }

      // Signal cancellation to the executing method
      cts.Cancel();

      // Wait until the task completes or the stop token triggers
      await Task.WhenAny(task, Task.Delay(-1, cancellationToken));

      // Throw if cancellation triggered
      cancellationToken.ThrowIfCancellationRequested();
    }
  }
}