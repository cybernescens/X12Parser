namespace X12.Parsing.Model.Typed
{
  public class TypedElementContextIdentification
  {
    private readonly int _elementNumber;
    private string _name;
    private string _reference;
    private readonly Segment _segment;

    internal TypedElementContextIdentification(Segment segment, int elementNumber)
    {
      _segment = segment;
      _elementNumber = elementNumber;
    }

    public string _1_ContextName
    {
      get => _name;
      set {
        _name = value;
        UpdateElement();
      }
    }

    public string _2_ContextReference
    {
      get => _reference;
      set {
        _reference = value;
        UpdateElement();
      }
    }

    private void UpdateElement()
    {
      var value = string.Format(
        "{1}{0}{2}",
        _segment._delimiters.SubElementSeparator,
        _name,
        _reference);

      value = value.TrimEnd(_segment._delimiters.SubElementSeparator);
      _segment.SetElement(_elementNumber, value);
    }
  }
}