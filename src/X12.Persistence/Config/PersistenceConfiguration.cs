using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using X12.Config;
using X12.Parsing;
using X12.Persistence.File;
using X12.Persistence.Impl;

namespace X12.Persistence.Config
{
  public class PersistenceConfiguration : ParserConfiguration, IPersistenceConfiguration
  {
    public new static PersistenceConfiguration Default => new();

    private IServiceProvider ServiceProvider { get; set; }
    protected bool BatchPersisterConfigurationRequired { get; init; } = true;
    protected bool PersistenceSessionConfigurationRequired { get; init; } = true;

    public Action<ILoggingBuilder> LoggingConfiguration { get; set; }
    public ParserConfiguration ParserConfiguration { get; set; } = ParserConfiguration.Default;
    public PersistenceOptionsConfiguration PersistenceOptionsConfiguration { get; set; } = PersistenceOptionsConfiguration.Default;
    public PersistenceSessionConfiguration PersistenceSessionConfiguration { get; set; }
    public ConnectionManagerConfiguration ConnectionManagerConfiguration { get; set; }
    public IdentityProviderConfiguration IdentityProviderConfiguration { get; set; }
    public IndexedSegmentConfiguration IndexedSegmentsConfiguration { get; set; }
    public PropertyMetaBuilderConfiguration PropertyMetaBuilderConfiguration { get; set; } = PropertyMetaBuilderConfiguration.Default;
    public BatchPersisterConfiguration BatchPersisterConfiguration { get; set; } 

    public IPersistenceSessionFactory Build()
    {
      Verify();
      ServiceProvider = Apply().BuildServiceProvider();
      return ServiceProvider.GetRequiredService<IPersistenceSessionFactory>();
    }
    
    protected void Verify()
    {
      if (LoggingConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(LoggingConfiguration)} has not been configured.");

      if (ParserConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(ParserConfiguration)} has not been configured.");

      if (PersistenceOptionsConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(PersistenceOptionsConfiguration)} has not been configured.");

      if (PersistenceSessionConfigurationRequired && PersistenceSessionConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(PersistenceSessionConfiguration)} has not been configured.");

      if (ConnectionManagerConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(ConnectionManagerConfiguration)} has not been configured.");

      if (IdentityProviderConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(IdentityProviderConfiguration)} has not been configured.");

      if (IndexedSegmentsConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(IndexedSegmentsConfiguration)} has not been configured.");

      if (PropertyMetaBuilderConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(PropertyMetaBuilderConfiguration)} has not been configured.");

      if (BatchPersisterConfigurationRequired && BatchPersisterConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(BatchPersisterConfiguration)} has not been configured.");
    }

    protected override IServiceCollection Apply(IServiceCollection? sc = null)
    {
      sc ??= new ServiceCollection();
      
      base.Apply(sc);

      PersistenceOptionsConfiguration.Apply(sc);
      PersistenceSessionConfiguration?.Apply(sc);
      ConnectionManagerConfiguration?.Apply(sc);
      IdentityProviderConfiguration.Apply(sc);
      IndexedSegmentsConfiguration.Apply(sc);
      PropertyMetaBuilderConfiguration.Apply(sc);
      BatchPersisterConfiguration?.Apply(sc);
      
      sc.AddLogging(LoggingConfiguration);
      sc.AddSingleton<IFileHashService, SHA384FileHashService>();
      sc.AddSingleton<IPersistenceSessionFactory, PersistenceSessionFactory>();
      sc.AddScoped<PersistenceSession, PersistenceSession>();
      
      sc.AddScoped<IIdentifiablePersistenceSession, PersistenceSession>(
        sp => sp.GetRequiredService<PersistenceSession>());

      sc.AddScoped<IPersistenceSession, PersistenceSession>(
        sp => sp.GetRequiredService<PersistenceSession>());

      return sc;
    }

    public PersistenceConfiguration Logging(Action<ILoggingBuilder> config)
    {
      LoggingConfiguration = config;
      return this;
    }
    
    public PersistenceConfiguration Options(
      PersistenceOptionsConfiguration config,
      Action<PersistenceOptionsConfiguration> action = null)
    {
      PersistenceOptionsConfiguration = config;
      action?.Invoke(PersistenceOptionsConfiguration);
      return this;
    }

    public PersistenceConfiguration Session(PersistenceSessionConfiguration config)
    {
      PersistenceSessionConfiguration = config;
      return this;
    }

    public PersistenceConfiguration ConnectionManager(ConnectionManagerConfiguration config)
    {
      ConnectionManagerConfiguration = config;
      return this;
    }

    public PersistenceConfiguration IdentityProvider(IdentityProviderConfiguration config)
    {
      IdentityProviderConfiguration = config;
      return this;
    }

    public PersistenceConfiguration IndexedSegments(IndexedSegmentConfiguration config)
    {
      IndexedSegmentsConfiguration = config;
      return this;
    }

    public PersistenceConfiguration ColumnMetaBuilder(PropertyMetaBuilderConfiguration config)
    {
      PropertyMetaBuilderConfiguration = config;
      return this;
    }

    public PersistenceConfiguration BatchPersister(BatchPersisterConfiguration config)
    {
      BatchPersisterConfiguration = config;
      return this;
    }

    public override PersistenceConfiguration Parser(Action<ParserSettings> action)
    {
      action(ParserSettings);
      return this;
    }
  }
}