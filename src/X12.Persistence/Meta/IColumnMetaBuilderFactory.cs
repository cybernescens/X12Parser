using System;

namespace X12.Persistence.Meta
{
  public interface IColumnMetaBuilderFactory
  {
    IColumnMetaBuilder Resolve(SegmentType segmentType);
    IColumnMetaBuilder Resolve<T>() where T : SegmentType;
  }
}