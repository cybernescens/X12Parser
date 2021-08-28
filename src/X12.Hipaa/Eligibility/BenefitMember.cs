using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Eligibility
{
  public class BenefitMember : Member
  {
    public BenefitMember()
    {
      if (Diagnoses == null) Diagnoses = new List<Lookup>();
      if (RequestValidations == null) RequestValidations = new List<RequestValidation>();
      if (Dates == null) Dates = new List<QualifiedDate>();
      if (DateRanges == null) DateRanges = new List<QualifiedDateRange>();
    }

    [XmlAttribute]
    public string BirthSequenceNumber { get; set; }

    public ProviderInformation ProviderInfo { get; set; }

    [XmlElement(ElementName = "Diagnosis")]
    public List<Lookup> Diagnoses { get; set; }

    [XmlElement(ElementName = "RequestValidation")]
    public new List<RequestValidation> RequestValidations { get; set; }

    [XmlElement(ElementName = "Date")]
    public List<QualifiedDate> Dates { get; set; }

    [XmlElement(ElementName = "DateRange")]
    public List<QualifiedDateRange> DateRanges { get; set; }

    #region PlanDate properties

    public DateTime? PlanDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "291");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "PlanDate", DataType = "date")]
    public DateTime SerializablePlanDate
    {
      get => PlanDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializablePlanDateSpecified
    {
      get => PlanDate.HasValue;
      set { }
    }

    #endregion

    #region PlanBeginDate properties

    public DateTime? PlanBeginDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "346");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "PlanBeginDate", DataType = "date")]
    public DateTime SerializablePlanBeginDate
    {
      get => PlanBeginDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializablePlanBeginDateSpecified
    {
      get => PlanBeginDate.HasValue;
      set { }
    }

    #endregion

    #region PlanEndDate properties

    public DateTime? PlanEndDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "347");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "PlanEndDate", DataType = "date")]
    public DateTime SerializablePlanEndDate
    {
      get => PlanEndDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializablePlanEndDateSpecified
    {
      get => PlanEndDate.HasValue;
      set { }
    }

    #endregion

    #region EligibilityDate properties

    public DateTime? EligibilityDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "307");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "EligibilityDate", DataType = "date")]
    public DateTime SerializableEligibilityDate
    {
      get => EligibilityDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializableEligibilityDateSpecified
    {
      get => EligibilityDate.HasValue;
      set { }
    }

    #endregion

    #region EligibilityBeginDate properties

    public DateTime? EligibilityBeginDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "356");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "EligibilityBeginDate", DataType = "date")]
    public DateTime SerializableEligibilityBeginDate
    {
      get => EligibilityBeginDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializableEligibilityBeginDateSpecified
    {
      get => EligibilityBeginDate.HasValue;
      set { }
    }

    #endregion

    #region EligibilityEndDate properties

    public DateTime? EligibilityEndDate
    {
      get {
        var date = Dates.FirstOrDefault(d => d.Qualifier == "357");
        return date == null ? null : date.Date;
      }
    }

    [XmlAttribute(AttributeName = "EligibilityEndDate", DataType = "date")]
    public DateTime SerializableEligibilityEndDate
    {
      get => EligibilityEndDate ?? DateTime.MinValue;
      set { }
    }

    [XmlIgnore]
    public bool SerializableEligibilityEndDateSpecified
    {
      get => EligibilityEndDate.HasValue;
      set { }
    }

    #endregion
  }
}