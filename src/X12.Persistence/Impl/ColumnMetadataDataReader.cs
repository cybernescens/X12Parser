using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using X12.Persistence.Meta;
using X12.Persistence.Model;

namespace X12.Persistence.Impl
{
  public class ColumnMetadataDataReader : IDataReader
  {
    private IDictionary<string, int> _ordinals;
    private Func<IndexedSegmentEntity, object>[] _values;
    private IEnumerator<IndexedSegmentEntity> _enumerator;
    private bool _disposed;
    private readonly string[] _names;

    public ColumnMetadataDataReader(
      ICollection<IndexedSegmentEntity> items,
      IList<ColumnMetadata> columnMetadata)
    {
      _enumerator = items.GetEnumerator();
      _ordinals = columnMetadata
        .Select((x, i) => (ColumnMetadata: x, Index: i))
        .ToDictionary(x => x.ColumnMetadata.Segment.Name, x => x.Index);

      _names = columnMetadata
        .Select((x, i) => (ColumnMetadata: x, Index: i))
        .OrderBy(x => x.Index)
        .Select(x => x.ColumnMetadata.Segment.Name)
        .ToArray();

      _values = columnMetadata
        .Select((x, i) => (ColumnMetadata: x, Index: i))
        .OrderBy(x => x.Index)
        .Select(x => x.ColumnMetadata.ValueFunction)
        .ToArray();
    }

    /// <inheritdoc />
    public int FieldCount => _values.Length;

    /// <summary>
    /// this will throw a NotImplemented exception. I left it here because if we did this a
    /// little differently then we could support this, as files are parsed we could
    /// utilize next result to iterate
    /// </summary>
    /// <returns></returns>
    public bool NextResult() => throw new NotImplementedException("NextResult is currently not supported");

    /// <inheritdoc />
    public bool Read()
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      if (_enumerator == null)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      RecordsAffected++;
      var next = _enumerator.MoveNext();
      if (!next) Close();
      return next;
    }

    /// <inheritdoc />
    public bool IsClosed => _enumerator == null;

    /// <inheritdoc />
    public void Close()
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      this.Dispose();
    }

    /// <inheritdoc />
    public int GetOrdinal(string name)
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      if (_ordinals.TryGetValue(name, out var index))
        return index;

      throw new InvalidOperationException($"Unknown Property: `{name}`");
    }

    /// <inheritdoc />
    public object GetValue(int i)
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      if (_enumerator == null)
        throw new ObjectDisposedException(nameof(ColumnMetadataDataReader));

      return _values[i](_enumerator.Current);
    }

    private void Dispose(bool disposing)
    {
      if (!disposing)
        return;

      if (_disposed)
        return;
      
      _ordinals.Clear();
      _ordinals = null;
      _values = null;
      _enumerator = null;
      _disposed = true;
    }

    /// <inheritdoc />
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #region Not Necessary for SqlBulkCopy (IDataReader)

    public int Depth { get; }

    public DataTable GetSchemaTable() => throw new NotImplementedException();

    public int RecordsAffected { get; private set; }

    #endregion

    #region Not Necessary for SqlBulkCopy (IDataRecord)

    public object this[int i] => GetValue(i);

    public object this[string name] => GetValue(GetOrdinal(name));

    public bool GetBoolean(int i) => throw new NotImplementedException();

    public byte GetByte(int i) => throw new NotImplementedException();

    public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => throw new NotImplementedException();

    public char GetChar(int i) => throw new NotImplementedException();

    public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => throw new NotImplementedException();

    public IDataReader GetData(int i) => throw new NotImplementedException();

    public string GetDataTypeName(int i) => throw new NotImplementedException();

    public DateTime GetDateTime(int i) => throw new NotImplementedException();

    public decimal GetDecimal(int i) => throw new NotImplementedException();

    public double GetDouble(int i) => throw new NotImplementedException();

    public Type GetFieldType(int i) => throw new NotImplementedException();

    public float GetFloat(int i) => throw new NotImplementedException();

    public Guid GetGuid(int i) => throw new NotImplementedException();

    public short GetInt16(int i) => throw new NotImplementedException();

    public int GetInt32(int i) => throw new NotImplementedException();

    public long GetInt64(int i) => throw new NotImplementedException();

    public string GetName(int i) => i > _ordinals.Count ? throw new InvalidOperationException($"No property for index `{i}`") : _names[i];

    public string GetString(int i) => throw new NotImplementedException();

    public int GetValues(object[] values) => throw new NotImplementedException();

    public bool IsDBNull(int i) => GetValue(i) == null;

    #endregion
  }
}