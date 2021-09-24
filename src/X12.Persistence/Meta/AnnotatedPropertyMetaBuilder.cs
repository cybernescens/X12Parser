using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using X12.Persistence.Meta.Property;

namespace X12.Persistence.Meta
{
  public class AnnotatedPropertyMetaBuilder : PropertyMetaBuilder<Type>
  {
    private readonly Type _recordType;

    public AnnotatedPropertyMetaBuilder(Type recordType, IIdentityProvider identityDataType) : base(identityDataType)
    {
      _recordType = recordType;
    }

    protected override IList<BatchPropertyMetadata> Describe(Type _)
    {
      return _recordType
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Select(
          x => {
            var parameter = Expression.Parameter(typeof(object), "input");
            var castAsObject = Expression.TypeAs(
              Expression.Property(Expression.TypeAs(parameter, _recordType), x),
              typeof(object));

            var valueFunc = Expression.Lambda<Func<object, object>>(castAsObject, parameter).Compile();

            var attributes = x.GetCustomAttributes().ToList();
            var required = 
              GetRequired(attributes.OfType<RequiredAttribute>().FirstOrDefault()) || 
              GetRequired(attributes.OfType<KeyAttribute>().FirstOrDefault()) ||
              !IsNullable(x);

            var sqlType = GetSqlType(
              x,
              attributes.OfType<DataTypeAttribute>().FirstOrDefault(),
              attributes.OfType<MaxLengthAttribute>().FirstOrDefault(),
              attributes.OfType<ForeignKeyAttribute>().FirstOrDefault(),
              attributes.OfType<KeyAttribute>().FirstOrDefault());

            return new BatchPropertyMetadata(x.Name, !required, sqlType, valueFunc);
          })
        .ToList();
    }

    private static bool IsNullable(PropertyInfo pi)
    {
      if (pi.PropertyType.IsValueType)
        return Nullable.GetUnderlyingType(pi.PropertyType) != null;

      var nullable = pi.CustomAttributes
        .FirstOrDefault(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableAttribute");

      if (nullable != null && nullable.ConstructorArguments.Count == 1)
      {
        var attributeArgument = nullable.ConstructorArguments[0];
        if (attributeArgument.ArgumentType == typeof(byte[]))
        {
          var args = (ReadOnlyCollection<CustomAttributeTypedArgument>)attributeArgument.Value!;
          if (args.Count > 0 && args[0].ArgumentType == typeof(byte))
          {
            return (byte)args[0].Value! == 2;
          }
        }
        else if (attributeArgument.ArgumentType == typeof(byte))
        {
          return (byte)attributeArgument.Value! == 2;
        }
      }

      for (var type = pi.DeclaringType; type != null; type = type.DeclaringType)
      {
        var context = type.CustomAttributes
          .FirstOrDefault(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableContextAttribute");

        if (context != null &&
          context.ConstructorArguments.Count == 1 &&
          context.ConstructorArguments[0].ArgumentType == typeof(byte))
        {
          return (byte)context.ConstructorArguments[0].Value! == 2;
        }
      }

      return false;
    }

    private PropertyDataType GetSqlType(
      PropertyInfo pi,
      DataTypeAttribute? dataTypeAttr,
      MaxLengthAttribute? maxLengthAttr,
      ForeignKeyAttribute? foreignKeyAttr,
      KeyAttribute? keyAttr)
    {
      return pi.PropertyType.Name switch {
        nameof(Int64)   => IntegerPropertyType.Big(),
        nameof(Int32)   => IntegerPropertyType.Regular(),
        nameof(Int16)   => IntegerPropertyType.Small(),
        nameof(Guid)    => new UniqueIdentifierPropertyType(),
        nameof(Boolean) => new BitPropertyType(),
        nameof(Char)    => new VarcharPropertyDataType(1),
        nameof(String) => maxLengthAttr switch {
          { Length: > 0 } => new VarcharPropertyDataType(maxLengthAttr.Length),
          null            => new VarcharPropertyDataType(int.MaxValue),
          _ => throw new InvalidOperationException(
            $"Invalid length `{maxLengthAttr?.Length ?? 0}` specified for string property `{pi.DeclaringType!.Name}.{pi.Name}`")
        },
        nameof(DateTime) => dataTypeAttr switch {
          { DataType: DataType.DateTime } => new DateTimePropertyType(),
          { DataType: DataType.Date }     => new DatePropertyType(),
          { DataType: DataType.Time }     => new TimePropertyType(),
          _ => throw new InvalidOperationException(
            $"Unknown data type `{dataTypeAttr?.DataType ?? 0}` specified for DateTime property `{pi.DeclaringType!.Name}.{pi.Name}`")
        },
        _ => (foreignKeyAttr, keyAttr) switch {
          (null, null) => throw new InvalidOperationException(
            $"No SQL Type Mapping defined for `{pi.PropertyType.FullName}` for property `{pi.DeclaringType!.Name}.{pi.Name}`"),
          _ => IdentityPropertyType
        }
      };
    }

    private bool GetRequired<T>(T? attr) where T : Attribute => attr != null;
  }
}