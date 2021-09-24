using System;
using System.Collections.Generic;
using X12.Persistence.Meta;

namespace X12.Persistence.File.Raw
{
  public class RawFileBatchPersister : IBatchPersister
  {
    public void Configure(IDisposable connection /* the connection manager */, SegmentType segmentType, IList<BatchPropertyMetadata> columnMetadata)
    {
      throw new NotImplementedException();
    }

    public long Persist(ISegmentBatch batch) => throw new NotImplementedException();

    public void Dispose() { throw new NotImplementedException(); }
  }
}