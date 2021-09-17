using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace X12.Persistence.Meta
{
  public class AnnotatedColumnMetaBuilder : ColumnMetaBuilder<Type>
  {
    private readonly Type _recordType;

    public AnnotatedColumnMetaBuilder(Type recordType, IIdentityProvider identityDataType) : base(identityDataType)
    {
      _recordType = recordType;
    }

    protected override IList<ColumnMetadata> Describe(Type specification)
    {
      return _recordType
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Select(x => (Attributes: x.GetCustomAttributes(), Pi: x))
        .Select(
          x => {
            var parameter = Expression.Parameter(typeof(object), "input");
            var castAsObject = Expression.TypeAs(
              Expression.Property(
                Expression.TypeAs(parameter, _recordType),
                x.Pi!),
              typeof(object));

            var valueFunc = Expression.Lambda<Func<object, object>>(castAsObject, parameter).Compile();
            var required = 
              GetRequired(x.Attributes.OfType<RequiredAttribute>().FirstOrDefault()) || 
              GetRequired(x.Attributes.OfType<KeyAttribute>().FirstOrDefault());

            var sqlType = GetSqlType(
              x.Pi,
              x.Attributes.OfType<DataTypeAttribute>().FirstOrDefault(),
              x.Attributes.OfType<MaxLengthAttribute>().FirstOrDefault(),
              x.Attributes.OfType<ForeignKeyAttribute>().FirstOrDefault(),
              x.Attributes.OfType<KeyAttribute>().FirstOrDefault());

            return new ColumnMetadata(x.Pi.Name, !required, sqlType, valueFunc);
          })
        .ToList();
    }

    private SqlDataType GetSqlType(
      PropertyInfo pi,
      DataTypeAttribute dataTypeAttr,
      MaxLengthAttribute maxLengthAttr,
      ForeignKeyAttribute foreignKeyAttr,
      KeyAttribute keyAttr)
    {
      return pi.PropertyType.Name switch {
        nameof(Int64)   => IntegerSqlType.Big(),
        nameof(Int32)   => IntegerSqlType.Regular(),
        nameof(Int16)   => IntegerSqlType.Small(),
        nameof(Guid)    => new UniqueIdentifierSqlType(),
        nameof(Boolean) => new BitSqlType(),
        nameof(Char)    => new VarcharSqlDataType(1),
        nameof(String) => maxLengthAttr switch {
          { Length: > 0 } => new VarcharSqlDataType(maxLengthAttr.Length),
          null            => new VarcharSqlDataType(int.MaxValue),
          _ => throw new InvalidOperationException(
            $"Invalid length `{maxLengthAttr.Length}` specified for string property `{pi.DeclaringType.Name}.{pi.Name}`")
        },
        nameof(DateTime) => dataTypeAttr switch {
          { DataType: DataType.DateTime } => new DateTimeSqlType(),
          { DataType: DataType.Date }     => new DateSqlType(),
          { DataType: DataType.Time }     => new TimeSqlType(),
          _ => throw new InvalidOperationException(
            $"Unknown data type `{dataTypeAttr?.DataType}` specified for DateTime property `{pi.DeclaringType.Name}.{pi.Name}`")
        },
        _ => (foreignKeyAttr, keyAttr) switch {
          (null, null) => throw new InvalidOperationException(
            $"No SQL Type Mapping defined for `{pi.PropertyType.FullName}` for property `{pi.DeclaringType.Name}.{pi.Name}`"),
          _ => IdentitySqlType
        }
      };
    }

    private bool GetRequired<T>(T attr) where T : Attribute => attr != null;
  }
}