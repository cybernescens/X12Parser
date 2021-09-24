namespace X12.Persistence.Meta.Property
{
  public class PropertyName : IPropertyMetadata
  {
    public string Name { get; }

    public PropertyName(string name) { Name = name; }

    public string Render() => $"[{Name}]";
  }
}