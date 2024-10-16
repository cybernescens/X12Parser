﻿using System;

namespace X12.Model
{
  public class ElementValidationException : ArgumentException
  {
    public ElementValidationException(string formatString, string elementId, string value, params object[] args)
      : base(
        string.Format(
          formatString,
          elementId,
          value,
          args.Length > 0 ? args[0] : null,
          args.Length > 1 ? args[1] : null,
          args.Length > 2 ? args[2] : null),
        elementId)
    {
      ElementId = elementId;
      Value = value;
    }

    public string ElementId { get; }
    public string Value { get; }
  }
}