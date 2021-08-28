namespace X12.Parsing.Model.Typed
{
  public class TypedElementRelatedCausesInfo
  {
    private string _countryCode;
    private readonly int _elementNumber;
    private string _relatedCausesCode1;
    private string _relatedCausesCode2;
    private string _relatedCausesCode3;
    private readonly Segment _segment;
    private string _stateOrProviceCode;

    internal TypedElementRelatedCausesInfo(Segment segment, int elementNumber)
    {
      _segment = segment;
      _elementNumber = elementNumber;
    }

    public string _1_RelatedCausesCode
    {
      get => _relatedCausesCode1;
      set {
        _relatedCausesCode1 = value;
        UpdateElement();
      }
    }

    public string _2_RelatedCausesCode
    {
      get => _relatedCausesCode2;
      set {
        _relatedCausesCode2 = value;
        UpdateElement();
      }
    }

    public string _3_RelatedCausesCode
    {
      get => _relatedCausesCode3;
      set {
        _relatedCausesCode3 = value;
        UpdateElement();
      }
    }

    public string _4_StateOrProvidenceCode
    {
      get => _stateOrProviceCode;
      set {
        _stateOrProviceCode = value;
        UpdateElement();
      }
    }

    public string _5_CountryCode
    {
      get => _countryCode;
      set {
        _countryCode = value;
        UpdateElement();
      }
    }

    private void UpdateElement()
    {
      var value = string.Format(
        "{1}{0}{2}{0}{3}{0}{4}{0}{5}",
        _segment._delimiters.SubElementSeparator,
        _relatedCausesCode1,
        _relatedCausesCode2,
        _relatedCausesCode3,
        _stateOrProviceCode,
        _countryCode);

      value = value.TrimEnd(_segment._delimiters.SubElementSeparator);
      _segment.SetElement(_elementNumber, value);
    }
  }
}