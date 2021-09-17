using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using X12.Persistence.Impl;
using X12.Persistence.Meta;
using X12.Persistence.Model;

namespace X12.Persistence.Batch
{
  public abstract class SegmentBatch : ISegmentBatch
  {
    private readonly Type _type;
    private readonly ICollection<object> _items;

    public SegmentBatch(Type type)
    {
      _type = type;
      _items = new Collection<object>();
    }

    IDataReader ISegmentBatch.GetDataReader() => new ObjectCollectionDataReader(_items, _type);
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    void ISegmentBatch.Add(object o) => _items.Add(o);
    public void Clear() => _items.Clear();
  }

  public class FileSegmentBatch : SegmentBatch
  {
    public FileSegmentBatch() : base(typeof(FileEntity)) { }
  }

  public class InterchangeSegmentBatch : SegmentBatch
  {
    public InterchangeSegmentBatch() : base(typeof(InterchangeEntity)) { }
  }

  public class FunctionGroupSegmentBatch : SegmentBatch
  {
    public FunctionGroupSegmentBatch() : base(typeof(FunctionalGroupEntity)) { }
  }

  public class TransactionSetSegmentBatch : SegmentBatch
  {
    public TransactionSetSegmentBatch() : base(typeof(TransactionSetEntity)) { }
  }

  public class LoopSegmentBatch : SegmentBatch
  {
    public LoopSegmentBatch() : base(typeof(LoopEntity)) { }
  }

  public class SegmentSegmentBatch : SegmentBatch
  {
    public SegmentSegmentBatch() : base(typeof(SegmentEntity)) { }
  }

  public class ParsingErrorSegmentBatch : SegmentBatch
  {
    public ParsingErrorSegmentBatch() : base(typeof(ParsingErrorEntity)) { }
  }

  public class IndexedSegmentBatch : ISegmentBatch
  {
    private readonly string _segmentId;
    private readonly IList<ColumnMetadata> _columns;
    private readonly ICollection<IndexedSegmentEntity> _items;

    public IndexedSegmentBatch(string segmentId, IList<ColumnMetadata> columns)
    {
      _segmentId = segmentId;
      _columns = columns;
      _items = new Collection<IndexedSegmentEntity>();
    }

    public IEnumerator GetEnumerator() => _items.GetEnumerator();
    public IDataReader GetDataReader() => new ColumnMetadataDataReader(_items, _columns);
    public void Clear() => _items.Clear();

    public void Add(object o)
    {
      if (o.GetType() != typeof(IndexedSegmentEntity))
        throw new InvalidOperationException($"Argument `o` must be of type {typeof(IndexedSegmentEntity).FullName}");

      var ise = (IndexedSegmentEntity)o;
      var iseSegmentId = ise.GetSegmentId();
      if (iseSegmentId != _segmentId)
        throw new InvalidOperationException(
          $"IndexedSegmentEntity `o` has SegmentId `{iseSegmentId}` and expects `{_segmentId}`.");

      _items.Add(ise);
    }

  }
}