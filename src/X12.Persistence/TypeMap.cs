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

    //public static explicit operator ColumnMetaBuilderTypeMap<SegmentType>(ColumnMetaBuilderTypeMap<TKey> specific) =>
    //  new ColumnMetaBuilderTypeMap<SegmentType>(specific.Value);

    //public static implicit operator ColumnMetaBuilderTypeMap<SegmentType>(ColumnMetaBuilderTypeMap<TKey> specific) =>
    //  new ColumnMetaBuilderTypeMap<SegmentType>(specific.Value);

    public IPropertyMetaBuilder Value { get; }
  }
}