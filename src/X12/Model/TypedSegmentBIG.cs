using System;

namespace X12.Model
{
  /// <summary>
  ///   Beginning Segment for Invoice
  /// </summary>
  public class TypedSegmentBIG : TypedSegment
  {
    public TypedSegmentBIG()
      : base("BIG") { }

    public DateTime? BIG01_InvoiceDate
    {
      get => this._segment.GetDate8Element(1);
      set => this._segment.SetDate8Element(1, value);
    }

    public string BIG02_InvoiceNumber
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public DateTime? BIG03_PurchaseOrderDate
    {
      get => this._segment.GetDate8Element(3);
      set => this._segment.SetDate8Element(3, value);
    }

    public string BIG04_PurchaseOrderNumber
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    /// <summary>
    ///   CN = Credit Invoice
    ///   CR = Credit Memo
    ///   DI = Debit Invoice
    ///   DR = Debit Memo
    /// </summary>
    public string BIG07_TransactionTypeCode
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string BIG08_TransactionSetPurposeCode
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string BIG09_ActionCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }

    public string BIG10_InvoiceNumber
    {
      get => this._segment.GetElement(10);
      set => this._segment.SetElement(10, value);
    }
  }
}