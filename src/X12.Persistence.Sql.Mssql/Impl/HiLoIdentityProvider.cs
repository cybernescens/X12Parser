using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using X12.Persistence.Meta;
using X12.Persistence.Meta.Property;
using X12.Persistence.Util;

namespace X12.Persistence.Sql.Mssql
{
  public abstract class HiLoIdentityProvider<T> : IIdentityProvider where T : IComparable
  {
    private readonly AsyncLock _asyncLock = new();
    private readonly string _schemaName;
    private readonly int _batchSize;
    private readonly int _retries;
    private readonly IDictionary<string, Ids> _ids = new Dictionary<string, Ids>();
    private readonly string _connectionString;
    private readonly ILogger<HiLoIdentityProvider<T>> _logger;

    protected HiLoIdentityProvider(PersistenceOptions options, DbConnectionStringBuilder connectionStringBuilder, ILoggerFactory lf)
    {
      if (!(typeof(T) == typeof(long) || typeof(T) == typeof(int)))
        throw new InvalidOperationException($"Generic constraint `T` is `{typeof(T).Name}` and expected to be of type `long` or `int`");

      _connectionString = connectionStringBuilder.ConnectionString;
      _schemaName = options.Schema;
      _batchSize = options.BatchSize;
      _retries = options.Retries;
      _logger = lf.CreateLogger<HiLoIdentityProvider<T>>();
    }

    public abstract PropertyDataType ToSqlDataType();
    protected abstract T ConvertResult(object o);
    protected abstract bool IsLessThan(T a, T b);
    protected abstract T Increment(ref Ids id);
    protected abstract void ConfigureId(ref Ids id, T hi, int lo);

    protected string GetSql(string segmentId) =>
      $"select next value for [{_schemaName}].HiLoSequence_{segmentId} as NextId";

    public object NextId(SegmentType segment)
    {
      using (_asyncLock.Lock())
      {
        if (!_ids.ContainsKey(segment.Id))
          _ids.Add(segment.Id, new Ids());

        var id = _ids[segment.Id];

        if (IsLessThan(id.NextId, id.MaxId))
          return Increment(ref id);

        _logger.LogInformation($"Out of IDs in batch, requesting next hi for table `{segment.Id}`");

        for (var retry = 1; retry < _retries; retry++)
        {
          try
          {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();
            conn.Open();

            using var tx = conn.BeginTransaction(IsolationLevel.Serializable);
            cmd.CommandText = GetSql(segment.Id);
            cmd.Transaction = tx;
            var resultValue = cmd.ExecuteScalar();
            tx.Commit();

            var idValue = ConvertResult(resultValue);
            _logger.LogInformation($"Next hi for table `{segment.Id}` is `{idValue}`.");
            ConfigureId(ref id, idValue, _batchSize);
            return id.NextId;
          }
          catch (Exception e)
          {
            _logger.LogWarning(e, $"Error encountered fetching next hi ID for table `{segment.Id}`");
            if (retry >= _retries)
              throw;

            Task.Delay(new Random().Next(50, 200)).GetAwaiter().GetResult();
          }
        }
      }

      return default(T);
    }

    protected class Ids
    {
      public T NextId;
      public T MaxId;
    }
  }
}