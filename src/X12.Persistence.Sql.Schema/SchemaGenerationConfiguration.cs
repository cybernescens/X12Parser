using DbUp.Engine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using X12.Persistence.Config;

namespace X12.Persistence.Sql.Schema
{
  public class SchemaGenerationConfiguration : PersistenceConfiguration, ISchemaGenerationConfiguration
  {
    public static SchemaGenerationConfiguration Schema => new();

    public SchemaGenerationConfiguration()
    {
      BatchPersisterConfigurationRequired = false;
      PersistenceSessionConfigurationRequired = false;
    }

    public SchemaGenerationOptionsConfiguration SchemaGenerationOptionsConfiguration { get; set; }

    public ISchemaGenerator Prepare()
    {
      VerifyGenerate();
      ServiceProvider = Apply().BuildServiceProvider();

      using var scope = ServiceProvider.CreateScope();
      return scope.ServiceProvider.GetRequiredService<ISchemaGenerator>();
    }

    protected override IServiceCollection Apply(IServiceCollection sc = null)
    {
      sc ??= new ServiceCollection();
      SchemaGenerationOptionsConfiguration.Apply(sc);
      sc.AddScoped<ISchemaGenerator, SchemaGenerator>();
      base.Apply(sc);

      /* add this if nothing else has been registered for this service */
      sc.TryAddSingleton<IIdentityProviderScriptFactory, DefaultIdentityProviderScriptFactory>();
      return sc;
    }

    protected void VerifyGenerate()
    {
      if (SchemaGenerationOptionsConfiguration == null)
        throw new X12PersistenceConfigurationException(
          $"{nameof(SchemaGenerationOptionsConfiguration)} has not been configured.");

      Verify();
    }
    
    public SchemaGenerationConfiguration SchemaOptions(SchemaGenerationOptionsConfiguration config)
    {
      SchemaGenerationOptionsConfiguration = config;
      return this;
    }
  }

  public static class SchemaGenerationConfigurationExtensions
  {
    public static ISchemaGenerator Prepare(this PersistenceConfiguration config) =>
      ((ISchemaGenerationConfiguration)config).Prepare();
  }
}