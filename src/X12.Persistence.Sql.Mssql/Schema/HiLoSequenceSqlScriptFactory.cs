using System.Collections.Generic;
using System.Linq;
using DbUp.Engine;
using X12.Parsing.Specification;
using X12.Persistence.Meta;
using X12.Persistence.Meta.Property;
using X12.Persistence.Sql.Schema;

namespace X12.Persistence.Sql.Mssql.Schema
{
  public class HiLoSequenceSqlScriptFactory : IIdentityProviderScriptFactory
  {
    private readonly PropertyDataType _identityType;
    private readonly PersistenceOptions _options;
    private readonly IList<IndexSegmentSegmentType> _segmentTypes;

    public HiLoSequenceSqlScriptFactory(
      PersistenceOptions options,
      IIdentityProvider identityProvider,
      IList<SegmentSpecification> indexedSegments)
    {
      _options = options;
      _identityType = identityProvider.ToSqlDataType();
      _segmentTypes = indexedSegments.Select((x, i) => new IndexSegmentSegmentType(x, 1000 + i)).ToList();
    }

    public IList<SqlScript> CreateProviders() =>
      SegmentType
        .Ordered
        .Union(_segmentTypes)
        .Select(x => new HiLoSequenceProviderSqlScript(_options, _identityType, x))
        .Cast<SqlScript>()
        .ToList();
  }
}