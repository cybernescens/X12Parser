using System;

namespace X12.Attributes
{
  public class EdiFieldValueAttribute : Attribute
  {
    public EdiFieldValueAttribute(string value) { Value = value; }
    public string Value { get; }
  }

  [Obsolete("Use EdiFieldValueAttribute")]
  public class EDIFieldValueAttribute : EdiFieldValueAttribute
  {
    public EDIFieldValueAttribute(string value) : base(value) { }
  }
}