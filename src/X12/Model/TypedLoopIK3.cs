namespace X12.Model
{
  public class TypedLoopIK3 : TypedLoop
  {
    public TypedLoopIK3() : base("IK3") { }

    public string IK301_SegmentIdCode
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public int? IK302_SegmentPositionInTransactionSet
    {
      get {
        int position;
        if (int.TryParse(this._loop.GetElement(2), out position))
          return position;

        return null;
      }
      set {
        if (value.HasValue)
          this._loop.SetElement(2, value.ToString());
        else
          this._loop.SetElement(2, "");
      }
    }

    public string IK303_LoopIdentifierCode
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string IK304_SyntaxErrorCode
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }
  }
}