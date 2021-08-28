namespace X12.Parsing.Model.Typed
{
  public enum CommunicationNumberQualifer
  {
    Undefined,
    ElectronicMail,
    TelephoneExtension,
    Facsimile,
    Telephone
  }

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

    public CommunicationNumberQualifer PER03_CommunicationNumberQualifier
    {
      get => GetQualifier(3);
      set => SetQualifier(3, value);
    }

    public string PER04_CommunicationNumber
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public CommunicationNumberQualifer PER05_CommunicationNumberQualifier
    {
      get => GetQualifier(5);
      set => SetQualifier(5, value);
    }

    public string PER06_CommunicationNumber
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public CommunicationNumberQualifer PER07_CommunicationNumberQualifier
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

    private CommunicationNumberQualifer GetQualifier(int elementNumber)
    {
      switch (this._segment.GetElement(elementNumber))
      {
        case "EM": return CommunicationNumberQualifer.ElectronicMail;
        case "EX": return CommunicationNumberQualifer.TelephoneExtension;
        case "FX": return CommunicationNumberQualifer.Facsimile;
        case "TE": return CommunicationNumberQualifer.Telephone;
        default:   return CommunicationNumberQualifer.Undefined;
      }
    }

    private void SetQualifier(int elementNumber, CommunicationNumberQualifer value)
    {
      switch (value)
      {
        case CommunicationNumberQualifer.ElectronicMail:
          this._segment.SetElement(elementNumber, "EM");
          break;
        case CommunicationNumberQualifer.TelephoneExtension:
          this._segment.SetElement(elementNumber, "EX");
          break;
        case CommunicationNumberQualifer.Facsimile:
          this._segment.SetElement(elementNumber, "FX");
          break;
        case CommunicationNumberQualifer.Telephone:
          this._segment.SetElement(elementNumber, "TE");
          break;
        default:
          this._segment.SetElement(elementNumber, "");
          break;
      }
    }
  }
}