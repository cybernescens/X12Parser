namespace X12.Persistence.Meta
{
  public class TimeSqlType : SqlDataType
  {
    public override string Render() => $"time";
  }
}