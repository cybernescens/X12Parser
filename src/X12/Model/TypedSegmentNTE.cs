namespace X12.Model
{
  /// <summary>
  ///   Note/Secial Instruction
  /// </summary>
  public class TypedSegmentNTE : TypedSegment
  {
    public TypedSegmentNTE()
      : base("NTE") { }

    /// <summary>
    ///   GEN = Entire Transaction Set
    /// </summary>
    public string NTE01_NoteReferenceCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string NTE02_Description
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }
  }
}