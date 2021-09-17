namespace X12.Model
{
  public class TypedSegmentAK9 : TypedSegment
  {
    public TypedSegmentAK9()
      : base("AK9") { }

    public string AK901_FunctionalGroupAcknowledgeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public int AK902_NumberOfTransactionSetsIncluded
    {
      get {
        int count;
        if (int.TryParse(this._segment.GetElement(2), out count))
          return count;

        return 0;
      }
      set => this._segment.SetElement(2, value.ToString());
    }

    public int AK903_NumberOfReceivedTransactionSets
    {
      get {
        int count;
        if (int.TryParse(this._segment.GetElement(3), out count))
          return count;

        return 0;
      }
      set => this._segment.SetElement(3, value.ToString());
    }

    public int AK904_NumberOfAcceptedTransactionSets
    {
      get {
        int count;
        if (int.TryParse(this._segment.GetElement(4), out count))
          return count;

        return 0;
      }
      set => this._segment.SetElement(4, value.ToString());
    }

    public string AK905_FunctionalGroupSyntaxErrorCode
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string AK906_FunctionalGroupSyntaxErrorCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string AK907_FunctionalGroupSyntaxErrorCode
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string AK908_FunctionalGroupSyntaxErrorCode
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string AK909_FunctionalGroupSyntaxErrorCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }
  }
}