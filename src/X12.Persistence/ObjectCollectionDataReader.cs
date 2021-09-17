using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace X12.Persistence
{
  /// <summary>
  ///   A SQL Server based implementation of an <see cref="IDataReader" />
  /// </summary>
  public class ObjectCollectionDataReader : IDataReader
  {
    private readonly Func<object, object>[] values;
    private readonly IDictionary<string, int> ordinals;
    private readonly IDictionary<int, string> names;
    private IEnumerator enumerator;
    private readonly Type recordType;
    private bool disposed;

    /// <summary>
    /// Iterates over a file of parsed records
    /// </summary>
    public ObjectCollectionDataReader(IEnumerable collection, Type recordType)
    {
      /*
        Since we're potentially iterating over these millions of times,
        compiled expressions are a few magnitudes faster
        https://stackoverflow.com/questions/35805609/performance-of-expression-compile-vs-lambda-direct-vs-virtual-calls
      */
      this.recordType = recordType;

      var accessors = recordType
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.CanRead)
        .Select((p, i) => new {
          Index = i,
          Property = p,
          Accessor = CreatePropertyAccessor(p)
        })
        .ToArray();

      values = accessors.Select(x => x.Accessor).ToArray();
      ordinals = accessors.ToDictionary(x => x.Property.Name, x => x.Index);
      names = accessors.ToDictionary(x => x.Index, x => x.Property.Name);
      enumerator = collection.GetEnumerator();
      RecordsAffected = 0;
    }

    private Func<object, object> CreatePropertyAccessor(PropertyInfo pi)
    {
      var parameter = Expression.Parameter(typeof(object), "input");
      var castAsObject = Expression.TypeAs(
        Expression.Property(Expression.TypeAs(parameter, recordType), pi), 
        typeof(object));

      return Expression.Lambda<Func<object, object>>(castAsObject, parameter).Compile();
    }

    /// <inheritdoc />
    public int FieldCount => values.Length;

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
      if (enumerator == null)
        throw new ObjectDisposedException(nameof(ObjectCollectionDataReader));

      RecordsAffected++;
      var next = enumerator.MoveNext();
      if (!next) Close();
      return next;
    }

    /// <inheritdoc />
    public bool IsClosed => enumerator == null;

    /// <inheritdoc />
    public void Close()
    {
      this.Dispose();
    }

    /// <inheritdoc />
    public int GetOrdinal(string name)
    {
      if (ordinals.TryGetValue(name, out var index))
        return index;

      throw new InvalidOperationException($"Unknown Property: `{name}`");
    }

    /// <inheritdoc />
    public object GetValue(int i)
    {
      if (enumerator == null)
        throw new ObjectDisposedException(nameof(ObjectCollectionDataReader));

      return values[i](enumerator.Current);
    }

    private void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      
      enumerator = null;
      disposed = true;
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

    public string GetName(int i) => i > ordinals.Count ? throw new InvalidOperationException($"No property for index `{i}`") : names[i];

    public string GetString(int i) => throw new NotImplementedException();

    public int GetValues(object[] values) => throw new NotImplementedException();

    public bool IsDBNull(int i) => GetValue(i) == null;

    #endregion
  }
}