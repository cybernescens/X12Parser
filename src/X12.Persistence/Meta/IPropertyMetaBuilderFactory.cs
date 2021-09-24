namespace X12.Persistence.Meta
{
  public interface IPropertyMetaBuilderFactory
  {
    IPropertyMetaBuilder Resolve<T>(T? @object = null) where T : SegmentType;
  }
}