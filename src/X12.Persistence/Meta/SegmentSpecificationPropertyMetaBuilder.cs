using System;
using System.Collections.Generic;
using System.Linq;
using X12.Parsing.Specification;
using X12.Persistence.Meta.Property;
using X12.Persistence.Model;

namespace X12.Persistence.Meta
{
  public class SegmentSpecificationPropertyMetaBuilder : PropertyMetaBuilder<SegmentSpecification>
  {
    public SegmentSpecificationPropertyMetaBuilder(IIdentityProvider identityDataType)
      : base(identityDataType) { }

    protected override IList<BatchPropertyMetadata> Describe(SegmentSpecification specification)
    {
      var columns = new List<BatchPropertyMetadata>();
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.Id), false, IdentityPropertyType, x => ((IndexedSegmentEntity)x).Id));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.InterchangeId), false, IdentityPropertyType, x => ((IndexedSegmentEntity)x).InterchangeId));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.PositionInInterchange), false, IntegerPropertyType.Big(), x => ((IndexedSegmentEntity)x).PositionInInterchange));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.TransactionSetId), false, IdentityPropertyType, x => ((IndexedSegmentEntity)x).TransactionSetId));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.ParentLoopId), true, IdentityPropertyType, x => ((IndexedSegmentEntity)x).ParentLoopId));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.LoopId), true, IdentityPropertyType, x => ((IndexedSegmentEntity)x).LoopId));
      columns.Add(new BatchPropertyMetadata(nameof(IndexedSegmentEntity.ErrorId), true, IdentityPropertyType, x => ((IndexedSegmentEntity)x).ErrorId));
      columns.AddRange(
        specification
          .Elements
          .Select(
            x => {
              x.MaxLength = Math.Max(x.MaxLength, DefaultMaxLength);
              return x switch {
                //{ Type: ElementDataTypeEnum.Binary } => new ColumnMetadata(x.Reference, true, new BinarySqlType(), z => ((IndexedSegmentEntity)z).GetBinaryElement(x.Reference)),
                { Type: ElementDataTypeEnum.Date } => new BatchPropertyMetadata(x.Reference, true, new DatePropertyType(), z => ((IndexedSegmentEntity)z).GetDateElement(x.Reference)),
                { Type: ElementDataTypeEnum.Decimal } => new BatchPropertyMetadata(x.Reference, true, new NumericPropertyType(x.MaxLength * 2, x.MaxLength / 2), z => ((IndexedSegmentEntity)z).GetDecimalElement(x.Reference)),
                { Type: ElementDataTypeEnum.Identifier } => new BatchPropertyMetadata(x.Reference, true, new VarcharPropertyDataType(x.MaxLength), z => ((IndexedSegmentEntity)z).GetElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric, MaxLength: < 5 } => new BatchPropertyMetadata(x.Reference, true, IntegerPropertyType.Small(), z => ((IndexedSegmentEntity)z).GetShortElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric, MaxLength: < 10 } => new BatchPropertyMetadata(x.Reference, true, IntegerPropertyType.Regular(), z => ((IndexedSegmentEntity)z).GetIntElement(x.Reference)),
                { Type: ElementDataTypeEnum.Numeric } => new BatchPropertyMetadata(x.Reference, true, IntegerPropertyType.Big(), z => ((IndexedSegmentEntity)z).GetLongElement(x.Reference)),
                { Type: ElementDataTypeEnum.String } => new BatchPropertyMetadata(x.Reference, true, new VarcharPropertyDataType(x.MaxLength), z => ((IndexedSegmentEntity)z).GetElement(x.Reference)),
                { Type: ElementDataTypeEnum.Time } => new BatchPropertyMetadata(x.Reference, true, new TimePropertyType(), z => ((IndexedSegmentEntity)z).GetTimeElement(x.Reference)),
                _ => throw new InvalidOperationException($"Unknown Element Type: `{x.Type}`")
              };
            })
          .ToList());

      return columns;
    }

    private const int DefaultMaxLength = 50;
  }
}