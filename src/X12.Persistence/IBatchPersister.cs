using System;
using System.Collections.Generic;
using System.Data;
using X12.Persistence.Meta;

namespace X12.Persistence
{
  public interface IBatchPersister : IDisposable
  {
    void Configure(IDisposable connection, SegmentType segmentType, IList<BatchPropertyMetadata> columnMetadata);
    long Persist(ISegmentBatch batch);
  }
}