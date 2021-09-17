using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using DbUp.Engine;
using X12.Persistence.Meta;

namespace X12.Persistence.Sql.Schema.Scripts._10.Templates
{
  public class AnnotatedTypeSqlScript : SqlScript
  {
    private readonly SegmentType _segmentType;
    private readonly IList<ColumnMetadata> _columnMetadata;

    public AnnotatedTypeSqlScript(
      SegmentType segmentType,
      IList<ColumnMetadata> columnMetadata,
      SqlScriptOptions sqlScriptOptions = null) 
      : base($"{typeof(AnnotatedTypeSqlScript).Namespace}._{segmentType.Priority:D2}.{segmentType.Id}", null, sqlScriptOptions)
    {
      _segmentType = segmentType;
      _columnMetadata = columnMetadata;
    }

    public override string Contents
    {
      get {
        var ids = _segmentType
          .EntityType
          .GetProperties(BindingFlags.Instance | BindingFlags.Public)
          .Where(x => x.GetCustomAttributes<KeyAttribute>().Any())
          .Select(x => x.Name)
          .ToArray();

        var sb = new StringBuilder();
        sb.AppendLine($"create table [$x12_schema$].[{_segmentType.Id}] (");
        _columnMetadata.ToList().ForEach(x => sb.AppendLine($"  {x.Render()},"));
        sb.AppendLine($"  constraint [PK__{_segmentType.Id}] primary key clustered ({string.Join(",", ids)})");
        sb.AppendLine(")");
        return sb.ToString();
      }
    }
  }
}