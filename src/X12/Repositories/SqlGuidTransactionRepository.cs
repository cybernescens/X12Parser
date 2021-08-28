using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using X12.Parsing;
using X12.Parsing.Model;

namespace X12.Repositories
{
  /// <summary>
  ///   Uses a Guid for all identity columns,
  ///   batches the inserts of loops and segments,
  ///   and allows for an overridable method for creating new Guids
  ///   so that users can apply their own guid comb algorithms
  /// </summary>
  [Obsolete("Use X12.Sql library and namespace")]
  public class SqlGuidTransactionRepository : SqlTransactionRepository<Guid>
  {
    public SqlGuidTransactionRepository(
      string dsn,
      ISpecificationFinder specFinder,
      string[] indexedSegments,
      string schema = "dbo",
      string commonSchema = "dbo",
      int segmentBatchSize = 1000)
      : base(dsn, specFinder, indexedSegments, schema, commonSchema, segmentBatchSize) { }

    protected virtual Guid NewGuid() => Guid.NewGuid();

    protected override Guid SaveLoop(
      Loop loop,
      Guid interchangeId,
      Guid transactionSetId,
      string transactionSetCode,
      Guid? parentLoopId)
    {
      var id = NewGuid();

      this._segmentBatch.AddLoop(
        id,
        loop,
        interchangeId,
        transactionSetId != Guid.Empty ? transactionSetId : null,
        transactionSetCode,
        parentLoopId != Guid.Empty ? parentLoopId : null,
        GetEntityTypeCode(loop));

      return id;
    }

    internal override void ExecuteBatch(SqlTransaction tran)
    {
      if (this._segmentBatch.LoopCount > 0)
        try
        {
          using (var conn = tran == null ? new SqlConnection(this._dsn) : tran.Connection)
          {
            if (conn.State != ConnectionState.Open)
              conn.Open();

            using (var sbc = new SqlBulkCopy(conn))
            {
              sbc.DestinationTableName = string.Format("[{0}].[Container]", this._commonDb.Schema);

              var containerTable = new DataTable();
              containerTable.Columns.Add("Id", typeof(Guid));
              containerTable.Columns.Add("SchemaName", typeof(string));
              containerTable.Columns.Add("Type", typeof(string));
              foreach (DataRow row in this._segmentBatch._loopTable.Rows)
                containerTable.Rows.Add(row["Id"], this._schema, row["StartingSegmentId"]);

              foreach (DataColumn c in containerTable.Columns)
                sbc.ColumnMappings.Add(c.ColumnName, c.ColumnName);

              sbc.WriteToServer(containerTable);
            }

            using (var sbc = new SqlBulkCopy(conn))
            {
              sbc.DestinationTableName = string.Format("[{0}].[Loop]", this._schema);
              foreach (DataColumn c in this._segmentBatch._loopTable.Columns)
                sbc.ColumnMappings.Add(c.ColumnName, c.ColumnName);

              sbc.WriteToServer(this._segmentBatch._loopTable);
            }
          }

          this._segmentBatch._loopTable.Clear();
        }
        catch (Exception exc)
        {
          Trace.WriteLine(exc.Message);
          Trace.TraceInformation(
            "Error Saving {0} loops to db starting with {1}.",
            this._segmentBatch.LoopCount,
            this._segmentBatch.StartingSegment);

          throw;
        }

      base.ExecuteBatch(tran);
    }
  }
}