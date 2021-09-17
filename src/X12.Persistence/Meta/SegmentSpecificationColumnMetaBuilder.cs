using System;
using System.Collections.Generic;
using System.Linq;
using X12.Parsing.Specification;
using X12.Persistence.Model;

namespace X12.Persistence.Meta
{
  public class SegmentSpecificationColumnMetaBuilder : ColumnMetaBuilder<SegmentSpecification>
  {
    public SegmentSpecificationColumnMetaBuilder(IIdentityProvider identityDataType)
      : base(identityDataType) { }

    protected override IList<ColumnMetadata> Describe(SegmentSpecification specification)
    {
      var columns = new List<ColumnMetadata>();
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.Id), false, IdentitySqlType, x => ((IndexedSegmentEntity)x).Id));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.InterchangeId), false, IdentitySqlType, x => ((IndexedSegmentEntity)x).InterchangeId));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.PositionInInterchange), false, IntegerSqlType.Big(), x => ((IndexedSegmentEntity)x).PositionInInterchange));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.TransactionSetId), false, IdentitySqlType, x => ((IndexedSegmentEntity)x).TransactionSetId));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.ParentLoopId), true, IdentitySqlType, x => ((IndexedSegmentEntity)x).ParentLoopId));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.LoopId), true, IdentitySqlType, x => ((IndexedSegmentEntity)x).LoopId));
      columns.Add(new ColumnMetadata(nameof(IndexedSegmentEntity.ErrorId), true, IdentitySqlType, x => ((IndexedSegmentEntity)x).ErrorId));
      columns.AddRange(
        specification
          .Elements
          .Select(
            x => {
              x.MaxLength = Math.Max(x.MaxLength, DefaultMaxLength);
              return x switch {
                //{ Type: ElementDataTypeEnum.Binary } => new ColumnMetadata(x.Reference, true, new BinarySqlType(), z => ((IndexedSegmentEntity)z).GetBinaryElement(x.Reference)),
                { Type: ElementDataTypeEnum.Date } => new ColumnMetadata(x.Reference, true, new DateSqlType(), z => ((IndexedSegmentEntity)z).GetDateElement(x.Reference)),
                { Type: ElementDataTypeEnum.Decimal } => new ColumnMetadata(x.Reference, true, new NumericSqlType(x.MaxLength * 2, x.MaxLength / 2), z => ((IndexedSegmentEntity)z).GetDecimalElement(x.Reference)),
                { Type: ElementDataTypeEnum.Identifier } => new ColumnMetadata(x.Reference, true, new VarcharSqlDataType(x.MaxLength), z => ((IndexedSegmentEntity)z).GetElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric, MaxLength: < 5 } => new ColumnMetadata(x.Reference, true, IntegerSqlType.Small(), z => ((IndexedSegmentEntity)z).GetShortElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric, MaxLength: < 10 } => new ColumnMetadata(x.Reference, true, IntegerSqlType.Regular(), z => ((IndexedSegmentEntity)z).GetIntElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric } => new ColumnMetadata(x.Reference, true, IntegerSqlType.Big(), z => ((IndexedSegmentEntity)z).GetLongElement(x.Reference)),
                { Type: ElementDataTypeEnum.String } => new ColumnMetadata(x.Reference, true, new VarcharSqlDataType(x.MaxLength), z => ((IndexedSegmentEntity)z).GetElement(x.Reference)),
                { Type: ElementDataTypeEnum.Time } => new ColumnMetadata(x.Reference, true, new TimeSqlType(), z => ((IndexedSegmentEntity)z).GetTimeElement(x.Reference)),
                _ => throw new InvalidOperationException($"Unknown Element Type: `{x.Type}`")
              };
            })
          .ToList());

      return columns;
    }

    private const int DefaultMaxLength = 50;
  }
}