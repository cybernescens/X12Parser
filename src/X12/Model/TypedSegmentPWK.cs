using X12.Extensions;

namespace X12.Model
{
  public class TypedSegmentPWK : TypedSegment
  {
    public TypedSegmentPWK()
      : base("PWK") { }

    public string PWK01_ReportTypeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PWK02_ReportTransmissionCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public int? PWK03_ReportCopiesNeeded
    {
      get => this._segment.GetIntElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string PWK04_EntityIdentifierCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public EntityIdentifierCode PWK04_EntityIdentiferCodeEnum
    {
      get => this._segment.GetElement(4).ToEnumFromEdiFieldValue<EntityIdentifierCode>();
      set => this._segment.SetElement(4, value.EdiFieldValue());
    }

    public string PWK05_IdentificationCodeQualifier
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public IdentificationCodeQualifier PWK05_IdentificationCodeQualifierEnum
    {
      get => this._segment.GetElement(5).ToEnumFromEdiFieldValue<IdentificationCodeQualifier>();
      set => this._segment.SetElement(5, value.EdiFieldValue());
    }

    public string PWK06_IdentificationCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string PWK07_Description
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string PWK08_ActionsIndicated
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string PWK09_RequestCategoryCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }
  }
}