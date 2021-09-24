using System;

namespace X12.Persistence.Meta.Property
{
  public class NumericPropertyType : PropertyDataType
  {
    public byte Precision { get; }
    public byte Scale { get; }

    public NumericPropertyType(int precision, int scale)
    {
      Precision = (byte) Math.Min(38, precision);
      Scale = (byte) Math.Min(Math.Min(4, precision), scale);
    }

    public override string Render() => $"numeric({Precision}, {Scale})";
  }
}