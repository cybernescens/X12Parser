using System;

namespace X12.Parsing.Model.Typed
{
  public class TypedSegmentPAT : TypedSegment
  {
    public TypedSegmentPAT()
      : base("PAT") { }

    public string PAT01_IndividualRelationshipCode
    {
      get => this._segment.GetElement(1);
      set => this._segment.SetElement(1, value);
    }

    public string PAT02_PatientLocationCode
    {
      get => this._segment.GetElement(2);
      set => this._segment.SetElement(2, value);
    }

    public string PAT03_EmploymentStatusCode
    {
      get => this._segment.GetElement(3);
      set => this._segment.SetElement(3, value);
    }

    public string PAT04_StudentStatusCode
    {
      get => this._segment.GetElement(4);
      set => this._segment.SetElement(4, value);
    }

    public string PAT05_DateTimePeriodFormatQualifier
    {
      get => this._segment.GetElement(5);
      set => this._segment.SetElement(5, value);
    }

    public DateTime? PAT06_DateOfDeath
    {
      get {
        var element = this._segment.GetElement(6);
        if (element.Length == 8)
          return DateTime.ParseExact(element, "yyyyMMdd", null);

        return null;
      }
      set => this._segment.SetElement(6, string.Format("{0:yyyyMMdd}", value));
    }

    public string PAT07_UnitOrBasisForMeasurementCode
    {
      get => this._segment.GetElement(7);
      set => this._segment.SetElement(7, value);
    }

    public decimal? PAT08_PatientWeight
    {
      get {
        decimal weight;
        if (decimal.TryParse(this._segment.GetElement(8), out weight))
          return weight;

        return null;
      }
      set => this._segment.SetElement(8, string.Format("{0}", value));
    }

    public bool? PAT09_PregnancyIndicator
    {
      get {
        switch (this._segment.GetElement(9))
        {
          case "Y": return true;
          case "N": return false;
          default:  return null;
        }
      }
      set {
        if (value.HasValue)
          this._segment.SetElement(9, value.Value ? "Y" : "N");
        else
          this._segment.SetElement(9, "");
      }
    }

    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      //PAT05_DateTimePeriodFormatQualifier = "D8";
    }
  }
}