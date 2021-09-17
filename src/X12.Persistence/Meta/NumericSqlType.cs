﻿using System;

namespace X12.Persistence.Meta
{
  public class NumericSqlType : SqlDataType
  {
    public byte Precision { get; }
    public byte Scale { get; }

    public NumericSqlType(int precision, int scale)
    {
      Precision = (byte) Math.Min(38, precision);
      Scale = (byte) Math.Min(Math.Min(4, precision), scale);
    }

    public override string Render() => $"numeric({Precision}, {Scale})";
  }
}