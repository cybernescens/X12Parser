using System;
using System.Linq;
using X12.Attributes;

namespace X12.Extensions
{
  public static class EnumExtensions
  {
    public static string EdiFieldValue(this Enum enumValue)
    {
      enumValue = enumValue ?? throw new ArgumentNullException(nameof(enumValue));

      var attributes = (EdiFieldValueAttribute[])enumValue
        .GetType()
        .GetField(enumValue.ToString())
        .GetCustomAttributes(typeof(EdiFieldValueAttribute), false);

      if (attributes.Length > 0)
        return attributes[0].Value;

      throw new InvalidOperationException("No EdiValue Attribute defined for " + enumValue);
    }

    public static T ToEnumFromEdiFieldValue<T>(this string itemValue)
      where T : Enum
    {
      var type = typeof(T);
      if (!type.IsEnum)
        throw new InvalidOperationException();

      foreach (var field in type.GetFields()
        .Select(
          field => new {
            Field = field,
            Attributes = (EdiFieldValueAttribute[])field.GetCustomAttributes(typeof(EdiFieldValueAttribute), false)
          })
        .Where(t => t.Attributes.Length > 0 && t.Attributes[0].Value == itemValue)
        .Select(t => t.Field))
        return (T)field.GetValue(null);

      throw new InvalidOperationException("No EDI Field Value found for " + itemValue);
    }
  }
}