namespace X12.Persistence.Meta.Property
{
  public class BinaryPropertyType : PropertyDataType
  {
    public override string Render() => $"varbinary(max)";
  }
}