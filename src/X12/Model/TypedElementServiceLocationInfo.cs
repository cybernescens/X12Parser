namespace X12.Model
{
  public class TypedElementServiceLocationInfo
  {
    private string _claimFrequencyTypeCode;
    private readonly int _elementNumber;
    private string _facilityCodeQualifier;
    private string _facilityCodeValue;
    private readonly Segment _segment;

    internal TypedElementServiceLocationInfo(Segment segment, int elementNumber)
    {
      _segment = segment;
      _elementNumber = elementNumber;
    }

    public string _1_FacilityCodeValue
    {
      get => _facilityCodeValue;
      set {
        _facilityCodeValue = value;
        UpdateElement();
      }
    }

    public string _2_FacilityCodeQualifier
    {
      get => _2_FacilityCodeQualifier;
      set {
        _facilityCodeQualifier = value;
        UpdateElement();
      }
    }

    public string _3_ClaimFrequencyTypeCode
    {
      get => _claimFrequencyTypeCode;
      set {
        _claimFrequencyTypeCode = value;
        UpdateElement();
      }
    }

    private void UpdateElement()
    {
      var value = string.Format(
        "{1}{0}{2}{0}{3}",
        _segment._delimiters.SubElementSeparator,
        _facilityCodeValue,
        _facilityCodeQualifier,
        _claimFrequencyTypeCode);

      value = value.TrimEnd(_segment._delimiters.SubElementSeparator);
      _segment.SetElement(_elementNumber, value);
    }
  }
}