using NUnit.Framework;
using Serilog;
using Serilog.Events;

[SetUpFixture]
public class LoggingSetup
{
  [OneTimeSetUp]
  public void InitializeLogging()
  {
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Is(LogEventLevel.Debug)
      .WriteTo.Debug()
      .WriteTo.NUnitOutput()
      .CreateLogger();
  }

  [OneTimeTearDown]
  public void TearDown() { Log.CloseAndFlush(); }
}