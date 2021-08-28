using System.Collections.Generic;

namespace X12.Hipaa.Claims.Forms.Dental
{
  #if DEBUG
  internal class J515Claim
  {
    /*
     * 2011/8/16, jhalliday - New Data Model for 837D (Dental) claim.
     * 
     * Team: dstrubhar, jhalliday and epkrause
     * 
     * Purpose:
     * To create a C# object model that will serve as a container for the X12 837D data
     * AS ENTERED from a J515 (ADA Dental Claim Form) dental claim form.
     * 
     * Goal:
     * The team has the overall goal of creating tools that can be used to consume and
     * manipulate X12 messages (AKA files/documents) without the need to have a big project
     * budget.  For that reason, this and the related X12 Parser project tools are all open
     * source and freely usable.

     * Fields in the J515 object model are defined in the order they appear on the J515 form.
     * 
     * Field Descriptions:   (putting this here instead of commenting each field)
     * 
     * 1. 
     */

    // First, we will declare the private variables.  Then the properties and their accessors.

    public string Field01_TypeOfTransaction { get; set; }

    public string Field02_PredeterminationOrPreauthorizationNumber { get; set; }

    public string Field03_PrimaryPayer_Name { get; set; }

    public string Field03_PrimaryPayer_Address { get; set; }

    public string Field03_PrimaryPayer_City { get; set; }

    public string Field03_PrimaryPayer_State { get; set; }

    public string Field03_PrimaryPayer_Zip { get; set; }

    public string Field04_OtherDentalOrMedicalCoverage { get; set; }

    public string Field05_SubscriberName_Last { get; set; }

    public string Field05_SubscriberName_First { get; set; }

    public string Field05_SubscriberName_Middle { get; set; }

    public string Field05_SubscriberName_Suffix { get; set; }

    public string Field06_DateOfBirth { get; set; }

    public string Field07_Gender { get; set; }

    public string Field08_SubscriberIdentifier { get; set; }

    public string Field09_PlanOrGroupNumber { get; set; }

    public string Field10_RelationshipToPrimarySubscriber_Self { get; set; }

    public string Field10_RelationshipToPrimarySubscriber_Spouse { get; set; }

    public string Field10_RelationshipToPrimarySubscriber_Dependent { get; set; }

    public string Field10_RelationshipToPrimarySubscriber_Other { get; set; }

    public string Field11_OtherCarrier_Name { get; set; }

    public string Field11_OtherCarrier_Address { get; set; }

    public string Field11_OtherCarrier_City { get; set; }

    public string Field11_OtherCarrier_State { get; set; }

    public string Field11_OtherCarrier_Zip { get; set; }

    public string Field12_PrimarySubscriberName_Last { get; set; }

    public string Field12_PrimarySubscriberName_First { get; set; }

    public string Field12_PrimarySubscriberName_Middle { get; set; }

    public string Field12_PrimarySubscriberName_Suffix { get; set; }

    public string Field12_PrimarySubscriber_Address { get; set; }

    public string Field12_PrimarySubscriber_City { get; set; }

    public string Field12_PrimarySubscriber_State { get; set; }

    public string Field12_PrimarySubscriber_Zip { get; set; }

    public string Field13_PrimarySubscriberDateOfBirth { get; set; }

    public string Field14_Gender { get; set; }

    public string Field15_SubscriberIdentifier { get; set; }

    public string Field16_PlanOrGroupNumber { get; set; }

    public string Field17_EmployerName { get; set; }

    public string Field18_RelationshipToPrimarySubscriber { get; set; }

    public string Field19_StudentStatus { get; set; }

    public string Field20_PatientName_Last { get; set; }

    public string Field20_PatientName_First { get; set; }

    public string Field20_PatientName_Middle { get; set; }

    public string Field20_PatientName_Suffix { get; set; }

    public string Field20_PatientAddress { get; set; }

    public string Field20_PatientCity { get; set; }

    public string Field20_PatientState { get; set; }

    public string Field20_PatientZip { get; set; }

    public string Field21_PatientDateOfBirth { get; set; }

    public string Field22_PatientGender { get; set; }

    public string Field23_PatientID_OrAccountNumber { get; set; }

    public List<J515ServiceLines> Field24_31_ServiceLines { get; set; }

    public decimal Field32_OtherFees { get; set; }

    public decimal Field33_TotalFees { get; set; }

    public List<Field34_MissingTeethInfo_Permanent> Field34_MissingTeethInfo_Permanent { get; set; }

    public List<Field34_MissingTeethInfo_Primary> Field34_MissingTeethInfo_Primary { get; set; }

    public string Field35_Remarks { get; set; }

    public string Field36_Authorizations_PatientGuardianSignature { get; set; }

    public string Field36_Authorizations_PatientGuardianSignatureDate { get; set; }

    public string Field37_Authorizations_SubscriberSignature { get; set; }

    public string Field37_Authorizations_SubscriberSignatureDate { get; set; }

    public string Field38_PlaceOfTreatment { get; set; }

    public string Field39_NumberOfEnclosures_Radiographs { get; set; }

    public string Field39_NumberOfEnclosures_OralImages { get; set; }

    public string Field39_NumberOfEnclosures_Models { get; set; }

    public string Field40_IsTreatmentForOrthodontics { get; set; }

    public string Field41_DateAppliancePlaced { get; set; }

    public string Field42_MonthsOfTreatmentRemaining { get; set; }

    public string Field43_ReplacementOfProsthesis { get; set; }

    public string Field44_DatePriorReplacement { get; set; }

    public string Field45_TreatmentResultingFrom_OccupationalIllnessOrInjury { get; set; }

    public string Field45_TreatmentResultingFrom_AutoAccident { get; set; }

    public string Field45_TreatmentResultingFrom_OtherAccident { get; set; }

    public string Field46_DateOfAccident { get; set; }

    public string Field47_AutoAccidentState { get; set; }

    public string Field48_BillingDentistOrDentalEntity_Name { get; set; }

    public string Field48_BillingDentistOrDentalEntity_Address { get; set; }

    public string Field48_BillingDentistOrDentalEntity_City { get; set; }

    public string Field48_BillingDentistOrDentalEntity_State { get; set; }

    public string Field48_BillingDentistOrDentalEntity_Zip { get; set; }

    public string Field49_BillingProviderID { get; set; }

    public string Field50_BillingProviderLicenseNumber { get; set; }

    public string Field51_ProviderSSN_OrTaxIDNumber { get; set; }

    public string Field52_ProviderPhone_AreaCode { get; set; }

    public string Field52_ProviderPhone_Number { get; set; }

    public string Field53_TreatingDentistSignature { get; set; }

    public string Field53_TreatingDentistSignatureDate { get; set; }

    public string Field54_PerformingProviderID { get; set; }

    public string Field55_PerformingProviderLicenseNumber { get; set; }

    public string Field56_PerformingProviderAddress { get; set; }

    public string Field56_PerformingProviderCity { get; set; }

    public string Field56_PerformingProviderState { get; set; }

    public string Field56_PerformingProviderZip { get; set; }

    public string Field57_PerformingProviderPhone_AreaCode { get; set; }

    public string Field57_PerformingProviderPhone_Number { get; set; }

    public string Field58_TreatingProviderSpecialty { get; set; }
  }
  #endif
}