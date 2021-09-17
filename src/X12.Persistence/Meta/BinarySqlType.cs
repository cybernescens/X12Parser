namespace X12.Persistence.Meta
{
  public class BinarySqlType : SqlDataType
  {
    public override string Render() => $"varbinary";
  }
}