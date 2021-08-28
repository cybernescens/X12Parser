namespace X12.Parsing.Model.Typed
{
  /// <summary>
  ///   Carrier Detail
  /// </summary>
  public class TypedSegmentCAD : TypedSegment
  {
    public TypedSegmentCAD()
      : base("CAD") { }

    /// <summary>
    ///   K = Back Haul
    ///   M = Motor (Common Carrier)
    ///   R = Rail
    ///   U = Private Parcel Service
    ///   ZZ = Mutually Defined
    /// </summary>
    public string CAD01_TransportationMethodTypeCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string CAD02_EquipmentInitial
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string CAD03_EquipmentNumber
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string CAD04_StandardCarrierAlphaCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string CAD05_Routing
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public string CAD06_ShipmentOrderStatusCode
    {
      get => this._segment.GetElement(6);
      set => this._segment.SetElement(6, value);
    }

    public string CAD07_ReferenceIdentificationQualifier
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public string CAD08_ReferenceIdentification
    {
      get => this._segment.GetElement(8);
      set => this._segment.SetElement(8, value);
    }

    public string CAD09_ServiceLevelCode
    {
      get => this._segment.GetElement(9);
      set => this._segment.SetElement(9, value);
    }
  }
}