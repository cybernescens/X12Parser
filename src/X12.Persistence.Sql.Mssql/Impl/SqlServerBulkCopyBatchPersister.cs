using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using X12.Persistence.Meta;

namespace X12.Persistence.Sql.Mssql
{
  public class SqlServerBulkCopyBatchPersister : IBatchPersister
  {
    private const int TenPercentOfBatch = 10;
    private readonly int _batchSize;
    private readonly string _schemaName;
    private SqlBulkCopy _bulkCopier;
    private long _totalRows;
    private bool _configured;
    private readonly ILogger<SqlServerBulkCopyBatchPersister> _logger;
    
    private static readonly BindingFlags npi = BindingFlags.NonPublic | BindingFlags.Instance;
    private static readonly BindingFlags pnpi = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    public SqlServerBulkCopyBatchPersister(PersistenceOptions options, ILoggerFactory lf)
    {
      _schemaName = options.Schema;
      _batchSize = options.BatchSize;
      _totalRows = 0;
      _configured = false;
      _logger = lf.CreateLogger<SqlServerBulkCopyBatchPersister>();
    }

    public void Dispose()
    {
      //_bulkCopier = null;
    }

    public void Configure(IDisposable connection, SegmentType segmentType, IList<BatchPropertyMetadata> columnMetadata)
    {
      var proxy = (SqlConnectionProxy)connection;
      _bulkCopier = new SqlBulkCopy(proxy.Connection, SqlBulkCopyOptions.TableLock, proxy.CurrentTransaction);
      _bulkCopier.BatchSize = _batchSize;
      _bulkCopier.BulkCopyTimeout = 0;
      _bulkCopier.NotifyAfter = _batchSize / TenPercentOfBatch;
      _bulkCopier.SqlRowsCopied += (_, args) => {
        _totalRows += args.RowsCopied;
        _logger.LogInformation($"Copied `{_totalRows} total `{segmentType.Id}` records.");
      };

      columnMetadata
        .ToList()
        .ForEach(x => _bulkCopier.ColumnMappings.Add(x.Segment.Name, x.Segment.Name));

      _bulkCopier.DestinationTableName = $"[{_schemaName}].[{segmentType.Id}]";
      _configured = true;
    }

    public long Persist(ISegmentBatch batch)
    {
      if (!_configured)
        throw new NotImplementedException(
          "BatchPersister has not been configured. Please call " +
          "`Configure(SegmentType segmentType, IList<ColumnMetadata> columnMetadata)`.");

      using var reader = batch.GetDataReader();

      try
      {
        _bulkCopier.WriteToServer(reader);
        return _totalRows;
      }
      catch (SqlException ex)
      {
        _logger.LogWarning(ex, "Interpreting SQL Bulk Copy Exception");
        if (ex.Message.Contains("Received an invalid column length from the bcp client"))
        {
          var match = Regex.Match(ex.Message, @"\d+");
          var index = Convert.ToInt32(match.Value) - 1;
          var fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", npi);
          var sortedColumns = fi.GetValue(_bulkCopier);
          var items = sortedColumns.GetType().GetField("_items", npi).GetValue(sortedColumns) as object[];
          var itemdata = items[index].GetType().GetField("_metadata", npi);
          var metadata = itemdata.GetValue(items[index]);
          var column = metadata.GetType().GetField("column", pnpi).GetValue(metadata);
          var length = metadata.GetType().GetField("length", pnpi).GetValue(metadata);

          reader.Close();
          //tx.Rollback();
          throw new Exception($"Column: {_bulkCopier.DestinationTableName}.{column} contains data with a length greater than: {length}");
        }

        reader.Close();
        //tx.Rollback();
        throw;
      }
    }
  }
}