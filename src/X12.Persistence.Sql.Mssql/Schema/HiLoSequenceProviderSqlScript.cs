using System.Text;
using DbUp.Engine;
using X12.Persistence.Meta;
using X12.Persistence.Meta.Property;

namespace X12.Persistence.Sql.Mssql.Schema
{
  public class HiLoSequenceProviderSqlScript : SqlScript
  {
    private readonly PropertyDataType _idType;
    private readonly SegmentType _segmentType;
    private readonly PersistenceOptions _sqlOptions;

    public HiLoSequenceProviderSqlScript(PersistenceOptions sqlOptions, PropertyDataType idType, SegmentType segmentType)
      : base(
        $"X12.Sql.Schema.Scripts._10.Templates.{nameof(HiLoSequenceProviderSqlScript)}.{idType.Render()}.{segmentType.Id}",
        null)
    {
      _sqlOptions = sqlOptions;
      _idType = idType;
      _segmentType = segmentType;
    }

    public override string Contents
    {
      get {
        var sb = new StringBuilder();
        sb.AppendLine($"create sequence [$x12_schema$].HiLoSequence_{_segmentType.Id} ");
        sb.AppendLine($"  as {_idType.Render()}");
        sb.AppendLine("    start with 1000000");
        sb.AppendLine($"    increment by {_sqlOptions.BatchSize}");
        sb.AppendLine("    minvalue 1000000");
        sb.AppendLine("    no cache;");
        return sb.ToString();
      }
    }
  }
}