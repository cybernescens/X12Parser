namespace X12.Persistence.Meta
{
  public class DateSqlType : SqlDataType
  {
    public override string Render() => $"date";
  }
}