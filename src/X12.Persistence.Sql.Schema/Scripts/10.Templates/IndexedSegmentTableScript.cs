using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUp.Engine;
using X12.Persistence.Meta;

namespace X12.Persistence.Sql.Schema.Scripts._10.Templates
{
  internal class IndexedSegmentTableScript : SqlScript
  {
    private readonly IList<BatchPropertyMetadata> columnMetadata;
    private readonly string segment;

    public IndexedSegmentTableScript(
      string segment,
      IList<BatchPropertyMetadata> columnMetadata,
      SqlScriptOptions sqlScriptOptions = null)
      : base($"{typeof(IndexedSegmentTableScript).Namespace}._1000.{segment}", null, sqlScriptOptions)
    {
      this.segment = segment;
      this.columnMetadata = columnMetadata;
    }

    public override string Contents
    {
      get {
        var sb = new StringBuilder();
        sb.AppendLine($"create table [$x12_schema$].[{segment}] (");
        columnMetadata.ToList().ForEach(x => sb.AppendLine($"  {x.Render()},"));
        sb.AppendLine($"  constraint [PK__{segment}] primary key clustered (Id)");
        sb.AppendLine(")");
        sb.AppendLine();
        sb.AppendLine($"create nonclustered index IDX__{segment}__IsaPosition on [$x12_schema$].[{segment}]");
        sb.AppendLine("  (InterchangeId, PositionInInterchange)");
        return sb.ToString();
      }
    }
  }
}