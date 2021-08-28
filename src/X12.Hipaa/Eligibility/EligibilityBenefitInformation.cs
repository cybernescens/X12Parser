using System.Collections.Generic;
using System.Xml.Serialization;
using X12.Hipaa.Common;

namespace X12.Hipaa.Eligibility
{
  public class EligibilityBenefitInformation
  {
    public EligibilityBenefitInformation()
    {
      if (Identifications == null) Identifications = new List<Identification>();
      if (RequestValidations == null) RequestValidations = new List<RequestValidation>();
      if (Dates == null) Dates = new List<QualifiedDate>();
      if (DateRanges == null) DateRanges = new List<QualifiedDateRange>();
      if (Messages == null) Messages = new List<string>();
      if (RelatedEntities == null) RelatedEntities = new List<RelatedEntity>();
    }

    public string ServiceTypeCount { get; set; }

    [XmlIgnore]
    public decimal? Amount { get; set; }

    [XmlIgnore]
    public decimal? Percentage { get; set; }

    public Lookup InfoType { get; set; }
    public Lookup CoverageLevel { get; set; }

    [XmlElement(ElementName = "ServiceType")]
    public List<Lookup> ServiceTypes { get; set; }

    public Lookup InsuranceType { get; set; }
    public string PlanCoverageDescription { get; set; }
    public Lookup TimePeriod { get; set; }
    public QualifiedAmount Quantity { get; set; }
    public Lookup InPlanNetwork { get; set; }
    public Lookup AuthorizationCertificationRequired { get; set; }
    public MedicalProcedure Procedure { get; set; }

    [XmlElement(ElementName = "Identification")]
    public List<Identification> Identifications { get; set; }

    [XmlElement(ElementName = "RequestValidation")]
    public List<RequestValidation> RequestValidations { get; set; }

    [XmlElement(ElementName = "Date")]
    public List<QualifiedDate> Dates { get; set; }

    [XmlElement(ElementName = "DateRange")]
    public List<QualifiedDateRange> DateRanges { get; set; }

    [XmlElement(ElementName = "Message")]
    public List<string> Messages { get; set; }

    [XmlElement(ElementName = "AdditionalInfo")]
    public List<EligibilityBenefitAdditionalInformation> AdditionalInfos { get; set; }

    [XmlElement(ElementName = "RelatedEntity")]
    public List<RelatedEntity> RelatedEntities { get; set; }

    #region Serializable Amount properties

    [XmlAttribute(AttributeName = "Amount")]
    public decimal SerializableAmount
    {
      get => Amount ?? decimal.Zero;
      set => Amount = value;
    }

    [XmlIgnore]
    public bool SerializableAmountSpecified
    {
      get => Amount.HasValue;
      set { }
    }

    #endregion

    #region Serializable Percentage properties

    [XmlAttribute(AttributeName = "Percentage")]
    public decimal SerializablePercentage
    {
      get => Percentage ?? decimal.Zero;
      set => Percentage = value;
    }

    [XmlIgnore]
    public bool SerializablePercentageSpecified
    {
      get => Percentage.HasValue;
      set { }
    }

    #endregion
  }
}