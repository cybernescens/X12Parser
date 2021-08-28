namespace X12.Parsing.Model.Typed
{
  public class TypedElementPositionInSegment
  {
    private int? _componentDataElementPositionInComposite;
    private readonly int _elementNumber;
    private int? _elementPositionInSegment;
    private int? _repeatingDataElementPosition;
    private readonly Segment _segment;

    internal TypedElementPositionInSegment(Segment segment, int elementNumber)
    {
      _segment = segment;
      _elementNumber = elementNumber;
    }

    public int? _1_ElementPositionInSegment
    {
      get => _elementPositionInSegment;
      set {
        _elementPositionInSegment = value;
        UpdateElement();
      }
    }

    public int? _2_ComponentDataElementPositionInComposite
    {
      get => _componentDataElementPositionInComposite;
      set {
        _componentDataElementPositionInComposite = value;
        UpdateElement();
      }
    }

    public int? _3_RepeatingDataElementPosition
    {
      get => _repeatingDataElementPosition;
      set {
        _repeatingDataElementPosition = value;
        UpdateElement();
      }
    }

    private void UpdateElement()
    {
      var value = string.Format(
        "{1}{0}{2}{0}{3}",
        _segment._delimiters.SubElementSeparator,
        _elementPositionInSegment,
        _componentDataElementPositionInComposite,
        _repeatingDataElementPosition);

      value = value.TrimEnd(_segment._delimiters.SubElementSeparator);
      _segment.SetElement(_elementNumber, value);
    }
  }
}