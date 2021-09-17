using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PowerArgs;
using Serilog;
using Serilog.Events;

namespace X12.X12Parser
{
  public class Program
  {
    public static int Main(string[] args)
    {
      try
      {
        Host.CreateDefaultBuilder(args)
          .ConfigureAppConfiguration(
            (ctx, bld) => { bld.SetBasePath(ctx.HostingEnvironment.ContentRootPath); })
          .ConfigureServices(
            (ctx, services) => {
              var logger = new LoggerConfiguration()
                .Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty(
                  "Version",
                  FileVersionInfo.GetVersionInfo(typeof(ParserHostedService).Assembly.Location).FileVersion)
                .Enrich.WithDemystifiedStackTraces()
                .MinimumLevel.Is(LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.Console()
                #if RELEASE
                .WriteTo.File(EnsureLogPath())
                #endif
                .CreateLogger();

              Log.Logger = logger;

              services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(logger, true));

              logger.Warning($"Command: {Environment.CommandLine}");

              var parserInfo = Args.InvokeAction<ParserArgs>(args);

              logger.Information($"Going to execute command line action `{parserInfo.Args.Action}`");

              var cfg = new ConfigurationBuilder()
                .AddEnvironmentVariables("X12_")
                .AddJsonFile("settings.json", true)
                .Build();

              cfg.Bind(parserInfo.Args.ConfigurationSectionName, parserInfo.Args.Configuration);

              parserInfo.Args.ConfigureServices(services);

              services.AddSingleton(parserInfo.Args.Configuration);
              services.AddTransient(parserInfo.Args.Args.GetType());
              services.AddTransient(typeof(ParserCommand), parserInfo.Args.Command);
              services.AddHostedService<ParserHostedService>();
            })
          .RunConsoleAsync()
          .GetAwaiter()
          .GetResult();
      }
      catch (Exception e)
      {
        Log.Logger.Error(
          e,
          "Stopped program because of exception. " +
          "We are at the very root of the application.");

        return (int) ReturnCodes.FailedUnknown;
      }
      finally
      {
        Log.CloseAndFlush();
      }

      return Environment.ExitCode;
    }

    private static string EnsureLogPath()
    {
      var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "x12");
      Directory.CreateDirectory(dir);
      return Path.Combine(dir, $"x12parser_{DateTime.Now:yyyyMMddHHmmss}.log");
    }
  }
}