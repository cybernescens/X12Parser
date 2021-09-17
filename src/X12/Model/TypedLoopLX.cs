using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public class TypedLoopLX : TypedLoop
  {
    private string _entityIdentifer;

    public TypedLoopLX(string entityIdentifier)
      : base("LX")
    {
      _entityIdentifer = entityIdentifier;
    }

    public string LX01_AssignedNumber
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    internal override void Initialize(Container parent, X12DelimiterSet delimiters, LoopSpecification loopSpecification)
    {
      var segmentString = GetSegmentString(delimiters);

      this._loop = new Loop(parent, delimiters, segmentString, loopSpecification);
    }
  }
}