﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum IdentificationCodeQualifier
  {
    [EDIFieldValue("1")]
    DunsNumber_DunAndBradstreet,

    [EDIFieldValue("2")]
    StandardCarrierAlphaCode_SCAC,

    [EDIFieldValue("3")]
    FederalMaritimeCommission_Ocean__FMC,

    [EDIFieldValue("4")]
    InternationalAirTransportAssociation_IATA,

    [EDIFieldValue("5")]
    SIRET,

    [EDIFieldValue("6")]
    PlantCode,

    [EDIFieldValue("7")]
    LoadingDock,

    [EDIFieldValue("8")]
    UCC_EANGlobalProductIdentificationPrefix,

    [EDIFieldValue("9")]
    DunsPlus4,
    DunsNumberwithFourCharacterSuffix,

    [EDIFieldValue("A")]
    UsCustomsCarrierIdentification,

    [EDIFieldValue("C")]
    InsuredsChangedUniqueIdentificationNumber,

    [EDIFieldValue("D")]
    CensusScheduleD,

    [EDIFieldValue("E")]
    HazardInsurancePolicyNumber,

    [EDIFieldValue("F")]
    DocumentCustodianIdentificationNumber,

    [EDIFieldValue("G")]
    PayeeIdentificationNumber,

    [EDIFieldValue("I")]
    SecondaryMarketingInvestorAssignedNumber,

    [EDIFieldValue("J")]
    MortgageElectronicRegistrationSystemOrganizationIdentifier,

    [EDIFieldValue("K")]
    CensusScheduleK,

    [EDIFieldValue("L")]
    InvestorAssignedIdentificationNumber,

    [EDIFieldValue("N")]
    InsuredsUniqueIdentificationNumber,

    [EDIFieldValue("S")]
    TitleInsurancePolicyNumber,

    [EDIFieldValue("10")]
    DepartmentofDefenseActivityAddressCode_DODAAC,

    [EDIFieldValue("11")]
    DrugEnforcementAdministration_DEA,

    [EDIFieldValue("12")]
    TelephoneNumber_Phone,

    [EDIFieldValue("13")]
    FederalReserveRoutingCode_FRRC,

    [EDIFieldValue("14")]
    UCC_EANLocationCodePrefix,

    [EDIFieldValue("15")]
    StandardAddressNumber_SAN,

    [EDIFieldValue("16")]
    ZIPCode,

    [EDIFieldValue("17")]
    AutomatedBrokerInterface_ABI_RoutingCode,

    [EDIFieldValue("18")]
    AutomotiveIndustryActionGroup_AIAG,

    [EDIFieldValue("19")]
    FIPS_55_NamedPopulatedPlaces,

    [EDIFieldValue("20")]
    StandardPointLocationCode_SPLC,

    [EDIFieldValue("21")]
    HealthIndustryNumber_HIN,

    [EDIFieldValue("22")]
    CouncilofPetroleumAccountingSocietiescode_COPAS,

    [EDIFieldValue("23")]
    JournalofCommerce_JOC,

    [EDIFieldValue("24")]
    EmployersIdentificationNumber,

    [EDIFieldValue("25")]
    CarriersCustomerCode,

    [EDIFieldValue("26")]
    PetroleumAccountantsSocietyofCanadaCompanyCode,

    [EDIFieldValue("27")]
    GovernmentBillOfLadingOfficeCode_GBLOC,

    [EDIFieldValue("28")]
    AmericanPaperInstitute,

    [EDIFieldValue("29")]
    GridLocationandFacilityCode,

    [EDIFieldValue("30")]
    AmericanPetroleumInstituteLocationCode,

    [EDIFieldValue("31")]
    BankIdentificationCode,

    [EDIFieldValue("32")]
    AssignedbyPropertyOperator,

    [EDIFieldValue("33")]
    CommercialandGovernmentEntity_CAGE,

    [EDIFieldValue("34")]
    SocialSecurityNumber,

    [EDIFieldValue("35")]
    ElectronicMailInternalSystemAddressCode,

    [EDIFieldValue("36")]
    CustomsHouseBrokerLicenseNumber,

    [EDIFieldValue("37")]
    UnitedNationsVendorCode,

    [EDIFieldValue("38")]
    CountryCode,

    [EDIFieldValue("39")]
    LocalUnionNumber,

    [EDIFieldValue("40")]
    ElectronicMailUserCode,

    [EDIFieldValue("41")]
    TelecommunicationsCarrierIdentificationCode,

    [EDIFieldValue("42")]
    TelecommunicationsPseudoCarrierIdentificationCode,

    [EDIFieldValue("43")]
    AlternateSocialSecurityNumber,

    [EDIFieldValue("44")]
    ReturnSequenceNumber,

    [EDIFieldValue("45")]
    DeclarationControlNumber,

    [EDIFieldValue("46")]
    ElectronicTransmitterIdentificationNumber_ETIN,

    [EDIFieldValue("47")]
    TaxAuthorityIdentification,

    [EDIFieldValue("48")]
    ElectronicFilerIdentificationNumber_EFIN,

    [EDIFieldValue("49")]
    StateIdentificationNumber,

    [EDIFieldValue("50")]
    BusinessLicenseNumber,

    [EDIFieldValue("53")]
    Building,

    [EDIFieldValue("54")]
    Warehouse,

    [EDIFieldValue("55")]
    PostOfficeBox,

    [EDIFieldValue("56")]
    Division,

    [EDIFieldValue("57")]
    Department,

    [EDIFieldValue("58")]
    OriginatingCompanyNumber,

    [EDIFieldValue("59")]
    ReceivingCompanyNumber,

    [EDIFieldValue("61")]
    HoldingMortgageeNumber,

    [EDIFieldValue("62")]
    ServicingMortgageeNumber,

    [EDIFieldValue("63")]
    Servicer_holderMortgageeNumber,

    [EDIFieldValue("64")]
    OneCallAgency,

    [EDIFieldValue("71")]
    IntegratedPostsecondaryEducationDataSystem_IPEDS,

    [EDIFieldValue("72")]
    TheCollegeBoardsAdmissionTestingProgram_ATP,

    [EDIFieldValue("73")]
    FederalInteragencyCommissiononEducation_FICE,

    [EDIFieldValue("74")]
    AmericanCollegeTesting_ACT_listofpostsecondaryeducationalinstitutions,

    [EDIFieldValue("75")]
    StateorProvinceAssignedNumber,

    [EDIFieldValue("76")]
    LocalSchoolDistrictorJurisdictionNumber,

    [EDIFieldValue("77")]
    NationalCenterforEducationStatistics_NCES_CommonCoreofData_CCD_number,

    [EDIFieldValue("78")]
    TheCollegeBoardandACT6digitcodelistofsecondaryeducationalinstitutions,

    [EDIFieldValue("81")]
    ClassificationofInstructionalPrograms_CIP_codingstructuremaintainedbytheUsDepartme,

    [EDIFieldValue("82")]
    HigherEducationGeneralInformationSurvey_HEGIS_maintainedbytheUsDepartmentofEducat,

    [EDIFieldValue("90")]
    CaliforniaEthnicSubgroupsCodeTable,

    [EDIFieldValue("91")]
    AssignedbySellerorSellersAgent,

    [EDIFieldValue("92")]
    AssignedbyBuyerorBuyersAgent,

    [EDIFieldValue("93")]
    Codeassignedbytheorganizationoriginatingthetransactionset,

    [EDIFieldValue("94")]
    Codeassignedbytheorganizationthatistheultimatedestinationofthetransactionset,

    [EDIFieldValue("95")]
    AssignedByTransporter,

    [EDIFieldValue("96")]
    AssignedByPipelineOperator,

    [EDIFieldValue("97")]
    ReceiversCode,

    [EDIFieldValue("98")]
    PurchasingOffice,

    [EDIFieldValue("99")]
    OfficeofWorkersCompensationPrograms_OWCP_AgencyCode,

    [EDIFieldValue("A1")]
    ApproverID,

    [EDIFieldValue("A2")]
    MilitaryAssistanceProgramAddressCode_MAPAC,

    [EDIFieldValue("A3")]
    AssignedbyThirdParty,

    [EDIFieldValue("A4")]
    AssignedbyClearinghouse,

    [EDIFieldValue("A5")]
    CommitteeforUniformSecurityIdentificationProcedures_CUSIP_Number,

    [EDIFieldValue("A6")]
    FinancialIdentificationNumberingSystem_FINS_Number,

    [EDIFieldValue("AA")]
    PostalServiceCode,

    [EDIFieldValue("AB")]
    USEnvironmentalProtectionAgency_EPA_IdentificationNumber,

    [EDIFieldValue("AC")]
    AttachmentControlNumber,

    [EDIFieldValue("AD")]
    BlueCrossBlueShieldAssociationPlanCode,

    [EDIFieldValue("AE")]
    AlbertaEnergyResourcesConservationBoard,

    [EDIFieldValue("AL")]
    AnesthesiaLicenseNumber,

    [EDIFieldValue("AP")]
    AlbertaPetroleumMarketingCommission,

    [EDIFieldValue("BC")]
    BritishColumbiaMinistryofEnergyMinesandPetroleumResources,

    [EDIFieldValue("BD")]
    BlueCrossProviderNumber,

    [EDIFieldValue("BE")]
    CommonLanguageLocationIdentification_CLLI,

    [EDIFieldValue("BG")]
    BadgeNumber,

    [EDIFieldValue("BP")]
    BenefitPlan,

    [EDIFieldValue("BS")]
    BlueShieldProviderNumber,

    [EDIFieldValue("C1")]
    InsuredorSubscriber,

    [EDIFieldValue("C2")]
    HealthMaintenanceOrganization_HMO_ProviderNumber,

    [EDIFieldValue("C5")]
    CustomerIdentificationFile,

    [EDIFieldValue("CA")]
    StatisticsCanadaCanadianCollegeStudentInformationSystemCourseCodes,

    [EDIFieldValue("CB")]
    StatisticsCanadaCanadianCollegeStudentInformationSystemInstitutionCodes,

    [EDIFieldValue("CC")]
    StatisticsCanadaUniversityStudentInformationSystemCurriculumCodes,

    [EDIFieldValue("CD")]
    ContractDivision,

    [EDIFieldValue("CE")]
    BureauoftheCensusFilerIdentificationCode,

    [EDIFieldValue("CF")]
    CanadianFinancialInstitutionRoutingNumber,

    [EDIFieldValue("CI")]
    CHAMPUS_CivilianHealthandMedicalProgramoftheUniformedServices_IdentificationNumber,

    [EDIFieldValue("CL")]
    CorrectedLoanNumber,

    [EDIFieldValue("CM")]
    UsCustomsService_USCS_ManufacturerIdentifier_MID,

    [EDIFieldValue("CP")]
    CanadianPetroleumAssociation,

    [EDIFieldValue("CR")]
    CreditRepository,

    [EDIFieldValue("CS")]
    StatisticsCanadaUniversityStudentInformationSystemUniversityCodes,

    [EDIFieldValue("CT")]
    CourtIdentificationCode,

    [EDIFieldValue("DG")]
    UnitedStatesDepartmentofEducationGuarantorIdentificationCode,

    [EDIFieldValue("DL")]
    UnitedStatesDepartmentofEducationLenderIdentificationCode,

    [EDIFieldValue("DN")]
    DentistLicenseNumber,

    [EDIFieldValue("DP")]
    DataProcessingPoint,

    [EDIFieldValue("DS")]
    UnitedStatesDepartmentofEducationSchoolIdentificationCode,

    [EDIFieldValue("EC")]
    ARIElectronicCommerceLocationIDCode,

    [EDIFieldValue("EH")]
    TheatreNumber,

    [EDIFieldValue("EI")]
    EmployeeIdentificationNumber,

    [EDIFieldValue("EP")]
    UsEnvironmentalProtectionAgency_EPA_,

    [EDIFieldValue("EQ")]
    InsuranceCompanyAssignedIdentificationNumber,

    [EDIFieldValue("ER")]
    MortgageeAssignedIdentificationNumber,

    [EDIFieldValue("ES")]
    AutomatedExportSystem_AES_FilerIdentificationCode,

    [EDIFieldValue("FA")]
    FacilityIdentification,

    [EDIFieldValue("FB")]
    FieldCode,

    [EDIFieldValue("FC")]
    FederalCourtJurisdictionIdentifier,

    [EDIFieldValue("FD")]
    FederalCourtDivisionalOfficeNumber,

    [EDIFieldValue("FI")]
    FederalTaxpayersIdentificationNumber,

    [EDIFieldValue("FJ")]
    FederalJurisdiction,

    [EDIFieldValue("FN")]
    UsEnvironmentalProtectionAgency_EPA_LaboratoryCertificationIdentification,

    [EDIFieldValue("GA")]
    PrimaryAgentIdentification,

    [EDIFieldValue("GC")]
    GasCode,

    [EDIFieldValue("HC")]
    HealthCareFinancingAdministration,

    [EDIFieldValue("HN")]
    HealthInsuranceClaim_HIC_Number,

    [EDIFieldValue("LC")]
    AgencyLocationCode_UsGovernment,

    [EDIFieldValue("LD")]
    NISOZ39_53LanguageCodes,

    [EDIFieldValue("LE")]
    ISO639LanguageCodes,

    [EDIFieldValue("LI")]
    LabelerIdentificationCode_LIC,

    [EDIFieldValue("LN")]
    LoanNumber,

    [EDIFieldValue("M3")]
    DisbursingStation,

    [EDIFieldValue("M4")]
    DepartmentofDefenseRoutingIdentifierCode_RIC,

    [EDIFieldValue("M5")]
    JurisdictionCode,

    [EDIFieldValue("M6")]
    DivisionOfficeCode,

    [EDIFieldValue("MA")]
    MailStop,

    [EDIFieldValue("MB")]
    MedicalInformationBureau,

    [EDIFieldValue("MC")]
    MedicaidProviderNumber,

    [EDIFieldValue("MD")]
    ManitobaDepartmentofMinesandResources,

    [EDIFieldValue("MI")]
    MemberIdentificationNumber,

    [EDIFieldValue("MK")]
    Market,

    [EDIFieldValue("ML")]
    MultipleListingServiceVendor_MultipleListingServiceIdentification,

    [EDIFieldValue("MN")]
    MortgageIdentificationNumber,

    [EDIFieldValue("MP")]
    MedicareProviderNumber,

    [EDIFieldValue("MR")]
    MedicaidRecipientIdentificationNumber,

    [EDIFieldValue("NA")]
    NationalAssociationofRealtors_MultipleListingServiceIdentification,

    [EDIFieldValue("ND")]
    ModeDesignator,

    [EDIFieldValue("NI")]
    NationalAssociationofInsuranceCommissioners_NAIC_Identification,

    [EDIFieldValue("NO")]
    NationalCriminalInformationCenterOriginatingAgency,

    [EDIFieldValue("OC")]
    OccupationCode,

    [EDIFieldValue("OP")]
    On_linePaymentandCollection,

    [EDIFieldValue("PA")]
    SecondaryAgentIdentification,

    [EDIFieldValue("PB")]
    PublicIdentification,

    [EDIFieldValue("PC")]
    ProviderCommercialNumber,

    [EDIFieldValue("PI")]
    PayorIdentification,

    [EDIFieldValue("PP")]
    PharmacyProcessorNumber,

    [EDIFieldValue("PR")]
    Pier,

    [EDIFieldValue("RA")]
    RegulatoryAgencyNumber,

    [EDIFieldValue("RB")]
    RealEstateAgent,

    [EDIFieldValue("RC")]
    RealEstateCompany,

    [EDIFieldValue("RD")]
    RealEstateBrokerIdentification,

    [EDIFieldValue("RE")]
    RealEstateLicenseNumber,

    [EDIFieldValue("RT")]
    RailroadTrack,

    [EDIFieldValue("SA")]
    TertiaryAgentIdentification,

    [EDIFieldValue("SB")]
    SocialInsuranceNumber,

    [EDIFieldValue("SD")]
    SaskatchewanDepartmentofEnergyMinesandResources,

    [EDIFieldValue("SF")]
    SuffixCode,

    [EDIFieldValue("SI")]
    StandardIndustryCode_SIC,

    [EDIFieldValue("SJ")]
    StateJurisdiction,

    [EDIFieldValue("SL")]
    StateLicenseNumber,

    [EDIFieldValue("SP")]
    SpecialtyLicenseNumber,

    [EDIFieldValue("ST")]
    State_ProvinceLicenseTag,

    [EDIFieldValue("SV")]
    ServiceProviderNumber,

    [EDIFieldValue("SW")]
    SocietyforWorldwideInterbankFinancialTelecommunications_SWIFT_Address,

    [EDIFieldValue("TA")]
    TaxpayerIDNumber,

    [EDIFieldValue("TC")]
    InternalRevenueServiceTerminalCode,

    [EDIFieldValue("TZ")]
    DepartmentCode,

    [EDIFieldValue("UC")]
    ConsumerCreditIdentificationNumber,

    [EDIFieldValue("UL")]
    UCC_EANLocationCode,

    [EDIFieldValue("UM")]
    UCC_EANLocationCodeSuffix,

    [EDIFieldValue("UP")]
    UniquePhysicianIdentificationNumber_UPIN,

    [EDIFieldValue("UR")]
    UniformResourceLocator_URL,

    [EDIFieldValue("US")]
    UniqueSupplierIdentificationNumber_USIN,

    [EDIFieldValue("WR")]
    WineRegionCode,

    [EDIFieldValue("XV")]
    HealthCareFinancingAdministrationNationalPayerIdentificationNumber_PAYERID,

    [EDIFieldValue("XX")]
    HealthCareFinancingAdministrationNationalProviderIdentifier,

    [EDIFieldValue("ZC")]
    ContractorEstablishmentCode,

    [EDIFieldValue("ZN")]
    Zone,

    [EDIFieldValue("ZY")]
    TemporaryIdentificationNumber,

    [EDIFieldValue("ZZ")]
    MutuallyDefined
  }
}