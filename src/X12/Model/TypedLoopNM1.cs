using X12.Extensions;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public class TypedLoopNM1 : TypedLoop
  {
    private readonly string _entityIdentifer;

    public TypedLoopNM1(string entityIdentifier)
      : base("NM1")
    {
      _entityIdentifer = entityIdentifier;
    }

    public string NM101_EntityIdCode
    {
      get => this._loop.GetElement(1);
      set => this._loop.SetElement(1, value);
    }

    public EntityIdentifierCode NM101_EntityIdentifierCodeEnum
    {
      get => this._loop.GetElement(1).ToEnumFromEdiFieldValue<EntityIdentifierCode>();
      set => this._loop.SetElement(1, value.EdiFieldValue());
    }

    public EntityTypeQualifier NM102_EntityTypeQualifier
    {
      get => this._loop.GetElement(2).ToEnumFromEdiFieldValue<EntityTypeQualifier>();
      set => this._loop.SetElement(2, value.EdiFieldValue());
    }

    public string NM103_NameLastOrOrganizationName
    {
      get => this._loop.GetElement(3);
      set => this._loop.SetElement(3, value);
    }

    public string NM104_NameFirst
    {
      get => this._loop.GetElement(4);
      set => this._loop.SetElement(4, value);
    }

    public string NM105_NameMiddle
    {
      get => this._loop.GetElement(5);
      set => this._loop.SetElement(5, value);
    }

    public string NM106_NamePrefix
    {
      get => this._loop.GetElement(6);
      set => this._loop.SetElement(6, value);
    }

    public string NM107_NameSuffix
    {
      get => this._loop.GetElement(7);
      set => this._loop.SetElement(7, value);
    }

    public string NM108_IdCodeQualifier
    {
      get => this._loop.GetElement(8);
      set => this._loop.SetElement(8, value);
    }

    public IdentificationCodeQualifier NM108_IdCodeQualifierEnum
    {
      get => this._loop.GetElement(8).ToEnumFromEdiFieldValue<IdentificationCodeQualifier>();
      set => this._loop.SetElement(8, value.EdiFieldValue());
    }

    public string NM109_IdCode
    {
      get => this._loop.GetElement(9);
      set => this._loop.SetElement(9, value);
    }

    public string NM110_EntityRelationshipCode
    {
      get => this._loop.GetElement(10);
      set => this._loop.SetElement(10, value);
    }

    public string NM111_EntityIdentifierCode
    {
      get => this._loop.GetElement(11);
      set => this._loop.SetElement(11, value);
    }

    public EntityIdentifierCode NM111_EntityIdentifierCodeEnum
    {
      get => this._loop.GetElement(11).ToEnumFromEdiFieldValue<EntityIdentifierCode>();
      set => this._loop.SetElement(11, value.EdiFieldValue());
    }

    public string NM112_NameLastOrOrganizationName
    {
      get => this._loop.GetElement(12);
      set => this._loop.SetElement(12, value);
    }

    internal override string GetSegmentString(X12DelimiterSet delimiters) =>
      string.Format("{0}{1}{2}", this._segmentId, delimiters.ElementSeparator, _entityIdentifer);

    internal override void Initialize(Container parent, X12DelimiterSet delimiters, LoopSpecification loopSpecification)
    {
      var segmentString = GetSegmentString(delimiters);

      this._loop = new Loop(parent, delimiters, segmentString, loopSpecification);
    }
  }
}