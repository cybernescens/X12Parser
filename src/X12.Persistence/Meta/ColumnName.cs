namespace X12.Persistence.Meta
{
  public class ColumnName : IColumnProperty
  {
    public string Name { get; }

    public ColumnName(string name) { Name = name; }

    public string Render() => $"[{Name}]";
  }
}