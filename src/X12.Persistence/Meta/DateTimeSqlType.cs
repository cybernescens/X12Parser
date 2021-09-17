namespace X12.Persistence.Meta
{
  public class DateTimeSqlType : SqlDataType
  {
    public override string Render() => $"datetime";
  }
}