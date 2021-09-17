namespace X12.Model
{
  public class TypedSegmentIK5 : TypedSegment
  {
    public TypedSegmentIK5() : base("IK5") { }

    public string IK501_TransactionSetAcknowledgmentCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string IK502_SyntaxErrorCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string IK503_SyntaxErrorCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string IK504_SyntaxErrorCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string IK505_SyntaxErrorCode
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string IK506_SyntaxErrorCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }
  }
}