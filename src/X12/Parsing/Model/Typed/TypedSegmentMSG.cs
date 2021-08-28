namespace X12.Parsing.Model.Typed
{
  /// <summary>
  ///   Message Text
  /// </summary>
  public class TypedSegmentMSG : TypedSegment
  {
    public TypedSegmentMSG()
      : base("MSG") { }

    public string MSG01_FreeFormMessageText
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string MSG02_PrinterCarriageControlCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public int? MSG03_Number
    {
      get => this._segment.GetIntElement(3);
      set => this._segment.SetElement(3, value);
    }
  }
}