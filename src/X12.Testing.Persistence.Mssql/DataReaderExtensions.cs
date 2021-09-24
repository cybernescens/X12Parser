using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace X12.Testing.Persistence.Mssql
{
  public static class DataReaderExtensions
  {
    public static T Get<T>(this IDataReader reader, string key, Func<object, T> convert = null)
    {
      var typet = typeof(T);
      
      if (convert == null && typet.IsGenericType && ReferenceEquals(typet.GetGenericTypeDefinition(), typeof(Nullable<>)))
        convert = o => o == null ? default(T) : (T)Convert.ChangeType(o, typet.GetGenericArguments()[0]);
      else if (convert == null)
        convert = o => (T)Convert.ChangeType(o, typeof(T));

      var value = GetValue(reader, key);
      return value != null ? convert(value) : Activator.CreateInstance<T>();
    }

    public static string Get(this IDataReader reader, string key) => Get(reader, key, Convert.ToString);

    private static object GetValue(IDataRecord reader, string key) =>
      reader[key] switch {
        DBNull => null,
        { } x  => x
      };

    private static bool IsNullable(Type type)
    {
      if (type.IsValueType)
        return Nullable.GetUnderlyingType(type) != null;
        
      for (; type != null; type = type.DeclaringType)
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
  }
}