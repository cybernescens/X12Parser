namespace X12.Model
{
  public class TypedSegmentPER : TypedSegment
  {
    public TypedSegmentPER()
      : base("PER") { }

    public string PER01_ContactFunctionCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PER02_Name
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public CommunicationNumberQualifier PER03_CommunicationNumberQualifier
    {
      get => GetQualifier(3);
      set => SetQualifier(3, value);
    }

    public string PER04_CommunicationNumber
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public CommunicationNumberQualifier PER05_CommunicationNumberQualifier
    {
      get => GetQualifier(5);
      set => SetQualifier(5, value);
    }

    public string PER06_CommunicationNumber
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public CommunicationNumberQualifier PER07_CommunicationNumberQualifier
    {
      get => GetQualifier(7);
      set => SetQualifier(7, value);
    }

    public string PER08_CommunicationNumber
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string PER09_ContactInquiryReference
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }

    private CommunicationNumberQualifier GetQualifier(int elementNumber)
    {
      switch (this._segment.GetElement(elementNumber))
      {
        case "EM": return CommunicationNumberQualifier.ElectronicMail;
        case "EX": return CommunicationNumberQualifier.TelephoneExtension;
        case "FX": return CommunicationNumberQualifier.Facsimile;
        case "TE": return CommunicationNumberQualifier.Telephone;
        default:   return CommunicationNumberQualifier.Undefined;
      }
    }

    private void SetQualifier(int elementNumber, CommunicationNumberQualifier value)
    {
      switch (value)
      {
        case CommunicationNumberQualifier.ElectronicMail:
          this._segment.SetElement(elementNumber, "EM");
          break;
        case CommunicationNumberQualifier.TelephoneExtension:
          this._segment.SetElement(elementNumber, "EX");
          break;
        case CommunicationNumberQualifier.Facsimile:
          this._segment.SetElement(elementNumber, "FX");
          break;
        case CommunicationNumberQualifier.Telephone:
          this._segment.SetElement(elementNumber, "TE");
          break;
        default:
          this._segment.SetElement(elementNumber, "");
          break;
      }
    }
  }
}