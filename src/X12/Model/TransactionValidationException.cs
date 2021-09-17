﻿using System;

namespace X12.Model
{
  public class TransactionValidationException : ArgumentException
  {
    public TransactionValidationException(
      string formatString,
      string transactionCode,
      string controlNumber,
      string elementId,
      string value,
      params object[] args)
      : base(
        string.Format(
          formatString,
          transactionCode,
          controlNumber,
          controlNumber,
          elementId,
          value,
          args.Length > 0 ? args[0] : null,
          args.Length > 1 ? args[1] : null),
        transactionCode)
    {
      TransactionCode = transactionCode;
      ControlNumber = controlNumber;
      ElementId = elementId;
      Value = value;
    }

    public string TransactionCode { get; }
    public string ControlNumber { get; }
    public string ElementId { get; }
    public string Value { get; }
  }
}