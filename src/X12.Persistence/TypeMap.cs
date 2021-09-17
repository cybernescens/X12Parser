using X12.Persistence.Meta;

namespace X12.Persistence
{
  internal interface IColumnMetaBuilderTypeMap<out TKey>
  {
    IColumnMetaBuilder Value { get; }
  }

  internal class ColumnMetaBuilderTypeMap<TKey> : IColumnMetaBuilderTypeMap<TKey>
    where TKey : SegmentType
  {
    public ColumnMetaBuilderTypeMap(IColumnMetaBuilder value) { Value = value; }

    //public static explicit operator ColumnMetaBuilderTypeMap<SegmentType>(ColumnMetaBuilderTypeMap<TKey> specific) =>
    //  new ColumnMetaBuilderTypeMap<SegmentType>(specific.Value);

    //public static implicit operator ColumnMetaBuilderTypeMap<SegmentType>(ColumnMetaBuilderTypeMap<TKey> specific) =>
    //  new ColumnMetaBuilderTypeMap<SegmentType>(specific.Value);

    public IColumnMetaBuilder Value { get; }
  }
}