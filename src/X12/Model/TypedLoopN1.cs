using X12.Extensions;

namespace X12.Model
{
  public class TypedLoopN1 : TypedLoop
  {
    public TypedLoopN1()
      : base("N1") { }

    public string N101_EntityIdentifierCode
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public EntityIdentifierCode N101_EntityIdentifierCodeEnum
    {
      get => this._loop.GetElement(1).ToEnumFromEdiFieldValue<EntityIdentifierCode>();
      set => this._loop.SetElement(1, value.EdiFieldValue());
    }

    public string N102_Name
    {
      get => this._loop.GetElement(2);
      set => this._loop.SetElement(2, value);
    }

    public string N103_IdentificationCodeQualifier
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public IdentificationCodeQualifier N103_IdentificationCodeQualifierEnum
    {
      get => this._loop.GetElement(3).ToEnumFromEdiFieldValue<IdentificationCodeQualifier>();
      set => this._loop.SetElement(3, value.EdiFieldValue());
    }

    public string N104_IdentificationCode
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    public string N105_EntityRelationshipCode
    {
      get => this._loop.GetElement(5);
      set => this._loop.SetElement(5, value);
    }

    public string N106_EntityIdentifierCode
    {
      get => this._loop.GetElement(6);
      set => this._loop.SetElement(6, value);
    }

    public EntityIdentifierCode N106_EntityIdentifierCodeEnum
    {
      get => this._loop.GetElement(6).ToEnumFromEdiFieldValue<EntityIdentifierCode>();
      set => this._loop.SetElement(6, value.EdiFieldValue());
    }
  }
}