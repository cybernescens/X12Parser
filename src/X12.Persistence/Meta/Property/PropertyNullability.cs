namespace X12.Persistence.Meta.Property
{
  public class PropertyNullability : IPropertyMetadata
  {
    public bool Nullable { get; }

    public PropertyNullability(bool nullable) { Nullable = nullable; }

    public string Render() => Nullable ? "null" : "not null";
  }
}