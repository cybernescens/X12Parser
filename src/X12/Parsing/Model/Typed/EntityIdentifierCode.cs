﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum EntityIdentifierCode
  {
    [EDIFieldValue("01")]
    LoanApplicant,

    [EDIFieldValue("02")]
    LoanBroker,

    [EDIFieldValue("03")]
    Dependent,

    [EDIFieldValue("04")]
    AssetAccountHolder,

    [EDIFieldValue("05")]
    Tenant,

    [EDIFieldValue("06")]
    RecipientOfCivilOrLegalLiabilityPayment,

    [EDIFieldValue("07")]
    Titleholder,

    [EDIFieldValue("08")]
    NonMortgageLiabilityAccountHolder,

    [EDIFieldValue("09")]
    NoteCo_Signer,

    [EDIFieldValue("0A")]
    ComparableRentals,

    [EDIFieldValue("0B")]
    InterimFundingOrganization,

    [EDIFieldValue("0D")]
    NonOccupantCoBorrower,

    [EDIFieldValue("0E")]
    ListOwner,

    [EDIFieldValue("0F")]
    ListMailer,

    [EDIFieldValue("0H")]
    StateDivision,

    [EDIFieldValue("10")]
    Conduit,

    [EDIFieldValue("11")]
    PartyToBeBilled_AARAccountingRule11,

    [EDIFieldValue("12")]
    RegionalOffice,

    [EDIFieldValue("13")]
    ContractedServiceProvider,

    [EDIFieldValue("14")]
    WhollyOwnedSubsidiary,

    [EDIFieldValue("15")]
    AccountsPayableOffice,

    [EDIFieldValue("16")]
    Plant,

    [EDIFieldValue("17")]
    ConsultantsOffice,

    [EDIFieldValue("18")]
    Production,

    [EDIFieldValue("19")]
    NonProductionSupplier,

    [EDIFieldValue("1A")]
    Subgroup,

    [EDIFieldValue("1B")]
    Applicant,

    [EDIFieldValue("1C")]
    GroupPurchasingOrganization_GPO,

    [EDIFieldValue("1D")]
    CoOperative,

    [EDIFieldValue("1E")]
    HealthMaintenanceOrganization_HMO,

    [EDIFieldValue("1F")]
    Alliance,

    [EDIFieldValue("1G")]
    OncologyCenter,

    [EDIFieldValue("1H")]
    KidneyDialysisUnit,

    [EDIFieldValue("1I")]
    PreferredProviderOrganization_PPO,

    [EDIFieldValue("1J")]
    Connection,

    [EDIFieldValue("1K")]
    Franchisor,

    [EDIFieldValue("1L")]
    Franchisee,

    [EDIFieldValue("1M")]
    PreviousGroup,

    [EDIFieldValue("1N")]
    Shareholder,

    [EDIFieldValue("1O")]
    AcuteCareHospital,

    [EDIFieldValue("1P")]
    Provider,

    [EDIFieldValue("1Q")]
    MilitaryFacility,

    [EDIFieldValue("1R")]
    University_CollegeOrSchool,

    [EDIFieldValue("1S")]
    OutpatientSurgicenter,

    [EDIFieldValue("1T")]
    Physician_ClinicOrGroupPractice,

    [EDIFieldValue("1U")]
    LongTermCareFacility,

    [EDIFieldValue("1V")]
    ExtendedCareFacility,

    [EDIFieldValue("1W")]
    PsychiatricHealthFacility,

    [EDIFieldValue("1X")]
    Laboratory,

    [EDIFieldValue("1Y")]
    RetailPharmacy,

    [EDIFieldValue("1Z")]
    HomeHealthCare,

    [EDIFieldValue("20")]
    ForeignSupplier,

    [EDIFieldValue("21")]
    SmallBusiness,

    [EDIFieldValue("22")]
    MinorityOwnedBusiness_Small,

    [EDIFieldValue("23")]
    MinorityOwnedBusiness_Large,

    [EDIFieldValue("24")]
    WomanOwnedBusiness_Small,

    [EDIFieldValue("25")]
    WomanOwnedBusiness_Large,

    [EDIFieldValue("26")]
    SociallyDisadvantagedBusiness,

    [EDIFieldValue("27")]
    SmallDisadvantagedBusiness,

    [EDIFieldValue("28")]
    Subcontractor,

    [EDIFieldValue("29")]
    PrototypeSupplier,

    [EDIFieldValue("2A")]
    FederalStateCountyOrCityFacility,

    [EDIFieldValue("2B")]
    ThirdPartyAdministrator,

    [EDIFieldValue("2C")]
    CoParticipant,

    [EDIFieldValue("2D")]
    MiscellaneousHealthCareFacility,

    [EDIFieldValue("2E")]
    NonHealthCareMiscellaneousFacility,

    [EDIFieldValue("2F")]
    State,

    [EDIFieldValue("2G")]
    Assigner,

    [EDIFieldValue("2H")]
    HospitalDistrictOrAuthority,

    [EDIFieldValue("2I")]
    ChurchOperatedFacility,

    [EDIFieldValue("2J")]
    Individual,

    [EDIFieldValue("2K")]
    Partnership,

    [EDIFieldValue("2L")]
    Corporation,

    [EDIFieldValue("2M")]
    AirForceFacility,

    [EDIFieldValue("2N")]
    ArmyFacility,

    [EDIFieldValue("2O")]
    NavyFacility,

    [EDIFieldValue("2P")]
    PublicHealthServiceFacility,

    [EDIFieldValue("2Q")]
    VeteransAdministrationFacility,

    [EDIFieldValue("2R")]
    FederalFacility,

    [EDIFieldValue("2S")]
    PublicHealthServiceIndianServiceFacility,

    [EDIFieldValue("2T")]
    DepartmentOfJusticeFacility,

    [EDIFieldValue("2U")]
    OtherNotForProfitFacility,

    [EDIFieldValue("2V")]
    IndividualForProfitFacility,

    [EDIFieldValue("2W")]
    PartnershipForProfitFacility,

    [EDIFieldValue("2X")]
    CorporationForProfitFacility,

    [EDIFieldValue("2Y")]
    GeneralMedicalAndSurgicalFacility,

    [EDIFieldValue("2Z")]
    HospitalUnitOfAnInstitution_PrisonHospital_CollegeInfirmary_Etc,

    [EDIFieldValue("30")]
    ServiceSupplier,

    [EDIFieldValue("31")]
    PostalMailingAddress,

    [EDIFieldValue("32")]
    PartyToReceiveMaterialRelease,

    [EDIFieldValue("33")]
    InquiryAddress,

    [EDIFieldValue("34")]
    MaterialChangeNoticeAddress,

    [EDIFieldValue("35")]
    ElectronicDataInterchange_EDI_CoordinatorPointAddress,

    [EDIFieldValue("36")]
    Employer,

    [EDIFieldValue("37")]
    PreviousDebtHolder,

    [EDIFieldValue("38")]
    MortgageLiabilityAccountHolder,

    [EDIFieldValue("39")]
    AppraisalCompany,

    [EDIFieldValue("3A")]
    HospitalUnitWithinanInstitutionfortheMentallyRetarded,

    [EDIFieldValue("3B")]
    PsychiatricFacility,

    [EDIFieldValue("3C")]
    TuberculosisAndOtherRespiratoryDiseasesFacility,

    [EDIFieldValue("3D")]
    ObstetricsAndGynecologyFacility,

    [EDIFieldValue("3E")]
    Eye_Ear_NoseAndThroatFacility,

    [EDIFieldValue("3F")]
    RehabilitationFacility,

    [EDIFieldValue("3G")]
    OrthopedicFacility,

    [EDIFieldValue("3H")]
    ChronicDiseaseFacility,

    [EDIFieldValue("3I")]
    OtherSpecialtyFacility,

    [EDIFieldValue("3J")]
    ChildrensGeneralFacility,

    [EDIFieldValue("3K")]
    ChildrensHospitalUnitOfanInstitution,

    [EDIFieldValue("3L")]
    ChildrensPsychiatricFacility,

    [EDIFieldValue("3M")]
    ChildrensTuberculosisAndOtherRespiratoryDiseasesFacility,

    [EDIFieldValue("3N")]
    ChildrensEyeEarNoseAndThroatFacility,

    [EDIFieldValue("3O")]
    ChildrensRehabilitationFacility,

    [EDIFieldValue("3P")]
    ChildrensOrthopedicFacility,

    [EDIFieldValue("3Q")]
    ChildrensChronicDiseaseFacility,

    [EDIFieldValue("3R")]
    ChildrensOtherSpecialtyFacility,

    [EDIFieldValue("3S")]
    InstitutionforMentalRetardation,

    [EDIFieldValue("3T")]
    AlcoholismAndOtherChemicalDependencyFacility,

    [EDIFieldValue("3U")]
    GeneralInpatientCareforAIDSARCFacility,

    [EDIFieldValue("3V")]
    AIDSARCUnit,

    [EDIFieldValue("3W")]
    SpecializedOutpatientProgramforAIDSARC,

    [EDIFieldValue("3X")]
    AlcoholDrugAbuseOrDependencyInpatientUnit,

    [EDIFieldValue("3Y")]
    AlcoholDrugAbuseOrDependencyOutpatientServices,

    [EDIFieldValue("3Z")]
    ArthritisTreatmentCenter,

    [EDIFieldValue("40")]
    Receiver,

    [EDIFieldValue("41")]
    Submitter,

    [EDIFieldValue("42")]
    ComponentManufacturer,

    [EDIFieldValue("43")]
    ClaimantAuthorizedRepresentative,

    [EDIFieldValue("44")]
    DataProcessingServiceBureau,

    [EDIFieldValue("45")]
    DropOffLocation,

    [EDIFieldValue("46")]
    InvoicingDealer,

    [EDIFieldValue("47")]
    Estimator,

    [EDIFieldValue("48")]
    InServiceSource,

    [EDIFieldValue("49")]
    InitialDealer,

    [EDIFieldValue("4A")]
    BirthingRoomLDRPRoom,

    [EDIFieldValue("4B")]
    BurnCareUnit,

    [EDIFieldValue("4C")]
    CardiacCatherizationLaboratory,

    [EDIFieldValue("4D")]
    OpenHeartSurgeryFacility,

    [EDIFieldValue("4E")]
    CardiacIntensiveCareUnit,

    [EDIFieldValue("4F")]
    AngioplastyFacility,

    [EDIFieldValue("4G")]
    ChronicObstructivePulmonaryDiseaseServiceFacility,

    [EDIFieldValue("4H")]
    EmergencyDepartment,

    [EDIFieldValue("4I")]
    TraumaCenter_Certified,

    [EDIFieldValue("4J")]
    ExtracorporealShock_WaveLithotripter_ESWL_Unit,

    [EDIFieldValue("4K")]
    FitnessCenter,

    [EDIFieldValue("4L")]
    GeneticCounselingScreeningServices,

    [EDIFieldValue("4M")]
    AdultDayCareProgramFacility,

    [EDIFieldValue("4N")]
    AlzheimersDiagnosticAssessmentServices,

    [EDIFieldValue("4O")]
    ComprehensiveGeriatricAssessmentFacility,

    [EDIFieldValue("4P")]
    EmergencyResponse_Geriatric_Unit,

    [EDIFieldValue("4Q")]
    GeriatricAcuteCareUnit,

    [EDIFieldValue("4R")]
    GeriatricClinics,

    [EDIFieldValue("4S")]
    RespiteCareFacility,

    [EDIFieldValue("4T")]
    SeniorMembershipProgram,

    [EDIFieldValue("4U")]
    PatientEducationUnit,

    [EDIFieldValue("4V")]
    CommunityHealthPromotionFacility,

    [EDIFieldValue("4W")]
    WorksiteHealthPromotionFacility,

    [EDIFieldValue("4X")]
    HemodialysisFacility,

    [EDIFieldValue("4Y")]
    HomeHealthServices,

    [EDIFieldValue("4Z")]
    Hospice,

    [EDIFieldValue("50")]
    ManufacturersRepresentative,

    [EDIFieldValue("51")]
    PartsDistributor,

    [EDIFieldValue("52")]
    PartRemanufacturer,

    [EDIFieldValue("53")]
    RegisteredOwner,

    [EDIFieldValue("54")]
    OrderWriter,

    [EDIFieldValue("55")]
    ServiceManager,

    [EDIFieldValue("56")]
    ServicingDealer,

    [EDIFieldValue("57")]
    ServicingOrganization,

    [EDIFieldValue("58")]
    StoreManager,

    [EDIFieldValue("59")]
    PartyToApproveSpecification,

    [EDIFieldValue("5A")]
    MedicalSurgicalOrOtherIntensiveCareUnit,

    [EDIFieldValue("5B")]
    HisopathologyLaboratory,

    [EDIFieldValue("5C")]
    BloodBank,

    [EDIFieldValue("5D")]
    NeonatalIntensiveCareUnit,

    [EDIFieldValue("5E")]
    ObstetricsUnit,

    [EDIFieldValue("5F")]
    OccupationalHealthServices,

    [EDIFieldValue("5G")]
    OrganizedOutpatientServices,

    [EDIFieldValue("5H")]
    PediatricAcuteInpatientUnit,

    [EDIFieldValue("5I")]
    PsychiatricChildAdolescentServices,

    [EDIFieldValue("5J")]
    PsychiatricConsultation_LiaisonServices,

    [EDIFieldValue("5K")]
    PsychiatricEducationServices,

    [EDIFieldValue("5L")]
    PsychiatricEmergencyServices,

    [EDIFieldValue("5M")]
    PsychiatricGeriatricServices,

    [EDIFieldValue("5N")]
    PsychiatricInpatientUnit,

    [EDIFieldValue("5O")]
    PsychiatricOutpatientServices,

    [EDIFieldValue("5P")]
    PsychiatricPartialHospitalizationProgram,

    [EDIFieldValue("5Q")]
    MegavoltageRadiationTherapyUnit,

    [EDIFieldValue("5R")]
    RadioactiveImplantsUnit,

    [EDIFieldValue("5S")]
    TherapeuticRadioisotopeFacility,

    [EDIFieldValue("5T")]
    X_RayRadiationTherapyUnit,

    [EDIFieldValue("5U")]
    CTScannerUnit,

    [EDIFieldValue("5V")]
    DiagnosticRadioisotopeFacility,

    [EDIFieldValue("5W")]
    MagneticResonanceImaging_MRI_Facility,

    [EDIFieldValue("5X")]
    UltrasoundUnit,

    [EDIFieldValue("5Y")]
    RehabilitationInpatientUnit,

    [EDIFieldValue("5Z")]
    RehabilitationOutpatientServices,

    [EDIFieldValue("60")]
    Salesperson,

    [EDIFieldValue("61")]
    PerformedAt,

    [EDIFieldValue("62")]
    ApplicantsEmployer,

    [EDIFieldValue("63")]
    ReferencesEmployer,

    [EDIFieldValue("64")]
    CosignersEmployer,

    [EDIFieldValue("65")]
    ApplicantsReference,

    [EDIFieldValue("66")]
    ApplicantsCosigner,

    [EDIFieldValue("67")]
    ApplicantsComaker,

    [EDIFieldValue("68")]
    OwnersRepresentative,

    [EDIFieldValue("69")]
    RepairingOutlet,

    [EDIFieldValue("6A")]
    ReproductiveHealthServices,

    [EDIFieldValue("6B")]
    SkilledNursingOrOtherLong_TermCareUnit,

    [EDIFieldValue("6C")]
    SinglePhotonEmissionComputerizedTomography_SPECT_Unit,

    [EDIFieldValue("6D")]
    OrganizedSocialWorkServiceFacility,

    [EDIFieldValue("6E")]
    OutpatientSocialWorkServices,

    [EDIFieldValue("6F")]
    EmergencyDepartmentSocialWorkServices,

    [EDIFieldValue("6G")]
    SportsMedicineClinicServices,

    [EDIFieldValue("6H")]
    HospitalAuxiliaryUnit,

    [EDIFieldValue("6I")]
    PatientRepresentativeServices,

    [EDIFieldValue("6J")]
    VolunteerServicesDepartment,

    [EDIFieldValue("6K")]
    OutpatientSurgeryServices,

    [EDIFieldValue("6L")]
    OrganTissueTransplantUnit,

    [EDIFieldValue("6M")]
    OrthopedicSurgeryFacility,

    [EDIFieldValue("6N")]
    OccupationalTherapyServices,

    [EDIFieldValue("6O")]
    PhysicalTherapyServices,

    [EDIFieldValue("6P")]
    RecreationalTherapyServices,

    [EDIFieldValue("6Q")]
    RespiratoryTherapyServices,

    [EDIFieldValue("6R")]
    SpeechTherapyServices,

    [EDIFieldValue("6S")]
    WomensHealthCenterServices,

    [EDIFieldValue("6T")]
    HealthSciencesLibrary,

    [EDIFieldValue("6U")]
    CardiacRehabilitationProgramFacility,

    [EDIFieldValue("6V")]
    Non_InvasiveCardiacAssessmentServices,

    [EDIFieldValue("6W")]
    EmergencyMedicalTechnician,

    [EDIFieldValue("6X")]
    DisciplinaryContact,

    [EDIFieldValue("6Y")]
    CaseManager,

    [EDIFieldValue("6Z")]
    Advisor,

    [EDIFieldValue("70")]
    PriorIncorrectInsured,

    [EDIFieldValue("71")]
    AttendingPhysician,

    [EDIFieldValue("72")]
    OperatingPhysician,

    [EDIFieldValue("73")]
    OtherPhysician,

    [EDIFieldValue("74")]
    CorrectedInsured,

    [EDIFieldValue("75")]
    Participant,

    [EDIFieldValue("76")]
    SecondaryWarranter,

    [EDIFieldValue("77")]
    ServiceLocation,

    [EDIFieldValue("78")]
    ServiceRequester,

    [EDIFieldValue("79")]
    Warranter,

    [EDIFieldValue("7A")]
    Premises,

    [EDIFieldValue("7B")]
    Bottler,

    [EDIFieldValue("7C")]
    PlaceOfOccurrence,

    [EDIFieldValue("7D")]
    ContractingOfficerRepresentative,

    [EDIFieldValue("7E")]
    PartyAuthorizedToDefinitizeContractAction,

    [EDIFieldValue("7F")]
    FilingAddress,

    [EDIFieldValue("7G")]
    HazardousMaterialOffice,

    [EDIFieldValue("7H")]
    GovernmentFurnishedPropertyFOBPoint,

    [EDIFieldValue("7I")]
    ProjectName,

    [EDIFieldValue("7J")]
    Codefendant,

    [EDIFieldValue("7K")]
    Co_occupant,

    [EDIFieldValue("7L")]
    PreliminaryInspectionLocation,

    [EDIFieldValue("7M")]
    InspectionAndAcceptanceLocation,

    [EDIFieldValue("7N")]
    PartyToReceiveProposal,

    [EDIFieldValue("7O")]
    FederallyCharteredFacility,

    [EDIFieldValue("7P")]
    TransportationOffice,

    [EDIFieldValue("7Q")]
    PartyToWhomProtestSubmitted,

    [EDIFieldValue("7R")]
    Birthplace,

    [EDIFieldValue("7S")]
    PipelineSegment,

    [EDIFieldValue("7T")]
    HomeStateName,

    [EDIFieldValue("7U")]
    Liquidator,

    [EDIFieldValue("7V")]
    PetitioningCreditorsAttorney,

    [EDIFieldValue("7W")]
    MergedName,

    [EDIFieldValue("7X")]
    PartyRepresented,

    [EDIFieldValue("7Y")]
    ProfessionalOrganization,

    [EDIFieldValue("7Z")]
    Referee,

    [EDIFieldValue("80")]
    Hospital,

    [EDIFieldValue("81")]
    PartSource,

    [EDIFieldValue("82")]
    RenderingProvider,

    [EDIFieldValue("83")]
    SubscribersSchool,

    [EDIFieldValue("84")]
    SubscribersEmployer,

    [EDIFieldValue("85")]
    BillingProvider,

    [EDIFieldValue("86")]
    Conductor,

    [EDIFieldValue("87")]
    Pay_toProvider,

    [EDIFieldValue("88")]
    Approver,

    [EDIFieldValue("89")]
    Investor,

    [EDIFieldValue("8A")]
    VacationHome,

    [EDIFieldValue("8B")]
    PrimaryResidence,

    [EDIFieldValue("8C")]
    SecondHome,

    [EDIFieldValue("8D")]
    PermitHolder,

    [EDIFieldValue("8E")]
    MinorityInstitution,

    [EDIFieldValue("8F")]
    BailmentWarehouse,

    [EDIFieldValue("8G")]
    FirstAppraiser,

    [EDIFieldValue("8H")]
    TaxExemptOrganization,

    [EDIFieldValue("8I")]
    ServiceOrganization,

    [EDIFieldValue("8J")]
    EmergingSmallBusiness,

    [EDIFieldValue("8K")]
    SurplusDealer,

    [EDIFieldValue("8L")]
    PollingSite,

    [EDIFieldValue("8M")]
    SociallyDisadvantagedIndividual,

    [EDIFieldValue("8N")]
    EconomicallyDisadvantagedIndividual,

    [EDIFieldValue("8O")]
    DisabledIndividual,

    [EDIFieldValue("8P")]
    Producer,

    [EDIFieldValue("8Q")]
    PublicOrPrivateOrganizationfortheDisabled,

    [EDIFieldValue("8R")]
    ConsumerServiceProvider_CSP_Customer,

    [EDIFieldValue("8S")]
    ConsumerServiceProvider_CSP,

    [EDIFieldValue("8T")]
    Voter,

    [EDIFieldValue("8U")]
    NativeHawaiianOrganization,

    [EDIFieldValue("8V")]
    PrimaryIntra_LATA_LocalAccessTransportArea_Carrier,

    [EDIFieldValue("8W")]
    PaymentAddress,

    [EDIFieldValue("8X")]
    OilAndGasCustodian,

    [EDIFieldValue("8Y")]
    RegisteredOffice,

    [EDIFieldValue("8Z")]
    JointDebtorAttorney_8Z,

    [EDIFieldValue("90")]
    PreviousBusinessPartner,

    [EDIFieldValue("91")]
    ActionParty,

    [EDIFieldValue("92")]
    SupportParty,

    [EDIFieldValue("93")]
    InsuranceInstitute,

    [EDIFieldValue("94")]
    NewSupplySource,

    [EDIFieldValue("95")]
    ResearchInstitute,

    [EDIFieldValue("96")]
    DebtorCompany,

    [EDIFieldValue("97")]
    PartyWaivingRequirements,

    [EDIFieldValue("98")]
    FreightManagementFacilitator,

    [EDIFieldValue("99")]
    OuterContinentalShelf_OCS_AreaLocation,

    [EDIFieldValue("9A")]
    DebtorIndividual,

    [EDIFieldValue("9B")]
    CountryOfExport,

    [EDIFieldValue("9C")]
    CountryOfDestination,

    [EDIFieldValue("9D")]
    NewServiceProvider,

    [EDIFieldValue("9E")]
    Sub_servicer,

    [EDIFieldValue("9F")]
    LossPayee,

    [EDIFieldValue("9G")]
    Nickname,

    [EDIFieldValue("9H")]
    Assignee,

    [EDIFieldValue("9I")]
    RegisteredPrincipal,

    [EDIFieldValue("9J")]
    AdditionalDebtor,

    [EDIFieldValue("9K")]
    KeyPerson,

    [EDIFieldValue("9L")]
    IncorporatedBy,

    [EDIFieldValue("9N")]
    PartyToLease,

    [EDIFieldValue("9O")]
    PartyToContract,

    [EDIFieldValue("9P")]
    Investigator,

    [EDIFieldValue("9Q")]
    LastSupplier,

    [EDIFieldValue("9R")]
    DownstreamFirstSupplier,

    [EDIFieldValue("9S")]
    Co_Investigator,

    [EDIFieldValue("9T")]
    TelephoneAnsweringServiceBureau,

    [EDIFieldValue("9U")]
    Author,

    [EDIFieldValue("9V")]
    FirstSupplier,

    [EDIFieldValue("9W")]
    UltimateParentCompany,

    [EDIFieldValue("9X")]
    ContractualReceiptMeter,

    [EDIFieldValue("9Y")]
    ContractualDeliveryMeter,

    [EDIFieldValue("9Z")]
    Co_debtor,

    [EDIFieldValue("A1")]
    Adjuster,

    [EDIFieldValue("A2")]
    Woman_OwnedBusiness,

    [EDIFieldValue("A3")]
    LaborSurplusAreaFirm,

    [EDIFieldValue("A4")]
    OtherDisadvantagedBusiness,

    [EDIFieldValue("A5")]
    Veteran_OwnedBusiness,

    [EDIFieldValue("A6")]
    Section8a_ProgramParticipantFirm,

    [EDIFieldValue("A7")]
    ShelteredWorkshop,

    [EDIFieldValue("A8")]
    NonprofitInstitution,

    [EDIFieldValue("A9")]
    SalesOffice,

    [EDIFieldValue("AA")]
    AuthorityForShipment,

    [EDIFieldValue("AB")]
    AdditionalPickUpAddress,

    [EDIFieldValue("AC")]
    AirCargoCompany,

    [EDIFieldValue("AD")]
    PartyToBeadvised_Writtenorders,

    [EDIFieldValue("AE")]
    AdditionalDeliveryAddress,

    [EDIFieldValue("AF")]
    AuthorizedAcceptingOfficial,

    [EDIFieldValue("AG")]
    AgentAgency,

    [EDIFieldValue("AH")]
    Advertiser,

    [EDIFieldValue("AI")]
    Airline,

    [EDIFieldValue("AJ")]
    AllegedDebtor,

    [EDIFieldValue("AK")]
    PartyToWhomAcknowledgmentShouldBeSent,

    [EDIFieldValue("AL")]
    AllotmentCustomer,

    [EDIFieldValue("AM")]
    AssistantUSTrustee,

    [EDIFieldValue("AN")]
    AuthorizedFrom,

    [EDIFieldValue("AO")]
    AccountOf,

    [EDIFieldValue("AP")]
    AccountOf_OriginParty,

    [EDIFieldValue("AQ")]
    AccountOf_DestinationParty,

    [EDIFieldValue("AR")]
    ArmedServicesLocationDesignation,

    [EDIFieldValue("AS")]
    PostsecondaryEducationSender,

    [EDIFieldValue("AT")]
    PostsecondaryEducationRecipient,

    [EDIFieldValue("AU")]
    PartyAuthorizingDisposition,

    [EDIFieldValue("AV")]
    AuthorizedTo,

    [EDIFieldValue("AW")]
    Accountant,

    [EDIFieldValue("AX")]
    Plaintiff,

    [EDIFieldValue("AY")]
    Clearinghouse,

    [EDIFieldValue("AZ")]
    PreviousName,

    [EDIFieldValue("B1")]
    ConstructionFirm,

    [EDIFieldValue("B2")]
    OtherUnlistedTypeOfOrganizationalEntity,

    [EDIFieldValue("B3")]
    PreviousNameOfFirm,

    [EDIFieldValue("B4")]
    ParentCompany,

    [EDIFieldValue("B5")]
    AffiliatedCompany,

    [EDIFieldValue("B6")]
    RegisteringParentParty,

    [EDIFieldValue("B7")]
    RegisteringNonparentParty,

    [EDIFieldValue("B8")]
    RegularDealer,

    [EDIFieldValue("B9")]
    LargeBusiness,

    [EDIFieldValue("BA")]
    Battery,

    [EDIFieldValue("BB")]
    BusinessPartner,

    [EDIFieldValue("BC")]
    Broadcaster,

    [EDIFieldValue("BD")]
    Bill_toPartyforDiversionCharges,

    [EDIFieldValue("BE")]
    Beneficiary,

    [EDIFieldValue("BF")]
    BilledFrom,

    [EDIFieldValue("BG")]
    BuyingGroup,

    [EDIFieldValue("BH")]
    InterimTrustee,

    [EDIFieldValue("BI")]
    TrusteesAttorney,

    [EDIFieldValue("BJ")]
    CoCounsel,

    [EDIFieldValue("BK")]
    Bank,

    [EDIFieldValue("BL")]
    PartyToReceiveBillOfLading,

    [EDIFieldValue("BM")]
    Brakeman,

    [EDIFieldValue("BN")]
    BeneficialOwner,

    [EDIFieldValue("BO")]
    BrokerOrSalesOffice,

    [EDIFieldValue("BP")]
    SpecialCounsel,

    [EDIFieldValue("BQ")]
    AttorneyforDefendantPrivate,

    [EDIFieldValue("BR")]
    Broker,

    [EDIFieldValue("BS")]
    BillAndShipTo,

    [EDIFieldValue("BT")]
    BillToParty,

    [EDIFieldValue("BU")]
    PlaceOfBusiness,

    [EDIFieldValue("BV")]
    BillingService,

    [EDIFieldValue("BW")]
    Borrower,

    [EDIFieldValue("BX")]
    AttorneyforPlaintiff,

    [EDIFieldValue("BY")]
    BuyingParty_Purchaser,

    [EDIFieldValue("BZ")]
    BusinessAssociate,

    [EDIFieldValue("C1")]
    InCareOfPartyno1,

    [EDIFieldValue("C2")]
    InCareOfPartyno2,

    [EDIFieldValue("C3")]
    CircuitLocationIdentifier,

    [EDIFieldValue("C4")]
    ContractAdministrationOffice,

    [EDIFieldValue("C5")]
    PartySubmittingQuote,

    [EDIFieldValue("C6")]
    Municipality,

    [EDIFieldValue("C7")]
    County,

    [EDIFieldValue("C8")]
    City,

    [EDIFieldValue("C9")]
    ContractHolder,

    [EDIFieldValue("CA")]
    Carrier,

    [EDIFieldValue("CB")]
    CustomsBroker,

    [EDIFieldValue("CC")]
    Claimant,

    [EDIFieldValue("CD")]
    Consignee_ToReceiveMailAndSmallParcels,

    [EDIFieldValue("CE")]
    Consignee_ToreceivelargeparcelsAndfreight,

    [EDIFieldValue("CF")]
    SubsidiaryDivision,

    [EDIFieldValue("CG")]
    CarnetIssuer,

    [EDIFieldValue("CH")]
    ChassisProvider,

    [EDIFieldValue("CI")]
    Consignor,

    [EDIFieldValue("CJ")]
    AutomatedDataProcessing_ADP_Point,

    [EDIFieldValue("CK")]
    Pharmacist,

    [EDIFieldValue("CL")]
    ContainerLocation,

    [EDIFieldValue("CM")]
    Customs,

    [EDIFieldValue("CN")]
    Consignee,

    [EDIFieldValue("CO")]
    OceanTariffConference,

    [EDIFieldValue("CP")]
    PartyToReceiveCertOfCompliance,

    [EDIFieldValue("CQ")]
    CorporateOffice,

    [EDIFieldValue("CR")]
    ContainerReturnCompany,

    [EDIFieldValue("CS")]
    Consolidator,

    [EDIFieldValue("CT")]
    CountryOfOrigin,

    [EDIFieldValue("CU")]
    CoatingOrPaintSupplier,

    [EDIFieldValue("CV")]
    Converter,

    [EDIFieldValue("CW")]
    AccountingStation,

    [EDIFieldValue("CX")]
    ClaimAdministrator,

    [EDIFieldValue("CY")]
    Country,

    [EDIFieldValue("CZ")]
    AdmittingSurgeon,

    [EDIFieldValue("D1")]
    Driver,

    [EDIFieldValue("D2")]
    CommercialInsurer,

    [EDIFieldValue("D3")]
    Defendant,

    [EDIFieldValue("D4")]
    Debtor,

    [EDIFieldValue("D5")]
    DebtorInPossession,

    [EDIFieldValue("D6")]
    ConsolidatedDebtor,

    [EDIFieldValue("D7")]
    PetitioningCreditor,

    [EDIFieldValue("D8")]
    Dispatcher,

    [EDIFieldValue("D9")]
    CreditorsAttorney,

    [EDIFieldValue("DA")]
    DeliveryAddress,

    [EDIFieldValue("DB")]
    DistributorBranch,

    [EDIFieldValue("DC")]
    DestinationCarrier,

    [EDIFieldValue("DD")]
    AssistantSurgeon,

    [EDIFieldValue("DE")]
    Depositor,

    [EDIFieldValue("DF")]
    MaterialDispositionAuthorizationLocation,

    [EDIFieldValue("DG")]
    DesignEngineering,

    [EDIFieldValue("DH")]
    DoingBusinessAs,

    [EDIFieldValue("DI")]
    DifferentPremiseAddress_DPA,

    [EDIFieldValue("DJ")]
    ConsultingPhysician,

    [EDIFieldValue("DK")]
    OrderingPhysician,

    [EDIFieldValue("DL")]
    Dealer,

    [EDIFieldValue("DM")]
    DestinationMailFacility,

    [EDIFieldValue("DN")]
    ReferringProvider,

    [EDIFieldValue("DO")]
    DependentName,

    [EDIFieldValue("DP")]
    PartyToProvideDiscount,

    [EDIFieldValue("DQ")]
    SupervisingPhysician,

    [EDIFieldValue("DR")]
    DestinationDrayman,

    [EDIFieldValue("DS")]
    Distributor,

    [EDIFieldValue("DT")]
    DestinationTerminal,

    [EDIFieldValue("DU")]
    ResaleDealer,

    [EDIFieldValue("DV")]
    Division,

    [EDIFieldValue("DW")]
    DownstreamParty,

    [EDIFieldValue("DX")]
    Distiller,

    [EDIFieldValue("DY")]
    DefaultForeclosureSpecialist,

    [EDIFieldValue("DZ")]
    DeliveryZone,

    [EDIFieldValue("E1")]
    PersonOrOtherEntityLegallyResponsibleforaChild,

    [EDIFieldValue("E2")]
    PersonOrOtherEntityWithWhomaChildResides,

    [EDIFieldValue("E3")]
    PersonOrOtherEntityLegallyResponsibleforAndWithWhomaChildResides,

    [EDIFieldValue("E4")]
    OtherPersonOrEntityAssociatedwithStudent,

    [EDIFieldValue("E5")]
    Examiner,

    [EDIFieldValue("E6")]
    Engineering,

    [EDIFieldValue("E7")]
    PreviousEmployer,

    [EDIFieldValue("E8")]
    InquiringParty,

    [EDIFieldValue("E9")]
    ParticipatingLaboratory,

    [EDIFieldValue("EA")]
    StudySubmitter,

    [EDIFieldValue("EB")]
    EligiblePartyToTheContract,

    [EDIFieldValue("EC")]
    Exchanger,

    [EDIFieldValue("ED")]
    ExcludedParty,

    [EDIFieldValue("EE")]
    LocationOfGoodsforCustomsExaminationBeforeClearance,

    [EDIFieldValue("EF")]
    ElectronicFiler,

    [EDIFieldValue("EG")]
    Engineer,

    [EDIFieldValue("EH")]
    Exhibitor,

    [EDIFieldValue("EI")]
    ExecutorOfEstate,

    [EDIFieldValue("EJ")]
    PrincipalPerson,

    [EDIFieldValue("EK")]
    AnimalSource,

    [EDIFieldValue("EL")]
    EstablishedLocation,

    [EDIFieldValue("EM")]
    PartyToReceiveElectronicMemoOfInvoice,

    [EDIFieldValue("EN")]
    EndUser,

    [EDIFieldValue("EO")]
    LimitedLiabilityPartnership,

    [EDIFieldValue("EP")]
    EligiblePartyTotheRate,

    [EDIFieldValue("EQ")]
    OldDebtor,

    [EDIFieldValue("ER")]
    NewDebtor,

    [EDIFieldValue("ES")]
    EmployerName,

    [EDIFieldValue("ET")]
    PlanAdministrator,

    [EDIFieldValue("EU")]
    OldSecuredParty,

    [EDIFieldValue("EV")]
    SellingAgent,

    [EDIFieldValue("EW")]
    ServicingBroker,

    [EDIFieldValue("EX")]
    Exporter,

    [EDIFieldValue("EY")]
    EmployeeName,

    [EDIFieldValue("EZ")]
    NewSecuredParty,

    [EDIFieldValue("F1")]
    Company_OwnedOilField,

    [EDIFieldValue("F2")]
    EnergyInformationAdministration_DepartmentOfEnergy__OwnedOilField,

    [EDIFieldValue("F3")]
    SpecializedMobileRadioService_SMRS_Licensee,

    [EDIFieldValue("F4")]
    FormerResidence,

    [EDIFieldValue("F5")]
    RadioControlStationLocation,

    [EDIFieldValue("F6")]
    SmallControlStationLocation,

    [EDIFieldValue("F7")]
    SmallBaseStationLocation,

    [EDIFieldValue("F8")]
    AntennaSite,

    [EDIFieldValue("F9")]
    AreaOfOperation,

    [EDIFieldValue("FA")]
    Facility,

    [EDIFieldValue("FB")]
    FirstBreakTerminal,

    [EDIFieldValue("FC")]
    CustomerIdentificationFile_CIF_CustomerIdentifier,

    [EDIFieldValue("FD")]
    PhysicalAddress,

    [EDIFieldValue("FE")]
    MailAddress,

    [EDIFieldValue("FF")]
    ForeignLanguageSynonym,

    [EDIFieldValue("FG")]
    TradeNameSynonym,

    [EDIFieldValue("FH")]
    PartyToReceiveLimitationsOfHeavyElementsReport,

    [EDIFieldValue("FI")]
    NameVariationSynonym,

    [EDIFieldValue("FJ")]
    FirstContact,

    [EDIFieldValue("FL")]
    PrimaryControlPointLocation,

    [EDIFieldValue("FM")]
    Fireman,

    [EDIFieldValue("FN")]
    FilerName,

    [EDIFieldValue("FO")]
    FieldOrBranchOffice,

    [EDIFieldValue("FP")]
    NameonCreditCard,

    [EDIFieldValue("FQ")]
    PierName,

    [EDIFieldValue("FR")]
    MessageFrom,

    [EDIFieldValue("FS")]
    FinalScheduledDestination,

    [EDIFieldValue("FT")]
    NewAssignee,

    [EDIFieldValue("FU")]
    OldAssignee,

    [EDIFieldValue("FV")]
    VesselName,

    [EDIFieldValue("FW")]
    Forwarder,

    [EDIFieldValue("FX")]
    ClosedDoorPharmacy,

    [EDIFieldValue("FY")]
    VeterinaryHospital,

    [EDIFieldValue("FZ")]
    ChildrensDayCareCenter,

    [EDIFieldValue("G0")]
    DependentInsured,

    [EDIFieldValue("G1")]
    BankruptcyTrustee,

    [EDIFieldValue("G2")]
    Annuitant,

    [EDIFieldValue("G3")]
    Clinic,

    [EDIFieldValue("G5")]
    ContingentBeneficiary,

    [EDIFieldValue("G6")]
    EntityHoldingtheInformation,

    [EDIFieldValue("G7")]
    EntityProvidingtheService,

    [EDIFieldValue("G8")]
    EntityResponsibleforFollow_up,

    [EDIFieldValue("G9")]
    FamilyMember,

    [EDIFieldValue("GA")]
    GasPlant,

    [EDIFieldValue("GB")]
    OtherInsured,

    [EDIFieldValue("GC")]
    PreviousCreditGrantor,

    [EDIFieldValue("GD")]
    Guardian,

    [EDIFieldValue("GE")]
    GeneralAgency,

    [EDIFieldValue("GF")]
    InspectionCompany,

    [EDIFieldValue("GG")]
    Intermediary,

    [EDIFieldValue("GH")]
    MotorVehicleReportProviderCompany,

    [EDIFieldValue("GI")]
    Paramedic,

    [EDIFieldValue("GJ")]
    ParamedicalCompany,

    [EDIFieldValue("GK")]
    PreviousInsured,

    [EDIFieldValue("GL")]
    PreviousResidence,

    [EDIFieldValue("GM")]
    SpouseInsured,

    [EDIFieldValue("GN")]
    Garnishee,

    [EDIFieldValue("GO")]
    PrimaryBeneficiary,

    [EDIFieldValue("GP")]
    GatewayProvider,

    [EDIFieldValue("GQ")]
    ProposedInsured,

    [EDIFieldValue("GR")]
    Reinsurer,

    [EDIFieldValue("GS")]
    GaragedLocation,

    [EDIFieldValue("GT")]
    CreditGrantor,

    [EDIFieldValue("GU")]
    GuaranteeAgency,

    [EDIFieldValue("GV")]
    GasTransactionEndingPoint,

    [EDIFieldValue("GW")]
    Group,

    [EDIFieldValue("GX")]
    Retrocessionaire,

    [EDIFieldValue("GY")]
    TreatmentFacility,

    [EDIFieldValue("GZ")]
    Grandparent,

    [EDIFieldValue("H1")]
    Representative,

    [EDIFieldValue("H2")]
    Sub_Office,

    [EDIFieldValue("H3")]
    District,

    [EDIFieldValue("H5")]
    PayingAgent,

    [EDIFieldValue("H6")]
    SchoolDistrict,

    [EDIFieldValue("H7")]
    GroupAffiliate,

    [EDIFieldValue("H8")]
    ServicingAgent_H8,

    [EDIFieldValue("H9")]
    Designer,

    [EDIFieldValue("HA")]
    Owner_HA,

    [EDIFieldValue("HB")]
    HistoricallyBlackCollegeOrUniversity,

    [EDIFieldValue("HC")]
    JointAnnuitant,

    [EDIFieldValue("HD")]
    ContingentAnnuitant,

    [EDIFieldValue("HE")]
    ContingentOwner,

    [EDIFieldValue("HF")]
    HealthcareProfessionalShortageArea_HPSA_Facility,

    [EDIFieldValue("HG")]
    BrokerOpinionOrAnalysisRequester,

    [EDIFieldValue("HH")]
    HomeHealthAgency,

    [EDIFieldValue("HI")]
    ListingCompany,

    [EDIFieldValue("HJ")]
    AutomatedUnderwritingSystem,

    [EDIFieldValue("HK")]
    Subscriber,

    [EDIFieldValue("HL")]
    DocumentCustodian,

    [EDIFieldValue("HM")]
    CompetitivePropertyListing,

    [EDIFieldValue("HN")]
    CompetingProperty,

    [EDIFieldValue("HO")]
    ComparablePropertyListing,

    [EDIFieldValue("HP")]
    ClosedSale,

    [EDIFieldValue("HQ")]
    SourcePartyOfInformation,

    [EDIFieldValue("HR")]
    SubjectOfInquiry,

    [EDIFieldValue("HS")]
    HighSchool,

    [EDIFieldValue("HT")]
    StateCharteredFacility,

    [EDIFieldValue("HU")]
    Subsidiary,

    [EDIFieldValue("HV")]
    TaxAddress,

    [EDIFieldValue("HW")]
    DesignatedHazardousWasteFacility,

    [EDIFieldValue("HX")]
    TransporterOfHazardousWaste,

    [EDIFieldValue("HY")]
    Charity,

    [EDIFieldValue("HZ")]
    HazardousWasteGenerator,

    [EDIFieldValue("I1")]
    InterestedParty,

    [EDIFieldValue("I3")]
    IndependentPhysiciansAssociation_IPA,

    [EDIFieldValue("I4")]
    IntellectualPropertyOwner,

    [EDIFieldValue("I9")]
    Interviewer,

    [EDIFieldValue("IA")]
    InstalledAt,

    [EDIFieldValue("IB")]
    IndustryBureau,

    [EDIFieldValue("IC")]
    IntermediateConsignee,

    [EDIFieldValue("ID")]
    IssuerOfDebitOrCreditMemo,

    [EDIFieldValue("IE")]
    OtherIndividualDisabilityCarrier,

    [EDIFieldValue("IF")]
    InternationalFreightForwarder,

    [EDIFieldValue("II")]
    IssuerOfInvoice,

    [EDIFieldValue("IJ")]
    InjectionPoint,

    [EDIFieldValue("IK")]
    IntermediateCarrier,

    [EDIFieldValue("IL")]
    InsuredOrSubscriber,

    [EDIFieldValue("IM")]
    Importer,

    [EDIFieldValue("IN")]
    Insurer,

    [EDIFieldValue("IO")]
    Inspector,

    [EDIFieldValue("IP")]
    IndependentAdjuster,

    [EDIFieldValue("IQ")]
    In_patientPharmacy,

    [EDIFieldValue("IR")]
    SelfInsured,

    [EDIFieldValue("IS")]
    PartyToReceiveCertifiedInspectionReport,

    [EDIFieldValue("IT")]
    InstallationonSite,

    [EDIFieldValue("IU")]
    Issuer,

    [EDIFieldValue("IV")]
    Renter,

    [EDIFieldValue("J1")]
    AssociateGeneralAgent,

    [EDIFieldValue("J2")]
    AuthorizedEntity,

    [EDIFieldValue("J3")]
    BrokersAssistant,

    [EDIFieldValue("J4")]
    Custodian,

    [EDIFieldValue("J5")]
    IrrevocableBeneficiary,

    [EDIFieldValue("J6")]
    PowerOfAttorney,

    [EDIFieldValue("J7")]
    TrustOfficer,

    [EDIFieldValue("J8")]
    BrokerDealer,

    [EDIFieldValue("J9")]
    CommunityAgent,

    [EDIFieldValue("JA")]
    DairyDepartment,

    [EDIFieldValue("JB")]
    DelicatessenDepartment,

    [EDIFieldValue("JC")]
    DryGroceryDepartment,

    [EDIFieldValue("JD")]
    Judge,

    [EDIFieldValue("JE")]
    FrozenDepartment,

    [EDIFieldValue("JF")]
    GeneralMerchandiseDepartment,

    [EDIFieldValue("JG")]
    HealthAndBeautyDepartment,

    [EDIFieldValue("JH")]
    AlcoholBeverageDepartment,

    [EDIFieldValue("JI")]
    MeatDepartment,

    [EDIFieldValue("JJ")]
    ProduceDepartment,

    [EDIFieldValue("JK")]
    BakeryDepartment,

    [EDIFieldValue("JL")]
    VideoDepartment,

    [EDIFieldValue("JM")]
    CandyAndConfectionsDepartment,

    [EDIFieldValue("JN")]
    CigarettesAndTobaccoDepartment,

    [EDIFieldValue("JO")]
    In_StoreBakeryDepartment,

    [EDIFieldValue("JP")]
    FloralDepartment,

    [EDIFieldValue("JQ")]
    PharmacyDepartment,

    [EDIFieldValue("JR")]
    Bidder,

    [EDIFieldValue("JS")]
    JointDebtorAttorney_JS,

    [EDIFieldValue("JT")]
    JointDebtor,

    [EDIFieldValue("JU")]
    Jurisdiction,

    [EDIFieldValue("JV")]
    JointOwner,

    [EDIFieldValue("JW")]
    JointVenture,

    [EDIFieldValue("JX")]
    ClosingAgent,

    [EDIFieldValue("JY")]
    FinancialPlanner,

    [EDIFieldValue("JZ")]
    ManagingGeneralAgent,

    [EDIFieldValue("K1")]
    ContractorCognizantSecurityOffice,

    [EDIFieldValue("K2")]
    SubcontractorCognizantSecurityOffice,

    [EDIFieldValue("K3")]
    PlaceOfPerformanceCognizantSecurityOffice,

    [EDIFieldValue("K4")]
    PartyAuthorizingReleaseOfSecurityInformation,

    [EDIFieldValue("K5")]
    PartyToReceiveContractSecurityClassificationSpecification,

    [EDIFieldValue("K6")]
    PolicyWritingAgent,

    [EDIFieldValue("K7")]
    RadioStation,

    [EDIFieldValue("K8")]
    FilingLocation,

    [EDIFieldValue("K9")]
    PreviousDistributor,

    [EDIFieldValue("KA")]
    ItemManager,

    [EDIFieldValue("KB")]
    CustomerforWhomSameOrSimilarWorkWasPerformed,

    [EDIFieldValue("KC")]
    PartyThatReceivedDisclosureStatement,

    [EDIFieldValue("KD")]
    Proposer,

    [EDIFieldValue("KE")]
    ContactOffice,

    [EDIFieldValue("KF")]
    AuditOffice,

    [EDIFieldValue("KG")]
    ProjectManager,

    [EDIFieldValue("KH")]
    OrganizationHavingSourceControl,

    [EDIFieldValue("KI")]
    UnitedStatesOverseasSecurityAdministrationOffice,

    [EDIFieldValue("KJ")]
    QualifyingOfficer,

    [EDIFieldValue("KK")]
    RegisteringParty,

    [EDIFieldValue("KL")]
    ClerkOfCourt,

    [EDIFieldValue("KM")]
    Coordinator,

    [EDIFieldValue("KN")]
    FormerAddress,

    [EDIFieldValue("KO")]
    PlantClearanceOfficer,

    [EDIFieldValue("KP")]
    NameUnderWhichFiled,

    [EDIFieldValue("KQ")]
    Licensee,

    [EDIFieldValue("KR")]
    Pre_kindergartenToGrade12Recipient,

    [EDIFieldValue("KS")]
    Pre_kindergartenToGrade12Sender,

    [EDIFieldValue("KT")]
    Court,

    [EDIFieldValue("KU")]
    ReceiverSite,

    [EDIFieldValue("KV")]
    DisbursingOfficer,

    [EDIFieldValue("KW")]
    BidOpeningLocation,

    [EDIFieldValue("KX")]
    FreeonBoardPoint,

    [EDIFieldValue("KY")]
    TechnicalOffice,

    [EDIFieldValue("KZ")]
    AcceptanceLocation,

    [EDIFieldValue("L1")]
    InspectionLocation,

    [EDIFieldValue("L2")]
    LocationOfPrincipalAssets,

    [EDIFieldValue("L3")]
    LoanCorrespondent,

    [EDIFieldValue("L5")]
    Contact,

    [EDIFieldValue("L8")]
    HeadOffice,

    [EDIFieldValue("L9")]
    InformationProvider,

    [EDIFieldValue("LA")]
    Attorney,

    [EDIFieldValue("LB")]
    LastBreakTerminal,

    [EDIFieldValue("LC")]
    LocationOfSpotforStorage,

    [EDIFieldValue("LD")]
    LiabilityHolder,

    [EDIFieldValue("LE")]
    Lessor,

    [EDIFieldValue("LF")]
    LimitedPartner,

    [EDIFieldValue("LG")]
    LocationOfGoods,

    [EDIFieldValue("LH")]
    Pipeline,

    [EDIFieldValue("LI")]
    IndependentLab,

    [EDIFieldValue("LJ")]
    LimitedLiabilityCompany,

    [EDIFieldValue("LK")]
    JuvenileOwner,

    [EDIFieldValue("LL")]
    LocationOfLoadExchange_Export,

    [EDIFieldValue("LM")]
    LendingInstitution,

    [EDIFieldValue("LN")]
    Lender,

    [EDIFieldValue("LO")]
    LoanOriginator,

    [EDIFieldValue("LP")]
    LoadingParty,

    [EDIFieldValue("LQ")]
    LawFirm,

    [EDIFieldValue("LR")]
    LegalRepresentative,

    [EDIFieldValue("LS")]
    Lessee,

    [EDIFieldValue("LT")]
    Long_termDisabilityCarrier,

    [EDIFieldValue("LU")]
    MasterAgent,

    [EDIFieldValue("LV")]
    LoanServicer,

    [EDIFieldValue("LW")]
    Customer,

    [EDIFieldValue("LY")]
    Labeler,

    [EDIFieldValue("LZ")]
    LocalChain,

    [EDIFieldValue("M1")]
    SourceMeterLocation,

    [EDIFieldValue("M2")]
    ReceiptMeterLocation,

    [EDIFieldValue("M3")]
    UpstreamMeterLocation,

    [EDIFieldValue("M4")]
    DownstreamMeterLocation,

    [EDIFieldValue("M5")]
    MigrantHealthClinic,

    [EDIFieldValue("M6")]
    Landlord,

    [EDIFieldValue("M7")]
    ForeclosingLender,

    [EDIFieldValue("M8")]
    EducationalInstitution,

    [EDIFieldValue("M9")]
    Manufacturing,

    [EDIFieldValue("MA")]
    PartyforwhomItemisUltimatelyIntended,

    [EDIFieldValue("MB")]
    CompanyInterviewerWorksFor,

    [EDIFieldValue("MC")]
    MotorCarrier,

    [EDIFieldValue("MD")]
    VeteransAdministrationLoanGuarantyAuthority,

    [EDIFieldValue("ME")]
    VeteransAdministrationLoanAuthorizedSupplier,

    [EDIFieldValue("MF")]
    ManufacturerOfGoods,

    [EDIFieldValue("MG")]
    GovernmentLoanAgencySponsorOrAgent,

    [EDIFieldValue("MH")]
    MortgageInsurer,

    [EDIFieldValue("MI")]
    PlanningScheduleMaterialReleaseIssuer,

    [EDIFieldValue("MJ")]
    FinancialInstitution,

    [EDIFieldValue("MK")]
    LoanHolderforRealEstateAsset,

    [EDIFieldValue("ML")]
    ConsumerCreditAccountCompany,

    [EDIFieldValue("MM")]
    MortgageCompany,

    [EDIFieldValue("MN")]
    AuthorizedMarketer,

    [EDIFieldValue("MO")]
    ReleaseDrayman,

    [EDIFieldValue("MP")]
    ManufacturingPlant,

    [EDIFieldValue("MQ")]
    MeteringLocation,

    [EDIFieldValue("MR")]
    MedicalInsuranceCarrier,

    [EDIFieldValue("MS")]
    BureauOfLandManagement_MineralsManagementService_PropertyUnit,

    [EDIFieldValue("MT")]
    Material,

    [EDIFieldValue("MU")]
    MeetingLocation,

    [EDIFieldValue("MV")]
    Mainline,

    [EDIFieldValue("MW")]
    MarineSurveyor,

    [EDIFieldValue("MX")]
    JuvenileWitness,

    [EDIFieldValue("MY")]
    MasterGeneralAgent,

    [EDIFieldValue("MZ")]
    Minister,

    [EDIFieldValue("N1")]
    NotifyPartyNo1,

    [EDIFieldValue("N2")]
    NotifyPartyNo2,

    [EDIFieldValue("N3")]
    IneligibleParty,

    [EDIFieldValue("N4")]
    PriceAdministration,

    [EDIFieldValue("N5")]
    PartyWhoSignedtheDeliveryReceipt,

    [EDIFieldValue("N6")]
    NonemploymentIncomeSource,

    [EDIFieldValue("N7")]
    PreviousNeighbor,

    [EDIFieldValue("N8")]
    Relative,

    [EDIFieldValue("N9")]
    Neighborhood,

    [EDIFieldValue("NB")]
    Neighbor,

    [EDIFieldValue("NC")]
    Cross_TownSwitch,

    [EDIFieldValue("ND")]
    NextDestination,

    [EDIFieldValue("NE")]
    Newspaper,

    [EDIFieldValue("NF")]
    OwnerAnnuitant,

    [EDIFieldValue("NG")]
    Administrator,

    [EDIFieldValue("NH")]
    Association,

    [EDIFieldValue("NI")]
    Non_insured,

    [EDIFieldValue("NJ")]
    TrustOrEstate,

    [EDIFieldValue("NK")]
    NationalChain,

    [EDIFieldValue("NL")]
    Non_railroadEntity,

    [EDIFieldValue("NM")]
    Physician_Specialists,

    [EDIFieldValue("NN")]
    NetworkName,

    [EDIFieldValue("NP")]
    NotifyPartyforShippersOrder,

    [EDIFieldValue("NQ")]
    PipelineSegmentBoundary,

    [EDIFieldValue("NR")]
    GasTransactionStartingPoint,

    [EDIFieldValue("NS")]
    Non_TemporaryStorageFacility,

    [EDIFieldValue("NT")]
    MagistrateJudge,

    [EDIFieldValue("NU")]
    FormerlyKnownAs,

    [EDIFieldValue("NV")]
    FormerlyDoingBusinessAs,

    [EDIFieldValue("NW")]
    MaidenName,

    [EDIFieldValue("NX")]
    PrimaryOwner,

    [EDIFieldValue("NY")]
    BirthName,

    [EDIFieldValue("NZ")]
    PrimaryPhysician,

    [EDIFieldValue("O1")]
    OriginatingBank,

    [EDIFieldValue("O2")]
    OriginatingCompany,

    [EDIFieldValue("O3")]
    ReceivingCompany,

    [EDIFieldValue("O4")]
    Factor,

    [EDIFieldValue("O5")]
    MerchantBanker,

    [EDIFieldValue("O6")]
    NonRegisteredBusinessName,

    [EDIFieldValue("O7")]
    RegisteredBusinessName,

    [EDIFieldValue("O8")]
    Registrar,

    [EDIFieldValue("OA")]
    ElectronicReturnOriginator,

    [EDIFieldValue("OB")]
    OrderedBy,

    [EDIFieldValue("OC")]
    OriginCarrier,

    [EDIFieldValue("OD")]
    DoctorOfOptometry,

    [EDIFieldValue("OE")]
    BookingOffice,

    [EDIFieldValue("OF")]
    OffsetOperator,

    [EDIFieldValue("OG")]
    CoOwner,

    [EDIFieldValue("OH")]
    OtherDepartments,

    [EDIFieldValue("OI")]
    OutsideInspectionAgency,

    [EDIFieldValue("OK")]
    Owner_OK,

    [EDIFieldValue("OL")]
    Officer,

    [EDIFieldValue("OM")]
    OriginMailFacility,

    [EDIFieldValue("ON")]
    ProductPositionHolder,

    [EDIFieldValue("OO")]
    OrderOf_ShippersOrders_Transportation,

    [EDIFieldValue("OP")]
    OperatorOfpropertyOrunit,

    [EDIFieldValue("OR")]
    OriginDrayman,

    [EDIFieldValue("OS")]
    OverrideInstitution,

    [EDIFieldValue("OT")]
    OriginTerminal,

    [EDIFieldValue("OU")]
    OutsideProcessor,

    [EDIFieldValue("OV")]
    OwnerOfVessel,

    [EDIFieldValue("OW")]
    OwnerOfPropertyOrUnit,

    [EDIFieldValue("OX")]
    OxygenTherapyFacility,

    [EDIFieldValue("OY")]
    OwnerOfVehicle,

    [EDIFieldValue("OZ")]
    OutsideTestingAgency,

    [EDIFieldValue("P0")]
    PatientFacility,

    [EDIFieldValue("P1")]
    Preparer,

    [EDIFieldValue("P2")]
    PrimaryInsuredOrSubscriber,

    [EDIFieldValue("P3")]
    PrimaryCareProvider,

    [EDIFieldValue("P4")]
    PriorInsuranceCarrier,

    [EDIFieldValue("P5")]
    PlanSponsor,

    [EDIFieldValue("P6")]
    ThirdPartyReviewingPreferredProviderOrganization_PPO,

    [EDIFieldValue("P7")]
    ThirdPartyRepricingPreferredProviderOrganization_PPO,

    [EDIFieldValue("P8")]
    PersonnelOffice,

    [EDIFieldValue("P9")]
    PrimaryInterexchangeCarrier_PIC,

    [EDIFieldValue("PA")]
    PartyToReceiveInspectionReport,

    [EDIFieldValue("PB")]
    PayingBank,

    [EDIFieldValue("PC")]
    PartyToReceiveCertOfConformance_CAA,

    [EDIFieldValue("PD")]
    PurchasersDepartmentBuyer,

    [EDIFieldValue("PE")]
    Payee,

    [EDIFieldValue("PF")]
    PartyToReceiveFreightBill,

    [EDIFieldValue("PG")]
    PrimeContractor,

    [EDIFieldValue("PH")]
    Printer,

    [EDIFieldValue("PI")]
    Publisher,

    [EDIFieldValue("PJ")]
    PartyToReceiveCorrespondence,

    [EDIFieldValue("PK")]
    PartyToReceiveCopy,

    [EDIFieldValue("PL")]
    PartyToReceivePurchaseOrder,

    [EDIFieldValue("PM")]
    PartyToreceivepaperMemoOfInvoice,

    [EDIFieldValue("PN")]
    PartyToReceiveShippingNotice,

    [EDIFieldValue("PO")]
    PartyToReceiveInvoiceforGoodsOrServices,

    [EDIFieldValue("PP")]
    Property,

    [EDIFieldValue("PQ")]
    PartyToReceiveInvoiceforLeasePayments,

    [EDIFieldValue("PR")]
    Payer,

    [EDIFieldValue("PS")]
    PreviousStation,

    [EDIFieldValue("PT")]
    PartyToReceiveTestReport,

    [EDIFieldValue("PU")]
    PartyatPick_upLocation,

    [EDIFieldValue("PV")]
    Partyperformingcertification,

    [EDIFieldValue("PW")]
    PickUpAddress,

    [EDIFieldValue("PX")]
    PartyPerformingCount,

    [EDIFieldValue("PY")]
    PartyToFilePersonalPropertyTax,

    [EDIFieldValue("PZ")]
    PartyToReceiveEquipment,

    [EDIFieldValue("Q1")]
    ConductorPilot,

    [EDIFieldValue("Q2")]
    EngineerPilot,

    [EDIFieldValue("Q3")]
    RetailAccount,

    [EDIFieldValue("Q4")]
    CooperativeBuyingGroup,

    [EDIFieldValue("Q5")]
    AdvertisingGroup,

    [EDIFieldValue("Q6")]
    Interpreter,

    [EDIFieldValue("Q7")]
    Partner,

    [EDIFieldValue("Q8")]
    BasePeriodEmployer,

    [EDIFieldValue("Q9")]
    LastEmployer,

    [EDIFieldValue("QA")]
    Pharmacy,

    [EDIFieldValue("QB")]
    PurchaseServiceProvider,

    [EDIFieldValue("QC")]
    Patient,

    [EDIFieldValue("QD")]
    ResponsibleParty,

    [EDIFieldValue("QE")]
    Policyholder,

    [EDIFieldValue("QF")]
    Passenger,

    [EDIFieldValue("QG")]
    Pedestrian,

    [EDIFieldValue("QH")]
    Physician,

    [EDIFieldValue("QI")]
    PartyinPossession,

    [EDIFieldValue("QJ")]
    MostRecentEmployer_Chargeable,

    [EDIFieldValue("QK")]
    ManagedCare,

    [EDIFieldValue("QL")]
    Chiropractor,

    [EDIFieldValue("QM")]
    DialysisCenters,

    [EDIFieldValue("QN")]
    Dentist,

    [EDIFieldValue("QO")]
    DoctorOfOsteopathy,

    [EDIFieldValue("QP")]
    PrincipalBorrower,

    [EDIFieldValue("QQ")]
    QualityControl,

    [EDIFieldValue("QR")]
    BuyersQualityReviewBoard,

    [EDIFieldValue("QS")]
    Podiatrist,

    [EDIFieldValue("QT")]
    Psychiatrist,

    [EDIFieldValue("QU")]
    Veterinarian,

    [EDIFieldValue("QV")]
    GroupPractice,

    [EDIFieldValue("QW")]
    Government,

    [EDIFieldValue("QX")]
    HomeHealthCorporation,

    [EDIFieldValue("QY")]
    MedicalDoctor,

    [EDIFieldValue("QZ")]
    Co_borrower,

    [EDIFieldValue("R0")]
    RoyaltyOwner,

    [EDIFieldValue("R1")]
    PartyToReceiveScaleTicket,

    [EDIFieldValue("R2")]
    ReportingOfficer,

    [EDIFieldValue("R3")]
    NextScheduledDestination,

    [EDIFieldValue("R4")]
    Regulatory_State_District,

    [EDIFieldValue("R5")]
    Regulatory_State_Entity,

    [EDIFieldValue("R6")]
    Requester,

    [EDIFieldValue("R7")]
    ConsumerReferralContact,

    [EDIFieldValue("R8")]
    CreditReportingAgency,

    [EDIFieldValue("R9")]
    RequestedLender,

    [EDIFieldValue("RA")]
    AlternateReturnAddress,

    [EDIFieldValue("RB")]
    ReceivingBank,

    [EDIFieldValue("RC")]
    ReceivingLocation,

    [EDIFieldValue("RD")]
    DestinationIntermodalRamp,

    [EDIFieldValue("RE")]
    PartyToReceiveCommercialInvoiceRemittance,

    [EDIFieldValue("RF")]
    Refinery,

    [EDIFieldValue("RG")]
    ResponsibleInstallation_Origin,

    [EDIFieldValue("RH")]
    ResponsibleInstallation_Destination,

    [EDIFieldValue("RI")]
    RemitTo,

    [EDIFieldValue("RJ")]
    ResidenceOrDomicile,

    [EDIFieldValue("RK")]
    RefineryOperator,

    [EDIFieldValue("RL")]
    ReportingLocation,

    [EDIFieldValue("RM")]
    Partythatremitspayment,

    [EDIFieldValue("RN")]
    RepairOrRefurbishLocation,

    [EDIFieldValue("RO")]
    OriginalIntermodalRamp,

    [EDIFieldValue("RP")]
    ReceivingPointforCustomerSamples,

    [EDIFieldValue("RQ")]
    ResaleCustomer,

    [EDIFieldValue("RR")]
    Railroad,

    [EDIFieldValue("RS")]
    ReceivingFacilityScheduler,

    [EDIFieldValue("RT")]
    Returnedto,

    [EDIFieldValue("RU")]
    ReceivingSub_Location,

    [EDIFieldValue("RV")]
    Reservoir,

    [EDIFieldValue("RW")]
    RuralHealthClinic,

    [EDIFieldValue("RX")]
    ResponsibleExhibitor,

    [EDIFieldValue("RY")]
    SpecifiedRepository,

    [EDIFieldValue("RZ")]
    ReceiptZone,

    [EDIFieldValue("S0")]
    SoleProprietor,

    [EDIFieldValue("S1")]
    Parent,

    [EDIFieldValue("S2")]
    Student,

    [EDIFieldValue("S3")]
    CustodialParent,

    [EDIFieldValue("S4")]
    SkilledNursingFacility,

    [EDIFieldValue("S5")]
    SecuredParty,

    [EDIFieldValue("S6")]
    AgencyGrantingSecurityClearance,

    [EDIFieldValue("S7")]
    SecuredPartyCompany,

    [EDIFieldValue("S8")]
    SecuredPartyIndividual,

    [EDIFieldValue("S9")]
    Sibling,

    [EDIFieldValue("SA")]
    SalvageCarrier,

    [EDIFieldValue("SB")]
    StorageArea,

    [EDIFieldValue("SC")]
    StoreClass,

    [EDIFieldValue("SD")]
    SoldToAndShipTo,

    [EDIFieldValue("SE")]
    SellingParty,

    [EDIFieldValue("SF")]
    ShipFrom,

    [EDIFieldValue("SG")]
    StoreGroup,

    [EDIFieldValue("SH")]
    Shipper,

    [EDIFieldValue("SI")]
    ShippingScheduleIssuer,

    [EDIFieldValue("SJ")]
    ServiceProvider,

    [EDIFieldValue("SK")]
    SecondaryLocationAddress_SLA,

    [EDIFieldValue("SL")]
    OriginSublocation,

    [EDIFieldValue("SM")]
    PartyToReceiveShippingManifest,

    [EDIFieldValue("SN")]
    Store,

    [EDIFieldValue("SO")]
    SoldToIfDifferentFromBillTo,

    [EDIFieldValue("SP")]
    PartyfillingShippersOrder,

    [EDIFieldValue("SQ")]
    ServiceBureau,

    [EDIFieldValue("SR")]
    SamplesToBeReturnedTo,

    [EDIFieldValue("SS")]
    SteamshipCompany,

    [EDIFieldValue("ST")]
    ShipTo,

    [EDIFieldValue("SU")]
    SupplierManufacturer,

    [EDIFieldValue("SV")]
    ServicePerformanceSite,

    [EDIFieldValue("SW")]
    SealingCompany,

    [EDIFieldValue("SX")]
    School_basedServiceProvider,

    [EDIFieldValue("SY")]
    SecondaryTaxpayer,

    [EDIFieldValue("SZ")]
    Supervisor,

    [EDIFieldValue("T1")]
    OperatorOftheTransferPoint,

    [EDIFieldValue("T2")]
    OperatorOftheSourceTransferPoint,

    [EDIFieldValue("T3")]
    TerminalLocation,

    [EDIFieldValue("T4")]
    TransferPoint,

    [EDIFieldValue("T6")]
    TerminalOperator,

    [EDIFieldValue("T8")]
    PreviousTitleCompany,

    [EDIFieldValue("T9")]
    PriorTitleEvidenceHolder,

    [EDIFieldValue("TA")]
    TitleInsuranceServicesProvider,

    [EDIFieldValue("TB")]
    Tooling,

    [EDIFieldValue("TC")]
    ToolSource,

    [EDIFieldValue("TD")]
    ToolingDesign,

    [EDIFieldValue("TE")]
    Theatre,

    [EDIFieldValue("TF")]
    TankFarm,

    [EDIFieldValue("TG")]
    ToolingFabrication,

    [EDIFieldValue("TH")]
    TheaterCircuit,

    [EDIFieldValue("TI")]
    TariffIssuer,

    [EDIFieldValue("TJ")]
    Cosigner,

    [EDIFieldValue("TK")]
    TestSponsor,

    [EDIFieldValue("TL")]
    TestingLaboratory,

    [EDIFieldValue("TM")]
    Transmitter,

    [EDIFieldValue("TN")]
    Tradename,

    [EDIFieldValue("TO")]
    MessageTo,

    [EDIFieldValue("TP")]
    PrimaryTaxpayer,

    [EDIFieldValue("TQ")]
    ThirdPartyReviewingOrganization_TPO,

    [EDIFieldValue("TR")]
    Terminal,

    [EDIFieldValue("TS")]
    PartyToReceiveCertifiedTestResults,

    [EDIFieldValue("TT")]
    TransferTo,

    [EDIFieldValue("TU")]
    ThirdPartyRepricingOrganization_TPO,

    [EDIFieldValue("TV")]
    ThirdPartyAdministrator_TPA,

    [EDIFieldValue("TW")]
    TransitAuthority,

    [EDIFieldValue("TX")]
    TaxAuthority,

    [EDIFieldValue("TY")]
    Trustee,

    [EDIFieldValue("TZ")]
    SignificantOther,

    [EDIFieldValue("U1")]
    GasTransactionPoint1,

    [EDIFieldValue("U2")]
    GasTransactionPoint2,

    [EDIFieldValue("U3")]
    ServicingAgent_U3,

    [EDIFieldValue("U4")]
    Team,

    [EDIFieldValue("U5")]
    Underwriter,

    [EDIFieldValue("U6")]
    TitleUnderwriter,

    [EDIFieldValue("U7")]
    Psychologist,

    [EDIFieldValue("U8")]
    Reference,

    [EDIFieldValue("U9")]
    Non_RegisteredInvestmentAdvisor,

    [EDIFieldValue("UA")]
    PlaceOfBottling,

    [EDIFieldValue("UB")]
    PlaceOfDistilling,

    [EDIFieldValue("UC")]
    UltimateConsignee,

    [EDIFieldValue("UD")]
    Region,

    [EDIFieldValue("UE")]
    TestingService,

    [EDIFieldValue("UF")]
    HealthMiscellaneous,

    [EDIFieldValue("UG")]
    NursingHomeChain,

    [EDIFieldValue("UH")]
    NursingHome,

    [EDIFieldValue("UI")]
    RegisteredInvestmentAdvisor,

    [EDIFieldValue("UJ")]
    SalesAssistant,

    [EDIFieldValue("UK")]
    System,

    [EDIFieldValue("UL")]
    SpecialAccount,

    [EDIFieldValue("UM")]
    CurrentEmployer_Primary,

    [EDIFieldValue("UN")]
    Union,

    [EDIFieldValue("UO")]
    CurrentEmployer_Secondary,

    [EDIFieldValue("UP")]
    UnloadingParty,

    [EDIFieldValue("UQ")]
    SubsequentOwner,

    [EDIFieldValue("UR")]
    Surgeon,

    [EDIFieldValue("US")]
    UpstreamParty,

    [EDIFieldValue("UT")]
    USTrustee,

    [EDIFieldValue("UU")]
    AnnuitantPayor,

    [EDIFieldValue("UW")]
    UnassignedAgent,

    [EDIFieldValue("UX")]
    BaseJurisdiction,

    [EDIFieldValue("UY")]
    Vehicle,

    [EDIFieldValue("UZ")]
    Signer,

    [EDIFieldValue("V1")]
    Surety,

    [EDIFieldValue("V2")]
    Grantor,

    [EDIFieldValue("V3")]
    WellPadConstructionContractor,

    [EDIFieldValue("V4")]
    OilAndGasRegulatoryAgency,

    [EDIFieldValue("V5")]
    SurfaceDischargeAgency,

    [EDIFieldValue("V6")]
    WellCasingDepthAuthority,

    [EDIFieldValue("V8")]
    MarketTimer,

    [EDIFieldValue("V9")]
    OwnerAnnuitantPayor,

    [EDIFieldValue("VA")]
    SecondContact,

    [EDIFieldValue("VB")]
    Candidate,

    [EDIFieldValue("VC")]
    VehicleCustodian,

    [EDIFieldValue("VD")]
    MultipleListingService,

    [EDIFieldValue("VE")]
    BoardOfRealtors,

    [EDIFieldValue("VF")]
    SellingOffice,

    [EDIFieldValue("VG")]
    ListingAgent,

    [EDIFieldValue("VH")]
    ShowingAgent,

    [EDIFieldValue("VI")]
    ContactPerson,

    [EDIFieldValue("VJ")]
    OwnerJointAnnuitantPayor,

    [EDIFieldValue("VK")]
    PropertyOrBuildingManager,

    [EDIFieldValue("VL")]
    BuilderName,

    [EDIFieldValue("VM")]
    Occupant,

    [EDIFieldValue("VN")]
    Vendor,

    [EDIFieldValue("VO")]
    ElementarySchool,

    [EDIFieldValue("VP")]
    PartywithPowerToVoteSecurities,

    [EDIFieldValue("VQ")]
    MiddleSchool,

    [EDIFieldValue("VR")]
    JuniorHighSchool,

    [EDIFieldValue("VS")]
    VehicleSalvageAssignment,

    [EDIFieldValue("VT")]
    ListingOffice,

    [EDIFieldValue("VU")]
    SecondContactOrganization,

    [EDIFieldValue("VV")]
    OwnerPayor,

    [EDIFieldValue("VW")]
    Winner,

    [EDIFieldValue("VX")]
    ProductionManager_VX,

    [EDIFieldValue("VY")]
    OrganizationCompletingConfigurationChange,

    [EDIFieldValue("VZ")]
    ProductionManager_VZ,

    [EDIFieldValue("W1")]
    WorkTeam,

    [EDIFieldValue("W2")]
    SupplierWorkTeam,

    [EDIFieldValue("W3")]
    ThirdPartyInvestmentAdvisor,

    [EDIFieldValue("W4")]
    Trust,

    [EDIFieldValue("W8")]
    InterlineServiceCommitmentCustomer,

    [EDIFieldValue("W9")]
    SamplingLocation,

    [EDIFieldValue("WA")]
    WritingAgent,

    [EDIFieldValue("WB")]
    AppraiserName,

    [EDIFieldValue("WC")]
    ComparableProperty,

    [EDIFieldValue("WD")]
    StorageFacilityatDestination,

    [EDIFieldValue("WE")]
    SubjectProperty,

    [EDIFieldValue("WF")]
    TankFarmOwner,

    [EDIFieldValue("WG")]
    WageEarner,

    [EDIFieldValue("WH")]
    Warehouse,

    [EDIFieldValue("WI")]
    Witness,

    [EDIFieldValue("WJ")]
    SupervisoryAppraiserName,

    [EDIFieldValue("WL")]
    Wholesaler,

    [EDIFieldValue("WN")]
    CompanyAssignedWell,

    [EDIFieldValue("WO")]
    StorageFacilityatOrigin,

    [EDIFieldValue("WP")]
    WitnessforPlaintiff,

    [EDIFieldValue("WR")]
    WithdrawalPoint,

    [EDIFieldValue("WS")]
    WaterSystem,

    [EDIFieldValue("WT")]
    WitnessforDefendant,

    [EDIFieldValue("WU")]
    PrimarySupportOrganization,

    [EDIFieldValue("WV")]
    PreliminaryMaintenancePeriodDesignatingOrganization,

    [EDIFieldValue("WW")]
    PreliminaryMaintenanceOrganization,

    [EDIFieldValue("WX")]
    PreliminaryReferredToOrganization,

    [EDIFieldValue("WY")]
    FinalMaintenancePeriodDesignatingOrganization,

    [EDIFieldValue("WZ")]
    FinalMaintenanceOrganization,

    [EDIFieldValue("X1")]
    Mailto,

    [EDIFieldValue("X2")]
    PartyToPerformPackaging,

    [EDIFieldValue("X3")]
    UtilizationManagementOrganization,

    [EDIFieldValue("X4")]
    Spouse,

    [EDIFieldValue("X5")]
    DurableMedicalEquipmentSupplier,

    [EDIFieldValue("X6")]
    InternationalOrganization,

    [EDIFieldValue("X7")]
    Inventor,

    [EDIFieldValue("X8")]
    HispanicServiceInstitute,

    [EDIFieldValue("XA")]
    Creditor,

    [EDIFieldValue("XC")]
    DebtorsAttorney,

    [EDIFieldValue("XD")]
    Alias,

    [EDIFieldValue("XE")]
    ClaimRecipient,

    [EDIFieldValue("XF")]
    Auctioneer,

    [EDIFieldValue("XG")]
    EventLocation,

    [EDIFieldValue("XH")]
    FinalReferredToOrganization,

    [EDIFieldValue("XI")]
    OriginalClaimant,

    [EDIFieldValue("XJ")]
    ActualReferredByOrganization,

    [EDIFieldValue("XK")]
    ActualReferredToOrganization,

    [EDIFieldValue("XL")]
    BorrowersEmployer,

    [EDIFieldValue("XM")]
    MaintenanceOrganizationUsedforEstimate,

    [EDIFieldValue("XN")]
    PlanningMaintenanceOrganization,

    [EDIFieldValue("XO")]
    PreliminaryCustomerOrganization,

    [EDIFieldValue("XP")]
    PartyToReceiveSolicitation,

    [EDIFieldValue("XQ")]
    CanadianCustomsBroker,

    [EDIFieldValue("XR")]
    MexicanCustomsBroker,

    [EDIFieldValue("XS")]
    SCorporation,

    [EDIFieldValue("XT")]
    FinalCustomerOrganization,

    [EDIFieldValue("XU")]
    UnitedStatesCustomsBroker,

    [EDIFieldValue("XV")]
    CrossClaimant,

    [EDIFieldValue("XW")]
    CounterClaimant,

    [EDIFieldValue("XX")]
    BusinessArea,

    [EDIFieldValue("XY")]
    TribalGovernment,

    [EDIFieldValue("XZ")]
    AmericanIndian_OwnedBusiness,

    [EDIFieldValue("Y2")]
    ManagedCareOrganization,

    [EDIFieldValue("YA")]
    Affiant,

    [EDIFieldValue("YB")]
    Arbitrator,

    [EDIFieldValue("YC")]
    BailPayor,

    [EDIFieldValue("YD")]
    DistrictJustice,

    [EDIFieldValue("YE")]
    ThirdParty,

    [EDIFieldValue("YF")]
    WitnessforProsecution,

    [EDIFieldValue("YG")]
    ExpertWitness,

    [EDIFieldValue("YH")]
    CrimeVictim,

    [EDIFieldValue("YI")]
    JuvenileVictim,

    [EDIFieldValue("YJ")]
    JuvenileDefendant,

    [EDIFieldValue("YK")]
    Bondsman,

    [EDIFieldValue("YL")]
    CourtAppointedAttorney,

    [EDIFieldValue("YM")]
    ComplainantsAttorney,

    [EDIFieldValue("YN")]
    DistrictAttorney,

    [EDIFieldValue("YO")]
    AttorneyforDefendant_Public,

    [EDIFieldValue("YP")]
    ProBonoAttorney,

    [EDIFieldValue("YQ")]
    ProSeCounsel,

    [EDIFieldValue("YR")]
    PartyToAppearBefore,

    [EDIFieldValue("YS")]
    Appellant,

    [EDIFieldValue("YT")]
    Appellee,

    [EDIFieldValue("YU")]
    ArrestingOfficer,

    [EDIFieldValue("YV")]
    HostileWitness,

    [EDIFieldValue("YW")]
    DischargePoint,

    [EDIFieldValue("YX")]
    FloodCertifier,

    [EDIFieldValue("YY")]
    FloodDeterminationProvider,

    [EDIFieldValue("YZ")]
    ElectronicRegistrationUtility,

    [EDIFieldValue("Z1")]
    PartyToReceiveStatus,

    [EDIFieldValue("Z2")]
    UnserviceableMaterialConsignee,

    [EDIFieldValue("Z3")]
    PotentialSourceOfSupply,

    [EDIFieldValue("Z4")]
    OwningInventoryControlPoint,

    [EDIFieldValue("Z5")]
    ManagementControlActivity,

    [EDIFieldValue("Z6")]
    TransferringParty,

    [EDIFieldValue("Z7")]
    Mark_forParty,

    [EDIFieldValue("Z8")]
    LastKnownSourceOfSupply,

    [EDIFieldValue("Z9")]
    Banker,

    [EDIFieldValue("ZA")]
    CorrectedAddress,

    [EDIFieldValue("ZB")]
    PartyToReceiveCredit,

    [EDIFieldValue("ZC")]
    RentPayor,

    [EDIFieldValue("ZD")]
    PartyToReceiveReports,

    [EDIFieldValue("ZE")]
    EndItemManufacturer,

    [EDIFieldValue("ZF")]
    BreakBulkPoint,

    [EDIFieldValue("ZG")]
    PresentAddress,

    [EDIFieldValue("ZH")]
    Child,

    [EDIFieldValue("ZJ")]
    Branch,

    [EDIFieldValue("ZK")]
    Reporter,

    [EDIFieldValue("ZL")]
    PartyPassingtheTransaction,

    [EDIFieldValue("ZM")]
    LeaseLocation,

    [EDIFieldValue("ZN")]
    LosingInventoryManager,

    [EDIFieldValue("ZO")]
    MinimumRoyaltyPayor,

    [EDIFieldValue("ZP")]
    GainingInventoryManager,

    [EDIFieldValue("ZQ")]
    ScreeningPoint,

    [EDIFieldValue("ZR")]
    ValidatingParty,

    [EDIFieldValue("ZS")]
    MonitoringParty,

    [EDIFieldValue("ZT")]
    ParticipatingArea,

    [EDIFieldValue("ZU")]
    Formation,

    [EDIFieldValue("ZV")]
    AllowableRecipient,

    [EDIFieldValue("ZW")]
    Field,

    [EDIFieldValue("ZX")]
    AttorneyOfRecord,

    [EDIFieldValue("ZY")]
    AmicusCuriae,

    [EDIFieldValue("ZZ")]
    MutuallyDefined,

    [EDIFieldValue("001")]
    Pumper,

    [EDIFieldValue("002")]
    SurfaceManagementEntity,

    [EDIFieldValue("003")]
    ApplicationParty,

    [EDIFieldValue("004")]
    SiteOperator,

    [EDIFieldValue("005")]
    ConstructionContractor,

    [EDIFieldValue("006")]
    DrillingContractor,

    [EDIFieldValue("007")]
    SpudContractor,

    [EDIFieldValue("AAA")]
    Sub_account,

    [EDIFieldValue("AAB")]
    ManagementNon_Officer,

    [EDIFieldValue("AAC")]
    IncorporatedLocation,

    [EDIFieldValue("AAD")]
    NamenotToBeConfusedwith,

    [EDIFieldValue("AAE")]
    Lot,

    [EDIFieldValue("AAF")]
    PreviousOccupant,

    [EDIFieldValue("AAG")]
    GroundAmbulanceServices,

    [EDIFieldValue("AAH")]
    AirAmbulanceServices,

    [EDIFieldValue("AAI")]
    WaterAmbulanceServices,

    [EDIFieldValue("AAJ")]
    AdmittingServices,

    [EDIFieldValue("AAK")]
    PrimarySurgeon,

    [EDIFieldValue("AAL")]
    MedicalNurse,

    [EDIFieldValue("AAM")]
    CardiacRehabilitationServices,

    [EDIFieldValue("AAN")]
    SkilledNursingServices,

    [EDIFieldValue("AAO")]
    ObservationRoomServices,

    [EDIFieldValue("AAP")]
    Employee,

    [EDIFieldValue("AAQ")]
    AnesthesiologyServices,

    [EDIFieldValue("AAS")]
    PriorBaseJurisdiction,

    [EDIFieldValue("AAT")]
    IncorporationJurisdiction,

    [EDIFieldValue("AAU")]
    MarkerOwner,

    [EDIFieldValue("AAV")]
    ReclamationCenter,

    [EDIFieldValue("ABB")]
    MasterProperty,

    [EDIFieldValue("ABC")]
    ProjectProperty,

    [EDIFieldValue("ABD")]
    UnitProperty,

    [EDIFieldValue("ABE")]
    AdditionalAddress,

    [EDIFieldValue("ABF")]
    SocietyOfPropertyInformationCompilersAndAnalysts,

    [EDIFieldValue("ABG")]
    Organization,

    [EDIFieldValue("ABH")]
    JointOwnerAnnuitant,

    [EDIFieldValue("ABI")]
    JointAnnuitantOwner,

    [EDIFieldValue("ABJ")]
    JointOwnerAnnuitantPayor,

    [EDIFieldValue("ABK")]
    JointOwnerJointAnnuitant,

    [EDIFieldValue("ABL")]
    JointOwnerJointAnnuitantPayor,

    [EDIFieldValue("ABM")]
    JointOwnerPayor,

    [EDIFieldValue("ALA")]
    AlternativeAddressee,

    [EDIFieldValue("BAL")]
    Bailiff,

    [EDIFieldValue("BKR")]
    Bookkeeper,

    [EDIFieldValue("BRN")]
    BrandName,

    [EDIFieldValue("BUS")]
    Business,

    [EDIFieldValue("CMW")]
    CompanyMergedWith,

    [EDIFieldValue("COL")]
    CollateralAssignee,

    [EDIFieldValue("COR")]
    CorrectedName,

    [EDIFieldValue("DCC")]
    ChiefDeputyClerkOfCourt,

    [EDIFieldValue("DIR")]
    DistributionRecipient,

    [EDIFieldValue("ENR")]
    Enroller,

    [EDIFieldValue("EXS")]
    Ex_spouse,

    [EDIFieldValue("FRL")]
    ForeignRegistrationLocation,

    [EDIFieldValue("FSR")]
    FinancialStatementRecipient,

    [EDIFieldValue("GIR")]
    GiftRecipient,

    [EDIFieldValue("HMI")]
    MaterialSafetyDataSheet_MSDS_Recipient,

    [EDIFieldValue("HOM")]
    HomeOffice,

    [EDIFieldValue("IAA")]
    BusinessEntity,

    [EDIFieldValue("IAC")]
    PrincipalExecutiveOffice,

    [EDIFieldValue("IAD")]
    ForeignOffice,

    [EDIFieldValue("IAE")]
    Member,

    [EDIFieldValue("IAF")]
    ExecutiveCommitteeMember,

    [EDIFieldValue("IAG")]
    Director,

    [EDIFieldValue("IAH")]
    Clerk,

    [EDIFieldValue("IAI")]
    PartywithKnowledgeOfAffairsOftheCompany,

    [EDIFieldValue("IAK")]
    PartyToReceiveStatementOfFeesDue,

    [EDIFieldValue("IAL")]
    CompanyinwhichInterestHeld,

    [EDIFieldValue("IAM")]
    CompanywhichHoldsInterest,

    [EDIFieldValue("IAN")]
    Notary,

    [EDIFieldValue("IAO")]
    Manager,

    [EDIFieldValue("IAP")]
    AlienAffiliate,

    [EDIFieldValue("IAQ")]
    IncorporationStatePrincipalOffice,

    [EDIFieldValue("IAR")]
    IncorporationStatePlaceOfBusiness,

    [EDIFieldValue("IAS")]
    Out_of_StatePrincipalOffice,

    [EDIFieldValue("IAT")]
    PartyExecutingAndVerifying,

    [EDIFieldValue("IAU")]
    Felon,

    [EDIFieldValue("IAV")]
    OtherRelatedParty,

    [EDIFieldValue("IAW")]
    Record_KeepingAddress,

    [EDIFieldValue("IAY")]
    InitialSubscriber,

    [EDIFieldValue("IAZ")]
    OriginalJurisdiction,

    [EDIFieldValue("INV")]
    InvestmentAdvisor,

    [EDIFieldValue("LGS")]
    LocalGovernmentSponsor,

    [EDIFieldValue("LYM")]
    AmendedName,

    [EDIFieldValue("LYN")]
    Stockholder,

    [EDIFieldValue("LYO")]
    ManagingAgent,

    [EDIFieldValue("LYP")]
    Organizer,

    [EDIFieldValue("MSC")]
    MammographyScreeningCenter,

    [EDIFieldValue("NCT")]
    NameChangedTo,

    [EDIFieldValue("NPC")]
    NotaryPublic,

    [EDIFieldValue("ORI")]
    OriginalName,

    [EDIFieldValue("PLR")]
    PayerOfLastResort,

    [EDIFieldValue("PMF")]
    PartyManufacturedFor,

    [EDIFieldValue("PPS")]
    PersonforWhoseBenefitPropertywasSeized,

    [EDIFieldValue("PRE")]
    PreviousOwner,

    [EDIFieldValue("PRP")]
    PrimaryPayer,

    [EDIFieldValue("PUR")]
    PurchasedCompany,

    [EDIFieldValue("RCR")]
    RecoveryRoom,

    [EDIFieldValue("REC")]
    ReceiverManager,

    [EDIFieldValue("RGA")]
    ResponsibleGovernmentAgency,

    [EDIFieldValue("SEP")]
    SecondaryPayer,

    [EDIFieldValue("TPM")]
    ThirdPartyMarketer,

    [EDIFieldValue("TSE")]
    ConsigneeCourierTransferStation,

    [EDIFieldValue("TSR")]
    ConsignorCourierTransferStation,

    [EDIFieldValue("TTP")]
    TertiaryPayer
  }
}