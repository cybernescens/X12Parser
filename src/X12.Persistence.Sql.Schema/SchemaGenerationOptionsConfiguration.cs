using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Sql.Schema
{
  public abstract class SchemaGenerationOptionsConfiguration
  {
    public ISchemaGenerationConfigurer SchemaGenerationConfigurer { get; set; }

    public SchemaGenerationOptionsConfiguration WithConfigurer(ISchemaGenerationConfigurer configurer)
    {
      SchemaGenerationConfigurer = configurer;
      return this;
    }

    public abstract IServiceCollection Apply(IServiceCollection sc);
  }
}