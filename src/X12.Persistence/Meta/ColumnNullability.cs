namespace X12.Persistence.Meta
{
  public class ColumnNullability : IColumnProperty
  {
    public bool Nullable { get; }

    public ColumnNullability(bool nullable) { Nullable = nullable; }

    public string Render() => Nullable ? "null" : "not null";
  }
}