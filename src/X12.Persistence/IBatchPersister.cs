using System;
using System.Collections.Generic;
using System.Data;
using X12.Persistence.Meta;

namespace X12.Persistence
{
  public interface IBatchPersister : IDisposable
  {
    void Configure(IDisposable disposable, SegmentType segmentType, IList<ColumnMetadata> columnMetadata);
    long Persist(ISegmentBatch batch);
  }
}