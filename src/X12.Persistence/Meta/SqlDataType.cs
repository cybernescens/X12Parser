namespace X12.Persistence.Meta
{
  public abstract class SqlDataType : IColumnProperty
  {
    public abstract string Render();
  }
}