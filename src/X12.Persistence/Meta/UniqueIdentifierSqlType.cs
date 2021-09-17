namespace X12.Persistence.Meta
{
  public class UniqueIdentifierSqlType : SqlDataType
  {
    public override string Render() => $"uniqueidentifier";
  }
}