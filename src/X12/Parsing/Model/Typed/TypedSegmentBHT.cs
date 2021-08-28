using System;

namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentBHT : TypedSegment
  {
    public TypedSegmentBHT()
      : base("BHT") { }

    public string BHT01_HierarchicalStructureCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string BHT02_TransactionSetPurposeCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string BHT03_ReferenceIdentification
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public DateTime? BHT04_Date
    {
      get => this._segment.GetDate8Element(4);
      set => this._segment.SetDate8Element(4, value);
    }

    public string BHT05_Time
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string BHT06_TransactionTypeCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}