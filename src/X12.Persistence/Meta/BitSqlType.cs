namespace X12.Persistence.Meta
{
  public class BitSqlType : SqlDataType
  {
    public override string Render() => $"bit";
  }
}