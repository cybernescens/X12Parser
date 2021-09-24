using X12.Persistence.Meta;

namespace X12.Persistence
{
  internal interface IPropertyMetaBuilderTypeMap<out TKey>
  {
    IPropertyMetaBuilder Value { get; }
  }

  internal class PropertyMetaBuilderTypeMap<TKey> : IPropertyMetaBuilderTypeMap<TKey>
    where TKey : SegmentType
  {
    public PropertyMetaBuilderTypeMap(IPropertyMetaBuilder value) { Value = value; }
    
    public IPropertyMetaBuilder Value { get; }
  }
}