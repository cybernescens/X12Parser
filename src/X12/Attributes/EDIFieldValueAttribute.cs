using System;

namespace X12.Attributes
{
  public class EDIFieldValueAttribute : Attribute
  {
    public EDIFieldValueAttribute(string value) { Value = value; }

    public string Value { get; }
  }
}