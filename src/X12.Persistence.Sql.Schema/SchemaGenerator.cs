using System.Collections.Generic;
using System.Linq;
using DbUp;
using DbUp.Engine;
using X12.Parsing.Specification;
using X12.Persistence.Meta;
using X12.Persistence.Sql.Schema.Scripts._10.Templates;

namespace X12.Persistence.Sql.Schema
{
  public interface ISchemaGenerator
  {
    DatabaseUpgradeResult Upgrade();
  }

  public class SchemaGenerator : ISchemaGenerator
  {
    private readonly string _schema;
    private readonly ISchemaGenerationConfigurer _configurer;
    private readonly IIdentityProvider _identityProvider;
    private readonly IColumnMetaBuilderFactory _metaBuilderFactory;
    private readonly IIdentityProviderScriptFactory _identityProviderScriptFactory;
    private readonly IList<SegmentSpecification> _segments;

    public SchemaGenerator(
      ISchemaGenerationConfigurer configurer,
      PersistenceOptions options, 
      IIdentityProvider identityProvider, 
      IColumnMetaBuilderFactory metaBuilderFactory,
      IIdentityProviderScriptFactory identityProviderScriptFactory,
      IList<SegmentSpecification> segments)
    {
      _schema = options.Schema;
      _configurer = configurer;
      _identityProvider = identityProvider;
      _metaBuilderFactory = metaBuilderFactory;
      _identityProviderScriptFactory = identityProviderScriptFactory;
      _segments = segments;
    }

    public DatabaseUpgradeResult Upgrade()
    {
      var it = _identityProvider.ToSqlDataType();

      var b = _configurer.Database(DeployChanges.To)
        .WithScriptsEmbeddedInAssembly(typeof(SchemaGenerator).Assembly)
        .WithScriptsEmbeddedInAssembly(_configurer.GetType().Assembly);

      SegmentType.Ordered
        .Select(x => new AnnotatedTypeSqlScript(x, _metaBuilderFactory.Resolve(x).Describe(x.EntityType)))
        .ToList()
        .ForEach(x => b.WithScript(x));

      _segments
        .Select(
          x => new IndexedSegmentTableScript(
            x.SegmentId, 
            _metaBuilderFactory.Resolve<IndexSegmentSegmentType>().Describe(x)))
        .ToList()
        .ForEach(x => b.WithScript(x));
        
      _identityProviderScriptFactory
        .CreateProviders()
        .ToList()
        .ForEach(x => b.WithScript(x));

      return b
        .WithVariable("x12_schema", _schema)
        .WithVariable("identity", it.Render())
        .LogToConsole()
        .LogToAutodetectedLog()
        .Build()
        .PerformUpgrade();
    }
  }
}