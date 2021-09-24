using System;
using Microsoft.Extensions.DependencyInjection;
using X12.Parsing;

namespace X12.Config
{
  public class ParserConfiguration : IParserConfiguration
  {
    public static readonly ParserConfiguration Default = new();

    private IServiceProvider ServiceProvider { get; set; }

    public ParserSettings ParserSettings { get; } = ParserSettings.Default;
    
    public IX12Parser CreateParser()
    {
      ServiceProvider = Apply().BuildServiceProvider();
      return ServiceProvider.GetRequiredService<IX12Parser>();
    }

    protected virtual IServiceCollection Apply(IServiceCollection sc = null)
    {
      sc ??= new ServiceCollection();
      sc.AddSingleton(ParserSettings);
      sc.AddTransient<IX12Parser, X12Parser>();
      return sc;
    }
    
    public virtual ParserConfiguration Parser(Action<ParserSettings> config)
    {
      config(ParserSettings);
      return this;
    }
  }
  
  public interface IParserConfiguration
  {
    IX12Parser CreateParser();
  }
}