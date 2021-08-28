using System;

namespace X12.Sql
{
  public static class TypeExtensions
  {
    public static object GetDefaultValue(this Type t)
    {
      if (t.IsValueType)
        return Activator.CreateInstance(t);

      return null;
    }
  }
}