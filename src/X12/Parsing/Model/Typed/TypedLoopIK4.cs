using X12.Parsing.Specification;

namespace X12.Parsing.Model.Typed
{
  public class TypedLoopIK4 : TypedLoop
  {
    public TypedLoopIK4() : base("IK4") { }

    public TypedElementPositionInSegment IK401 { get; private set; }

    public string IK402_DataElementReferenceNumber
    {
      get => this._loop.GetElement(2);
      set => this._loop.SetElement(2, value);
    }

    public string IK403_SyntaxErrorCode
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string IK404_CopyOfBaDataElement
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    internal override void Initialize(Container parent, X12DelimiterSet delimiters, LoopSpecification loopSpecification)
    {
      base.Initialize(parent, delimiters, loopSpecification);
      IK401 = new TypedElementPositionInSegment(this._loop, 1);
    }
  }
}