﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum DTPQualifier
  {
    [EDIFieldValue("001")]
    CancelAfter,

    [EDIFieldValue("002")]
    DeliveryRequested,

    [EDIFieldValue("003")]
    Invoice,

    [EDIFieldValue("004")]
    PurchaseOrder,

    [EDIFieldValue("005")]
    Sailing,

    [EDIFieldValue("006")]
    Sold,

    [EDIFieldValue("007")]
    Effective,

    [EDIFieldValue("008")]
    PurchaseOrderReceived,

    [EDIFieldValue("009")]
    Process,

    [EDIFieldValue("010")]
    RequestedShip,

    [EDIFieldValue("011")]
    Shipped,

    [EDIFieldValue("012")]
    TermsDiscountDue,

    [EDIFieldValue("013")]
    TermsNetDue,

    [EDIFieldValue("014")]
    DeferredPayment,

    [EDIFieldValue("015")]
    PromotionStart,

    [EDIFieldValue("016")]
    PromotionEnd,

    [EDIFieldValue("017")]
    EstimatedDelivery,

    [EDIFieldValue("018")]
    Available,

    [EDIFieldValue("019")]
    Unloaded,

    [EDIFieldValue("020")]
    Check,

    [EDIFieldValue("021")]
    ChargeBack,

    [EDIFieldValue("022")]
    FreightBill,

    [EDIFieldValue("023")]
    PromotionOrder_Start,

    [EDIFieldValue("024")]
    PromotionOrder_End,

    [EDIFieldValue("025")]
    PromotionShip_Start,

    [EDIFieldValue("026")]
    PromotionShip_End,

    [EDIFieldValue("027")]
    PromotionRequestedDelivery_Start,

    [EDIFieldValue("028")]
    PromotionRequestedDelivery_End,

    [EDIFieldValue("029")]
    PromotionPerformance_Start,

    [EDIFieldValue("030")]
    PromotionPerformance_End,

    [EDIFieldValue("031")]
    PromotionInvoicePerformance_Start,

    [EDIFieldValue("032")]
    PromotionInvoicePerformance_End,

    [EDIFieldValue("033")]
    PromotionFloorStockProtect_Start,

    [EDIFieldValue("034")]
    PromotionFloorStockProtect_End,

    [EDIFieldValue("035")]
    Delivered,

    [EDIFieldValue("036")]
    Expiration,

    [EDIFieldValue("037")]
    ShipNotBefore,

    [EDIFieldValue("038")]
    ShipNoLater,

    [EDIFieldValue("039")]
    ShipWeekOf,

    [EDIFieldValue("040")]
    Status_AfterandIncluding,

    [EDIFieldValue("041")]
    Status_PriorandIncluding,

    [EDIFieldValue("042")]
    Superseded,

    [EDIFieldValue("043")]
    Publication,

    [EDIFieldValue("044")]
    SettlementDateasSpecifiedbytheOriginator,

    [EDIFieldValue("045")]
    EndorsementDate,

    [EDIFieldValue("046")]
    FieldFailure,

    [EDIFieldValue("047")]
    FunctionalTest,

    [EDIFieldValue("048")]
    SystemTest,

    [EDIFieldValue("049")]
    PrototypeTest,

    [EDIFieldValue("050")]
    Received,

    [EDIFieldValue("051")]
    CumulativeQuantityStart,

    [EDIFieldValue("052")]
    CumulativeQuantityEnd,

    [EDIFieldValue("053")]
    BuyersLocal,

    [EDIFieldValue("054")]
    SellersLocal,

    [EDIFieldValue("055")]
    Confirmed,

    [EDIFieldValue("056")]
    EstimatedPortOfEntry,

    [EDIFieldValue("057")]
    ActualPortOfEntry,

    [EDIFieldValue("058")]
    CustomsClearance,

    [EDIFieldValue("059")]
    InlandShip,

    [EDIFieldValue("060")]
    EngineeringChangeLevel,

    [EDIFieldValue("061")]
    CancelifNotDeliveredby,

    [EDIFieldValue("062")]
    Blueprint,

    [EDIFieldValue("063")]
    DoNotDeliverAfter,

    [EDIFieldValue("064")]
    DoNotDeliverBefore,

    [EDIFieldValue("065")]
    FirstScheduleDelivery,

    [EDIFieldValue("066")]
    FirstScheduleShip,

    [EDIFieldValue("067")]
    CurrentScheduleDelivery,

    [EDIFieldValue("068")]
    CurrentScheduleShip,

    [EDIFieldValue("069")]
    PromisedforDelivery,

    [EDIFieldValue("070")]
    ScheduledforDelivery_AfterandIncluding,

    [EDIFieldValue("071")]
    RequestedforDelivery_AfterandIncluding,

    [EDIFieldValue("072")]
    PromisedforDelivery_AfterandIncluding,

    [EDIFieldValue("073")]
    ScheduledforDelivery_PriortoandIncluding,

    [EDIFieldValue("074")]
    RequestedforDelivery_PriortoandIncluding,

    [EDIFieldValue("075")]
    PromisedforDelivery_PriortoandIncluding,

    [EDIFieldValue("076")]
    ScheduledforDelivery_WeekOf,

    [EDIFieldValue("077")]
    RequestedforDelivery_WeekOf,

    [EDIFieldValue("078")]
    PromisedforDelivery_WeekOf,

    [EDIFieldValue("079")]
    PromisedforShipment,

    [EDIFieldValue("080")]
    ScheduledforShipment_AfterandIncluding,

    [EDIFieldValue("081")]
    RequestedforShipment_AfterandIncluding,

    [EDIFieldValue("082")]
    PromisedforShipment_AfterandIncluding,

    [EDIFieldValue("083")]
    ScheduledforShipment_PriortoandIncluding,

    [EDIFieldValue("084")]
    RequestedforShipment_PriortoandIncluding,

    [EDIFieldValue("085")]
    PromisedforShipment_PriortoandIncluding,

    [EDIFieldValue("086")]
    ScheduledforShipment_WeekOf,

    [EDIFieldValue("087")]
    RequestedforShipment_WeekOf,

    [EDIFieldValue("088")]
    PromisedforShipment_WeekOf,

    [EDIFieldValue("089")]
    Inquiry,

    [EDIFieldValue("090")]
    ReportStart,

    [EDIFieldValue("091")]
    ReportEnd,

    [EDIFieldValue("092")]
    ContractEffective,

    [EDIFieldValue("093")]
    ContractExpiration,

    [EDIFieldValue("094")]
    Manufacture,

    [EDIFieldValue("095")]
    BillOfLading,

    [EDIFieldValue("096")]
    Discharge,

    [EDIFieldValue("097")]
    TransactionCreation,

    [EDIFieldValue("098")]
    Bid_Effective,

    [EDIFieldValue("099")]
    BidOpen_DateBidsWillBeOpened,

    [EDIFieldValue("100")]
    NoShippingScheduleEstablishedasOf,

    [EDIFieldValue("101")]
    NoProductionScheduleEstablishedasOf,

    [EDIFieldValue("102")]
    Issue,

    [EDIFieldValue("103")]
    Award,

    [EDIFieldValue("104")]
    SystemSurvey,

    [EDIFieldValue("105")]
    QualityRating,

    [EDIFieldValue("106")]
    RequiredBy,

    [EDIFieldValue("107")]
    Deposit,

    [EDIFieldValue("108")]
    Postmark,

    [EDIFieldValue("109")]
    ReceivedatLockbox,

    [EDIFieldValue("110")]
    OriginallyScheduledShip,

    [EDIFieldValue("111")]
    Manifest_ShipNotice,

    [EDIFieldValue("112")]
    BuyersDock,

    [EDIFieldValue("113")]
    SampleRequired,

    [EDIFieldValue("114")]
    ToolingRequired,

    [EDIFieldValue("115")]
    SampleAvailable,

    [EDIFieldValue("116")]
    ScheduledInterchangeDelivery,

    [EDIFieldValue("118")]
    RequestedPick_up,

    [EDIFieldValue("119")]
    TestPerformed,

    [EDIFieldValue("120")]
    ControlPlan,

    [EDIFieldValue("121")]
    FeasibilitySignOff,

    [EDIFieldValue("122")]
    FailureModeEffective,

    [EDIFieldValue("124")]
    GroupContractEffective,

    [EDIFieldValue("125")]
    GroupContractExpiration,

    [EDIFieldValue("126")]
    WholesaleContractEffective,

    [EDIFieldValue("127")]
    WholesaleContractExpiration,

    [EDIFieldValue("128")]
    ReplacementEffective,

    [EDIFieldValue("129")]
    CustomerContractEffective,

    [EDIFieldValue("130")]
    CustomerContractExpiration,

    [EDIFieldValue("131")]
    ItemContractEffective,

    [EDIFieldValue("132")]
    ItemContractExpiration,

    [EDIFieldValue("133")]
    AccountsReceivable_StatementDate,

    [EDIFieldValue("134")]
    ReadyforInspection,

    [EDIFieldValue("135")]
    Booking,

    [EDIFieldValue("136")]
    TechnicalRating,

    [EDIFieldValue("137")]
    DeliveryRating,

    [EDIFieldValue("138")]
    CommercialRating,

    [EDIFieldValue("139")]
    Estimated,

    [EDIFieldValue("140")]
    Actual,

    [EDIFieldValue("141")]
    Assigned,

    [EDIFieldValue("142")]
    Loss,

    [EDIFieldValue("143")]
    DueDateOfFirstPaymenttoPrincipalandInterest,

    [EDIFieldValue("144")]
    EstimatedAcceptance,

    [EDIFieldValue("145")]
    OpeningDate,

    [EDIFieldValue("146")]
    ClosingDate,

    [EDIFieldValue("147")]
    DueDateLastCompleteInstallmentPaid,

    [EDIFieldValue("148")]
    DateOfLocalOfficeApprovalOfConveyanceOfDamagedRealEstateProperty,

    [EDIFieldValue("149")]
    DateDeedFiledforRecord,

    [EDIFieldValue("150")]
    ServicePeriodStart,

    [EDIFieldValue("151")]
    ServicePeriodEnd,

    [EDIFieldValue("152")]
    EffectiveDateOfChange,

    [EDIFieldValue("153")]
    ServiceInterruption,

    [EDIFieldValue("154")]
    AdjustmentPeriodStart,

    [EDIFieldValue("155")]
    AdjustmentPeriodEnd,

    [EDIFieldValue("156")]
    AllotmentPeriodStart,

    [EDIFieldValue("157")]
    TestPeriodStart,

    [EDIFieldValue("158")]
    TestPeriodEnding,

    [EDIFieldValue("159")]
    BidPriceException,

    [EDIFieldValue("160")]
    SamplestobeReturnedBy,

    [EDIFieldValue("161")]
    LoadedonVessel,

    [EDIFieldValue("162")]
    PendingArchive,

    [EDIFieldValue("163")]
    ActualArchive,

    [EDIFieldValue("164")]
    FirstIssue,

    [EDIFieldValue("165")]
    FinalIssue,

    [EDIFieldValue("166")]
    Message,

    [EDIFieldValue("167")]
    MostRecentRevision_OrInitialVersion,

    [EDIFieldValue("168")]
    Release,

    [EDIFieldValue("169")]
    ProductAvailabilityDate,

    [EDIFieldValue("170")]
    SupplementalIssue,

    [EDIFieldValue("171")]
    Revision,

    [EDIFieldValue("172")]
    Correction,

    [EDIFieldValue("173")]
    WeekEnding,

    [EDIFieldValue("174")]
    MonthEnding,

    [EDIFieldValue("175")]
    Cancelifnotshippedby,

    [EDIFieldValue("176")]
    Expeditedon,

    [EDIFieldValue("177")]
    Cancellation,

    [EDIFieldValue("178")]
    Hold_AsOf,

    [EDIFieldValue("179")]
    HoldasStock_AsOf,

    [EDIFieldValue("180")]
    NoPromise_AsOf,

    [EDIFieldValue("181")]
    StopWork_AsOf,

    [EDIFieldValue("182")]
    WillAdvise_AsOf,

    [EDIFieldValue("183")]
    Connection,

    [EDIFieldValue("184")]
    Inventory,

    [EDIFieldValue("185")]
    VesselRegistry,

    [EDIFieldValue("186")]
    InvoicePeriodStart,

    [EDIFieldValue("187")]
    InvoicePeriodEnd,

    [EDIFieldValue("188")]
    CreditAdvice,

    [EDIFieldValue("189")]
    DebitAdvice,

    [EDIFieldValue("190")]
    ReleasedtoVessel,

    [EDIFieldValue("191")]
    MaterialSpecification,

    [EDIFieldValue("192")]
    DeliveryTicket,

    [EDIFieldValue("193")]
    PeriodStart,

    [EDIFieldValue("194")]
    PeriodEnd,

    [EDIFieldValue("195")]
    ContractRe_Open,

    [EDIFieldValue("196")]
    Start,

    [EDIFieldValue("197")]
    End,

    [EDIFieldValue("198")]
    Completion,

    [EDIFieldValue("199")]
    Seal,

    [EDIFieldValue("200")]
    AssemblyStart,

    [EDIFieldValue("201")]
    Acceptance,

    [EDIFieldValue("202")]
    MasterLeaseAgreement,

    [EDIFieldValue("203")]
    FirstProduced,

    [EDIFieldValue("204")]
    OfficialRailCarInterchange_EitherActualorAgreedUpon,

    [EDIFieldValue("205")]
    Transmitted,

    [EDIFieldValue("206")]
    Status_OutsideProcessor,

    [EDIFieldValue("207")]
    Status_Commercial,

    [EDIFieldValue("208")]
    LotNumberExpiration,

    [EDIFieldValue("209")]
    ContractPerformanceStart,

    [EDIFieldValue("210")]
    ContractPerformanceDelivery,

    [EDIFieldValue("211")]
    ServiceRequested,

    [EDIFieldValue("212")]
    ReturnedtoCustomer,

    [EDIFieldValue("213")]
    AdjustmenttoBillDated,

    [EDIFieldValue("214")]
    DateOfRepair_Service,

    [EDIFieldValue("215")]
    InterruptionStart,

    [EDIFieldValue("216")]
    InterruptionEnd,

    [EDIFieldValue("217")]
    Spud,

    [EDIFieldValue("218")]
    InitialCompletion,

    [EDIFieldValue("219")]
    PluggedandAbandoned,

    [EDIFieldValue("220")]
    Penalty,

    [EDIFieldValue("221")]
    PenaltyBegin,

    [EDIFieldValue("222")]
    Birth,

    [EDIFieldValue("223")]
    BirthCertificate,

    [EDIFieldValue("224")]
    Adoption,

    [EDIFieldValue("225")]
    Christening,

    [EDIFieldValue("226")]
    LeaseCommencement,

    [EDIFieldValue("227")]
    LeaseTermStart,

    [EDIFieldValue("228")]
    LeaseTermEnd,

    [EDIFieldValue("229")]
    RentStart,

    [EDIFieldValue("230")]
    Installation,

    [EDIFieldValue("231")]
    ProgressPayment,

    [EDIFieldValue("232")]
    ClaimStatementPeriodStart,

    [EDIFieldValue("233")]
    ClaimStatementPeriodEnd,

    [EDIFieldValue("234")]
    SettlementDate,

    [EDIFieldValue("235")]
    DelayedBilling_NotDelayedPayment,

    [EDIFieldValue("236")]
    LenderCreditCheck,

    [EDIFieldValue("237")]
    StudentSigned,

    [EDIFieldValue("238")]
    ScheduleRelease,

    [EDIFieldValue("239")]
    Baseline,

    [EDIFieldValue("240")]
    BaselineStart,

    [EDIFieldValue("241")]
    BaselineComplete,

    [EDIFieldValue("242")]
    ActualStart,

    [EDIFieldValue("243")]
    ActualComplete,

    [EDIFieldValue("244")]
    EstimatedStart,

    [EDIFieldValue("245")]
    EstimatedCompletion,

    [EDIFieldValue("246")]
    Startnoearlierthan,

    [EDIFieldValue("247")]
    Startnolaterthan,

    [EDIFieldValue("248")]
    Finishnolaterthan,

    [EDIFieldValue("249")]
    Finishnoearlierthan,

    [EDIFieldValue("250")]
    Mandatory_orTarget_Start,

    [EDIFieldValue("251")]
    Mandatory_orTarget_Finish,

    [EDIFieldValue("252")]
    EarlyStart,

    [EDIFieldValue("253")]
    EarlyFinish,

    [EDIFieldValue("254")]
    LateStart,

    [EDIFieldValue("255")]
    LateFinish,

    [EDIFieldValue("256")]
    ScheduledStart,

    [EDIFieldValue("257")]
    ScheduledFinish,

    [EDIFieldValue("258")]
    OriginalEarlyStart,

    [EDIFieldValue("259")]
    OriginalEarlyFinish,

    [EDIFieldValue("260")]
    RestDay,

    [EDIFieldValue("261")]
    RestStart,

    [EDIFieldValue("262")]
    RestFinish,

    [EDIFieldValue("263")]
    Holiday,

    [EDIFieldValue("264")]
    HolidayStart,

    [EDIFieldValue("265")]
    HolidayFinish,

    [EDIFieldValue("266")]
    Base,

    [EDIFieldValue("267")]
    Timenow,

    [EDIFieldValue("268")]
    EndDateOfSupport,

    [EDIFieldValue("269")]
    DateAccountMatures,

    [EDIFieldValue("270")]
    DateFiled,

    [EDIFieldValue("271")]
    PenaltyEnd,

    [EDIFieldValue("272")]
    ExitPlantDate,

    [EDIFieldValue("273")]
    LatestOnBoardCarrierDate,

    [EDIFieldValue("274")]
    RequestedDepartureDate,

    [EDIFieldValue("275")]
    Approved,

    [EDIFieldValue("276")]
    ContractStart,

    [EDIFieldValue("277")]
    ContractDefinition,

    [EDIFieldValue("278")]
    LastItemDelivery,

    [EDIFieldValue("279")]
    ContractCompletion,

    [EDIFieldValue("280")]
    DateCourseOfOrthodonticsTreatmentBeganorisExpectedtoBegin,

    [EDIFieldValue("281")]
    OverTargetBaselineMonth,

    [EDIFieldValue("282")]
    PreviousReport,

    [EDIFieldValue("283")]
    FundsAppropriation_Start,

    [EDIFieldValue("284")]
    FundsAppropriation_End,

    [EDIFieldValue("285")]
    EmploymentorHire,

    [EDIFieldValue("286")]
    Retirement,

    [EDIFieldValue("287")]
    Medicare,

    [EDIFieldValue("288")]
    ConsolidatedOmnibusBudgetReconciliationAct_COBRA_288,

    [EDIFieldValue("289")]
    PremiumPaidtoDate,

    [EDIFieldValue("290")]
    CoordinationOfBenefits,

    [EDIFieldValue("291")]
    Plan,

    [EDIFieldValue("292")]
    Benefit,

    [EDIFieldValue("293")]
    Education,

    [EDIFieldValue("294")]
    EarningsEffectiveDate,

    [EDIFieldValue("295")]
    PrimaryCareProvider,

    [EDIFieldValue("296")]
    ReturntoWork,

    [EDIFieldValue("297")]
    DateLastWorked,

    [EDIFieldValue("298")]
    LatestAbsence,

    [EDIFieldValue("299")]
    Illness,

    [EDIFieldValue("300")]
    EnrollmentSignatureDate,

    [EDIFieldValue("301")]
    ConsolidatedOmnibusBudgetReconciliationAct_COBRA_QualifyingEvent,

    [EDIFieldValue("302")]
    Maintenance,

    [EDIFieldValue("303")]
    MaintenanceEffective,

    [EDIFieldValue("304")]
    LatestVisitorConsultation,

    [EDIFieldValue("305")]
    NetCreditServiceDate,

    [EDIFieldValue("306")]
    AdjustmentEffectiveDate,

    [EDIFieldValue("307")]
    Eligibility,

    [EDIFieldValue("308")]
    Pre_AwardSurvey,

    [EDIFieldValue("309")]
    PlanTermination,

    [EDIFieldValue("310")]
    DateOfClosing,

    [EDIFieldValue("311")]
    LatestReceivingDate_CutoffDate,

    [EDIFieldValue("312")]
    SalaryDeferral,

    [EDIFieldValue("313")]
    Cycle,

    [EDIFieldValue("314")]
    Disability,

    [EDIFieldValue("315")]
    Offset,

    [EDIFieldValue("316")]
    PriorIncorrectDateOfBirth,

    [EDIFieldValue("317")]
    CorrectedDateOfBirth,

    [EDIFieldValue("318")]
    Added,

    [EDIFieldValue("319")]
    Failed,

    [EDIFieldValue("320")]
    DateForeclosureProceedingsInstituted,

    [EDIFieldValue("321")]
    Purchased,

    [EDIFieldValue("322")]
    PutintoService,

    [EDIFieldValue("323")]
    Replaced,

    [EDIFieldValue("324")]
    Returned,

    [EDIFieldValue("325")]
    DisbursementDate,

    [EDIFieldValue("326")]
    GuaranteeDate,

    [EDIFieldValue("327")]
    QuarterEnding,

    [EDIFieldValue("328")]
    Changed,

    [EDIFieldValue("329")]
    Terminated,

    [EDIFieldValue("330")]
    ReferralDate,

    [EDIFieldValue("331")]
    EvaluationDate,

    [EDIFieldValue("332")]
    PlacementDate,

    [EDIFieldValue("333")]
    IndividualEducationPlan_IEP,

    [EDIFieldValue("334")]
    Re_evaluationDate,

    [EDIFieldValue("335")]
    DismissalDate,

    [EDIFieldValue("336")]
    EmploymentBegin,

    [EDIFieldValue("337")]
    EmploymentEnd,

    [EDIFieldValue("338")]
    MedicareBegin,

    [EDIFieldValue("339")]
    MedicareEnd,

    [EDIFieldValue("340")]
    ConsolidatedOmnibusBudgetReconciliationAct_COBRA_Begin_340,

    [EDIFieldValue("341")]
    ConsolidatedOmnibusBudgetReconciliationAct_COBRA_End_341,

    [EDIFieldValue("342")]
    PremiumPaidToDateBegin,

    [EDIFieldValue("343")]
    PremiumPaidToDateEnd,

    [EDIFieldValue("344")]
    CoordinationOfBenefitsBegin,

    [EDIFieldValue("345")]
    CoordinationOfBenefitsEnd,

    [EDIFieldValue("346")]
    PlanBegin,

    [EDIFieldValue("347")]
    PlanEnd,

    [EDIFieldValue("348")]
    BenefitBegin,

    [EDIFieldValue("349")]
    BenefitEnd,

    [EDIFieldValue("350")]
    EducationBegin,

    [EDIFieldValue("351")]
    EducationEnd,

    [EDIFieldValue("352")]
    PrimaryCareProviderBegin,

    [EDIFieldValue("353")]
    PrimaryCareProviderEnd,

    [EDIFieldValue("354")]
    IllnessBegin,

    [EDIFieldValue("355")]
    IllnessEnd,

    [EDIFieldValue("356")]
    EligibilityBegin,

    [EDIFieldValue("357")]
    EligibilityEnd,

    [EDIFieldValue("358")]
    CycleBegin,

    [EDIFieldValue("359")]
    CycleEnd,

    [EDIFieldValue("360")]
    DisabilityBegin,

    [EDIFieldValue("361")]
    DisabilityEnd,

    [EDIFieldValue("362")]
    OffsetBegin,

    [EDIFieldValue("363")]
    OffsetEnd,

    [EDIFieldValue("364")]
    PlanPeriodElectionBegin,

    [EDIFieldValue("365")]
    PlanPeriodElectionEnd,

    [EDIFieldValue("366")]
    PlanPeriodElection,

    [EDIFieldValue("367")]
    DuetoCustomer,

    [EDIFieldValue("368")]
    Submittal,

    [EDIFieldValue("369")]
    EstimatedDepartureDate,

    [EDIFieldValue("370")]
    ActualDepartureDate,

    [EDIFieldValue("371")]
    EstimatedArrivalDate,

    [EDIFieldValue("372")]
    ActualArrivalDate,

    [EDIFieldValue("373")]
    OrderStart,

    [EDIFieldValue("374")]
    OrderEnd,

    [EDIFieldValue("375")]
    DeliveryStart,

    [EDIFieldValue("376")]
    DeliveryEnd,

    [EDIFieldValue("377")]
    ContractCostsThrough,

    [EDIFieldValue("378")]
    FinancialInformationSubmission,

    [EDIFieldValue("379")]
    BusinessTermination,

    [EDIFieldValue("380")]
    ApplicantSigned,

    [EDIFieldValue("381")]
    CosignerSigned,

    [EDIFieldValue("382")]
    Enrollment,

    [EDIFieldValue("383")]
    AdjustedHire,

    [EDIFieldValue("384")]
    CreditedService,

    [EDIFieldValue("385")]
    CreditedServiceBegin,

    [EDIFieldValue("386")]
    CreditedServiceEnd,

    [EDIFieldValue("387")]
    DeferredDistribution,

    [EDIFieldValue("388")]
    PaymentCommencement,

    [EDIFieldValue("389")]
    PayrollPeriod,

    [EDIFieldValue("390")]
    PayrollPeriodBegin,

    [EDIFieldValue("391")]
    PayrollPeriodEnd,

    [EDIFieldValue("392")]
    PlanEntry,

    [EDIFieldValue("393")]
    PlanParticipationSuspension,

    [EDIFieldValue("394")]
    Rehire,

    [EDIFieldValue("395")]
    Retermination,

    [EDIFieldValue("396")]
    Termination,

    [EDIFieldValue("397")]
    Valuation,

    [EDIFieldValue("398")]
    VestingService,

    [EDIFieldValue("399")]
    VestingServiceBegin,

    [EDIFieldValue("400")]
    VestingServiceEnd,

    [EDIFieldValue("401")]
    DuplicateBill,

    [EDIFieldValue("402")]
    AdjustmentPromised,

    [EDIFieldValue("403")]
    AdjustmentProcessed,

    [EDIFieldValue("404")]
    YearEnding,

    [EDIFieldValue("405")]
    Production,

    [EDIFieldValue("406")]
    MaterialClassification,

    [EDIFieldValue("408")]
    Weighed,

    [EDIFieldValue("409")]
    DateOfDeedinLieu,

    [EDIFieldValue("410")]
    DateOfFirmCommitment,

    [EDIFieldValue("411")]
    ExpirationDateOfExtensionToForeclose,

    [EDIFieldValue("412")]
    DateOfNoticetoConvey,

    [EDIFieldValue("413")]
    DateOfReleaseOfBankruptcy,

    [EDIFieldValue("414")]
    OptimisticEarlyStart,

    [EDIFieldValue("415")]
    OptimisticEarlyFinish,

    [EDIFieldValue("416")]
    OptimisticLateStart,

    [EDIFieldValue("417")]
    OptimisticLateFinish,

    [EDIFieldValue("418")]
    MostLikelyEarlyStart,

    [EDIFieldValue("419")]
    MostLikelyEarlyFinish,

    [EDIFieldValue("420")]
    MostLikelyLateStart,

    [EDIFieldValue("421")]
    MostLikelyLateFinish,

    [EDIFieldValue("422")]
    PessimisticEarlyStart,

    [EDIFieldValue("423")]
    PessimisticEarlyFinish,

    [EDIFieldValue("424")]
    PessimisticLateStart,

    [EDIFieldValue("425")]
    PessimisticLateFinish,

    [EDIFieldValue("426")]
    FirstPaymentDue,

    [EDIFieldValue("427")]
    FirstInterestPaymentDue,

    [EDIFieldValue("428")]
    SubsequentInterestPaymentDue,

    [EDIFieldValue("429")]
    IrregularInterestPaymentDue,

    [EDIFieldValue("430")]
    GuarantorReceived,

    [EDIFieldValue("431")]
    OnsetOfCurrentSymptomsorIllness,

    [EDIFieldValue("432")]
    Submission,

    [EDIFieldValue("433")]
    Removed,

    [EDIFieldValue("434")]
    Statement,

    [EDIFieldValue("435")]
    Admission,

    [EDIFieldValue("436")]
    InsuranceCard,

    [EDIFieldValue("437")]
    SpouseRetirement,

    [EDIFieldValue("438")]
    OnsetOfSimilarSymptomsorIllness,

    [EDIFieldValue("439")]
    Accident,

    [EDIFieldValue("440")]
    ReleaseOfInformation,

    [EDIFieldValue("441")]
    PriorPlacement,

    [EDIFieldValue("442")]
    DateOfDeath,

    [EDIFieldValue("443")]
    PeerReviewOrganization_PRO_ApprovedStay,

    [EDIFieldValue("444")]
    FirstVisitorConsultation,

    [EDIFieldValue("445")]
    InitialPlacement,

    [EDIFieldValue("446")]
    Replacement,

    [EDIFieldValue("447")]
    Occurrence,

    [EDIFieldValue("448")]
    OccurrenceSpan,

    [EDIFieldValue("449")]
    OccurrenceSpanFrom,

    [EDIFieldValue("450")]
    OccurrenceSpanTo,

    [EDIFieldValue("451")]
    InitialFeeDue,

    [EDIFieldValue("452")]
    AppliancePlacement,

    [EDIFieldValue("453")]
    AcuteManifestationOfAChronicCondition,

    [EDIFieldValue("454")]
    InitialTreatment,

    [EDIFieldValue("455")]
    LastX_Ray,

    [EDIFieldValue("456")]
    Surgery,

    [EDIFieldValue("457")]
    ContinuousPassiveMotion_CPM,

    [EDIFieldValue("458")]
    Certification,

    [EDIFieldValue("459")]
    NursingHomeFrom,

    [EDIFieldValue("460")]
    NursingHomeTo,

    [EDIFieldValue("461")]
    LastCertification,

    [EDIFieldValue("462")]
    DateOfLocalOfficeApprovalOfConveyanceOfOccupiedRealEstateProperty,

    [EDIFieldValue("463")]
    BeginTherapy,

    [EDIFieldValue("464")]
    OxygenTherapyFrom,

    [EDIFieldValue("465")]
    OxygenTherapyTo,

    [EDIFieldValue("466")]
    OxygenTherapy,

    [EDIFieldValue("467")]
    Signature,

    [EDIFieldValue("468")]
    PrescriptionFill,

    [EDIFieldValue("469")]
    ProviderSignature,

    [EDIFieldValue("470")]
    DateOfLocalOfficeCertificationOfConveyanceOfDamagedRealEstateProperty,

    [EDIFieldValue("471")]
    Prescription,

    [EDIFieldValue("472")]
    Service,

    [EDIFieldValue("473")]
    MedicaidBegin,

    [EDIFieldValue("474")]
    MedicaidEnd,

    [EDIFieldValue("475")]
    Medicaid,

    [EDIFieldValue("476")]
    PeerReviewOrganization_PRO_ApprovedStayFrom,

    [EDIFieldValue("477")]
    PeerReviewOrganization_PRO_ApprovedStayTo,

    [EDIFieldValue("478")]
    PrescriptionFrom,

    [EDIFieldValue("479")]
    PrescriptionTo,

    [EDIFieldValue("480")]
    ArterialBloodGasTest,

    [EDIFieldValue("481")]
    OxygenSaturationTest,

    [EDIFieldValue("482")]
    PregnancyBegin,

    [EDIFieldValue("483")]
    PregnancyEnd,

    [EDIFieldValue("484")]
    LastMenstrualPeriod,

    [EDIFieldValue("485")]
    InjuryBegin,

    [EDIFieldValue("486")]
    InjuryEnd,

    [EDIFieldValue("487")]
    NursingHome,

    [EDIFieldValue("488")]
    CollateralDependent,

    [EDIFieldValue("489")]
    CollateralDependentBegin,

    [EDIFieldValue("490")]
    CollateralDependentEnd,

    [EDIFieldValue("491")]
    SponsoredDependent,

    [EDIFieldValue("492")]
    SponsoredDependentBegin,

    [EDIFieldValue("493")]
    SponsoredDependentEnd,

    [EDIFieldValue("494")]
    Deductible,

    [EDIFieldValue("495")]
    OutOfPocket,

    [EDIFieldValue("496")]
    ContractAuditDate,

    [EDIFieldValue("497")]
    LatestDeliveryDateatPier,

    [EDIFieldValue("498")]
    MortgageeReportedCurtailmentDate,

    [EDIFieldValue("499")]
    MortgageeOfficialSignatureDate,

    [EDIFieldValue("500")]
    Resubmission,

    [EDIFieldValue("501")]
    ExpectedReply,

    [EDIFieldValue("502")]
    DroppedtoLessthanHalfTime,

    [EDIFieldValue("503")]
    RepaymentBegin,

    [EDIFieldValue("504")]
    LoanServicingTransfer,

    [EDIFieldValue("505")]
    LoanPurchase,

    [EDIFieldValue("506")]
    LastNotification,

    [EDIFieldValue("507")]
    Extract,

    [EDIFieldValue("508")]
    Extended,

    [EDIFieldValue("509")]
    ServicerSignatureDate,

    [EDIFieldValue("510")]
    DatePacked,

    [EDIFieldValue("511")]
    ShelfLifeExpiration,

    [EDIFieldValue("512")]
    WarrantyExpiration,

    [EDIFieldValue("513")]
    Overhauled,

    [EDIFieldValue("514")]
    Transferred,

    [EDIFieldValue("515")]
    Notified,

    [EDIFieldValue("516")]
    Discovered,

    [EDIFieldValue("517")]
    Inspected,

    [EDIFieldValue("518")]
    Voucher_DateOf,

    [EDIFieldValue("519")]
    DateBankruptcyFiled,

    [EDIFieldValue("520")]
    DateOfDamage,

    [EDIFieldValue("521")]
    DateHazardInsurancePolicyCancelled,

    [EDIFieldValue("522")]
    ExpirationDatetoSubmitTitleEvidence,

    [EDIFieldValue("523")]
    DateOfClaim,

    [EDIFieldValue("524")]
    DateOfNoticeOfReferralforAssignment,

    [EDIFieldValue("525")]
    DateOfNoticeOfProbableIneligibilityforAssignment,

    [EDIFieldValue("526")]
    DateOfForeclosureNotice,

    [EDIFieldValue("527")]
    ExpirationOfForeclosureTimeframe,

    [EDIFieldValue("528")]
    DatePossessoryActionInitiated,

    [EDIFieldValue("529")]
    DateOfPossession,

    [EDIFieldValue("530")]
    DateOfLastInstallmentReceived,

    [EDIFieldValue("531")]
    DateOfAcquisitionOfTitle,

    [EDIFieldValue("532")]
    ExpirationOfExtensiontoConvey,

    [EDIFieldValue("533")]
    DateOfAssignmentApproval,

    [EDIFieldValue("534")]
    DateOfAssignmentRejection,

    [EDIFieldValue("535")]
    CurtailmentDatefromAdviceOfPayment,

    [EDIFieldValue("536")]
    ExpirationOfExtensiontoSubmitFiscalData,

    [EDIFieldValue("537")]
    DateDocumentation,
    orPaperwork,
    orBothWasSent,

    [EDIFieldValue("538")]
    MakegoodCommercialDate,

    [EDIFieldValue("539")]
    PolicyEffective,

    [EDIFieldValue("540")]
    PolicyExpiration,

    [EDIFieldValue("541")]
    EmployeeEffectiveDateOfCoverage,

    [EDIFieldValue("542")]
    DateOfRepresentation,

    [EDIFieldValue("543")]
    LastPremiumPaidDate,

    [EDIFieldValue("544")]
    DateReportedtoEmployer,

    [EDIFieldValue("545")]
    DateReportedtoClaimAdministrator,

    [EDIFieldValue("546")]
    DateOfMaximumMedicalImprovement,

    [EDIFieldValue("547")]
    DateOfLoan,

    [EDIFieldValue("548")]
    DateOfAdvance,

    [EDIFieldValue("549")]
    BeginningLayDate,

    [EDIFieldValue("550")]
    CertificateEffective,

    [EDIFieldValue("551")]
    BenefitApplicationDate,

    [EDIFieldValue("552")]
    ActualReturntoWork,

    [EDIFieldValue("553")]
    ReleasedReturntoWork,

    [EDIFieldValue("554")]
    EndingLayDate,

    [EDIFieldValue("555")]
    EmployeeWagesCeased,

    [EDIFieldValue("556")]
    LastSalaryIncrease,

    [EDIFieldValue("557")]
    EmployeeLaidOff,

    [EDIFieldValue("558")]
    InjuryorIllness,

    [EDIFieldValue("559")]
    OldestUnpaidInstallment,

    [EDIFieldValue("560")]
    PreforeclosureAcceptanceDate,

    [EDIFieldValue("561")]
    PreforeclosureSaleClosingDate,

    [EDIFieldValue("562")]
    DateOfFirstUncuredDefault,

    [EDIFieldValue("563")]
    DateDefaultWasCured,

    [EDIFieldValue("564")]
    DateOfFirstMortgagePayment,

    [EDIFieldValue("565")]
    DateOfPropertyInspection,

    [EDIFieldValue("566")]
    DateTotalAmountOfDelinquencyReported,

    [EDIFieldValue("567")]
    DateOutstandingLoanBalanceReported,

    [EDIFieldValue("568")]
    DateForeclosureSaleScheduled,

    [EDIFieldValue("569")]
    DateForeclosureHeld,

    [EDIFieldValue("570")]
    DateRedemptionPeriodEnds,

    [EDIFieldValue("571")]
    DateVoluntaryConveyanceAccepted,

    [EDIFieldValue("572")]
    DatePropertySold,

    [EDIFieldValue("573")]
    DateClaimPaid,

    [EDIFieldValue("574")]
    ActionBeginDate,

    [EDIFieldValue("575")]
    ProjectedActionEndDate,

    [EDIFieldValue("576")]
    ActionEndDate,

    [EDIFieldValue("577")]
    OriginalMaturityDate,

    [EDIFieldValue("578")]
    DateReferredtoAttorneyforForeclosure,

    [EDIFieldValue("579")]
    PlannedRelease,

    [EDIFieldValue("580")]
    ActualRelease,

    [EDIFieldValue("581")]
    ContractPeriod,

    [EDIFieldValue("582")]
    ReportPeriod,

    [EDIFieldValue("583")]
    Suspension,

    [EDIFieldValue("584")]
    Reinstatement_584,

    [EDIFieldValue("585")]
    Report,

    [EDIFieldValue("586")]
    FirstContact,

    [EDIFieldValue("587")]
    ProjectedForeclosureSaleDate,

    [EDIFieldValue("589")]
    DateAssignmentFiledforRecord,

    [EDIFieldValue("590")]
    DateOfAppraisal,

    [EDIFieldValue("591")]
    ExpirationDateOfExtensiontoAssign,

    [EDIFieldValue("592")]
    DateOfExtensiontoConvey,

    [EDIFieldValue("593")]
    DateHazardInsurancePolicyRefused,

    [EDIFieldValue("594")]
    HighFabricationReleaseAuthorization,

    [EDIFieldValue("595")]
    HighRawMaterialAuthorization,

    [EDIFieldValue("596")]
    MaterialChangeNotice,

    [EDIFieldValue("597")]
    LatestDeliveryDateatRailRamp,

    [EDIFieldValue("598")]
    Rejected,

    [EDIFieldValue("599")]
    RepaymentScheduleSent,

    [EDIFieldValue("600")]
    AsOf,

    [EDIFieldValue("601")]
    FirstSubmission,

    [EDIFieldValue("602")]
    SubsequentSubmission,

    [EDIFieldValue("603")]
    Renewal,

    [EDIFieldValue("604")]
    Withdrawn,

    [EDIFieldValue("606")]
    CertificationPeriodStart,

    [EDIFieldValue("607")]
    CertificationRevision,

    [EDIFieldValue("608")]
    ContinuousCoverageDates,

    [EDIFieldValue("609")]
    PrearrangedDealMatch,

    [EDIFieldValue("610")]
    ContingencyEnd,

    [EDIFieldValue("611")]
    OxygenTherapyEvaluation,

    [EDIFieldValue("612")]
    ShutIn,

    [EDIFieldValue("613")]
    AllowableEffective,

    [EDIFieldValue("614")]
    FirstSales,

    [EDIFieldValue("615")]
    DateAcquired,

    [EDIFieldValue("616")]
    InterviewerSigned,

    [EDIFieldValue("617")]
    ApplicationLoggedDate,

    [EDIFieldValue("618")]
    ReviewDate,

    [EDIFieldValue("619")]
    DecisionDate,

    [EDIFieldValue("620")]
    PreviouslyResided,

    [EDIFieldValue("621")]
    Reported,

    [EDIFieldValue("622")]
    Checked,

    [EDIFieldValue("623")]
    Settled,

    [EDIFieldValue("624")]
    PresentlyResiding,

    [EDIFieldValue("625")]
    EmployedinthisPosition,

    [EDIFieldValue("626")]
    Verified,

    [EDIFieldValue("627")]
    SecondAdmissionDate,

    [EDIFieldValue("629")]
    AccountOpened,

    [EDIFieldValue("630")]
    AccountClosed,

    [EDIFieldValue("631")]
    PropertyAcquired,

    [EDIFieldValue("632")]
    PropertyBuilt,

    [EDIFieldValue("633")]
    EmployedinthisProfession,

    [EDIFieldValue("634")]
    NextReviewDate,

    [EDIFieldValue("635")]
    InitialContactDate,

    [EDIFieldValue("636")]
    DateOfLastUpdate,

    [EDIFieldValue("637")]
    SecondDischargeDate,

    [EDIFieldValue("638")]
    DateOfLastDraw,

    [EDIFieldValue("640")]
    Complaint,

    [EDIFieldValue("641")]
    Option,

    [EDIFieldValue("642")]
    Solicitation,

    [EDIFieldValue("643")]
    Clause,

    [EDIFieldValue("644")]
    Meeting,

    [EDIFieldValue("646")]
    RentalPeriod,

    [EDIFieldValue("647")]
    NextPayIncrease,

    [EDIFieldValue("648")]
    PeriodCoveredbySourceDocuments,

    [EDIFieldValue("649")]
    DocumentDue,

    [EDIFieldValue("650")]
    CourtNotice,

    [EDIFieldValue("651")]
    ExpectedFundingDate,

    [EDIFieldValue("652")]
    AssignmentRecorded,

    [EDIFieldValue("653")]
    CaseReopened,

    [EDIFieldValue("655")]
    PreviousCourtEvent,

    [EDIFieldValue("656")]
    LastDatetoObject,

    [EDIFieldValue("657")]
    CourtEvent,

    [EDIFieldValue("658")]
    LastDateToFileAClaim,

    [EDIFieldValue("659")]
    CaseConverted,

    [EDIFieldValue("660")]
    DebtIncurred,

    [EDIFieldValue("661")]
    Judgment,

    [EDIFieldValue("662")]
    WagesStart,

    [EDIFieldValue("663")]
    WagesEnd,

    [EDIFieldValue("664")]
    DateThroughWhichPropertyTaxesHaveBeenPaid,

    [EDIFieldValue("665")]
    PaidThroughDate,

    [EDIFieldValue("666")]
    DatePaid,

    [EDIFieldValue("667")]
    AnesthesiaAdministration,

    [EDIFieldValue("668")]
    PriceProtection,

    [EDIFieldValue("669")]
    ClaimIncurred,

    [EDIFieldValue("670")]
    BookEntryDelivery,

    [EDIFieldValue("671")]
    RateAdjustment,

    [EDIFieldValue("672")]
    NextInstallmentDueDate,

    [EDIFieldValue("673")]
    DaylightOverdraftTime,

    [EDIFieldValue("674")]
    PresentmentDate,

    [EDIFieldValue("675")]
    NegotiatedExtensionDate,

    [EDIFieldValue("681")]
    Remittance,

    [EDIFieldValue("682")]
    SecurityRateAdjustment,

    [EDIFieldValue("683")]
    FilingPeriod,

    [EDIFieldValue("684")]
    ReviewPeriodEnd,

    [EDIFieldValue("685")]
    RequestedSettlement,

    [EDIFieldValue("686")]
    LastScreening,

    [EDIFieldValue("687")]
    Confinement,

    [EDIFieldValue("688")]
    Arrested,

    [EDIFieldValue("689")]
    Convicted,

    [EDIFieldValue("690")]
    Interviewed,

    [EDIFieldValue("691")]
    LastVisit,

    [EDIFieldValue("692")]
    Recovery,

    [EDIFieldValue("693")]
    TimeInUS,

    [EDIFieldValue("694")]
    FuturePeriod,

    [EDIFieldValue("695")]
    PreviousPeriod,

    [EDIFieldValue("696")]
    InterestPaidTo,

    [EDIFieldValue("697")]
    DateOfSeizure,

    [EDIFieldValue("699")]
    SetOff,

    [EDIFieldValue("700")]
    OverrideDateforSettlement,

    [EDIFieldValue("701")]
    SettlementDate_FromInterlineSettlementSystem_ISS_only,

    [EDIFieldValue("702")]
    SendingRoadTimeStamp,

    [EDIFieldValue("703")]
    RetransmissionTimeStamp,

    [EDIFieldValue("704")]
    DeliveryAppointmentDateandTime,

    [EDIFieldValue("705")]
    InterestPaidThrough,

    [EDIFieldValue("706")]
    DateMaterialUsageSuspended,

    [EDIFieldValue("707")]
    LastPaymentMade,

    [EDIFieldValue("708")]
    PastDue,

    [EDIFieldValue("709")]
    AnalysisMonthEnding,

    [EDIFieldValue("710")]
    DateOfSpecification,

    [EDIFieldValue("711")]
    DateOfStandard,

    [EDIFieldValue("712")]
    ReturntoWorkPartTime,

    [EDIFieldValue("713")]
    Paid_throughDateforSalaryContinuation,

    [EDIFieldValue("714")]
    Paid_throughDateforVacationPay,

    [EDIFieldValue("715")]
    Paid_throughDateforAccruedSickPay,

    [EDIFieldValue("716")]
    AppraisalOrdered,

    [EDIFieldValue("717")]
    DateOfOperation,

    [EDIFieldValue("718")]
    BestTimetoCall,

    [EDIFieldValue("719")]
    VerbalReportNeeded,

    [EDIFieldValue("720")]
    EstimatedEscrowClosing,

    [EDIFieldValue("721")]
    PermitYear,

    [EDIFieldValue("722")]
    RemodelingCompleted,

    [EDIFieldValue("723")]
    CurrentMonthEnding,

    [EDIFieldValue("724")]
    PreviousMonthEnding,

    [EDIFieldValue("725")]
    CycletoDate,

    [EDIFieldValue("726")]
    YeartoDate,

    [EDIFieldValue("727")]
    OnHold,

    [EDIFieldValue("728")]
    OffHold,

    [EDIFieldValue("729")]
    FacsimileDueBy,

    [EDIFieldValue("730")]
    ReportingCycleDate,

    [EDIFieldValue("731")]
    LastPaidInstallmentDate,

    [EDIFieldValue("732")]
    ClaimsMade,

    [EDIFieldValue("733")]
    DateOfLastPaymentReceived,

    [EDIFieldValue("734")]
    CurtailmentDate,

    [EDIFieldValue("736")]
    PoolSettlement,

    [EDIFieldValue("737")]
    NextInterestChangeDate,

    [EDIFieldValue("738")]
    MostRecentHemoglobinorHematocritorBoth,

    [EDIFieldValue("739")]
    MostRecentSerumCreatine,

    [EDIFieldValue("740")]
    Closed,

    [EDIFieldValue("741")]
    Therapy,

    [EDIFieldValue("742")]
    Implantation,

    [EDIFieldValue("743")]
    Explantation,

    [EDIFieldValue("744")]
    DateBecameAware,

    [EDIFieldValue("745")]
    FirstMarketed,

    [EDIFieldValue("746")]
    LastMarketed,

    [EDIFieldValue("750")]
    ExpectedProblemResolution,

    [EDIFieldValue("751")]
    AlternateProblemResolution,

    [EDIFieldValue("752")]
    FeeCapitalization,

    [EDIFieldValue("753")]
    InterestCapitalization,

    [EDIFieldValue("754")]
    NextPaymentDue,

    [EDIFieldValue("755")]
    ConversiontoRepayment,

    [EDIFieldValue("756")]
    EndOfGrace,

    [EDIFieldValue("757")]
    SchoolRefund,

    [EDIFieldValue("758")]
    SimpleInterestDue,

    [EDIFieldValue("760")]
    Printed,

    [EDIFieldValue("770")]
    BackonMarket,

    [EDIFieldValue("771")]
    Status,

    [EDIFieldValue("773")]
    Off_Market,

    [EDIFieldValue("774")]
    Tour,

    [EDIFieldValue("776")]
    ListingReceived,

    [EDIFieldValue("778")]
    AnticipatedClosing,

    [EDIFieldValue("779")]
    LastPublication,

    [EDIFieldValue("780")]
    SoldBookPublication,

    [EDIFieldValue("781")]
    Occupancy,

    [EDIFieldValue("782")]
    Contingency,

    [EDIFieldValue("783")]
    PercolationTest,

    [EDIFieldValue("784")]
    SepticApproval,

    [EDIFieldValue("785")]
    TitleTransfer,

    [EDIFieldValue("786")]
    OpenHouse,

    [EDIFieldValue("789")]
    Homestead,

    [EDIFieldValue("800")]
    MidpointOfPerformance,

    [EDIFieldValue("801")]
    AcquisitionDate,

    [EDIFieldValue("802")]
    DateOfAction,

    [EDIFieldValue("803")]
    PaidinFull,

    [EDIFieldValue("804")]
    Refinance,

    [EDIFieldValue("805")]
    VoluntaryTermination,

    [EDIFieldValue("806")]
    CustomerOrder,

    [EDIFieldValue("807")]
    Stored,

    [EDIFieldValue("808")]
    Selected,

    [EDIFieldValue("809")]
    Posted,

    [EDIFieldValue("810")]
    DocumentReceived,

    [EDIFieldValue("811")]
    Rebuilt,

    [EDIFieldValue("812")]
    Marriage,

    [EDIFieldValue("813")]
    CustomsEntryDate,

    [EDIFieldValue("814")]
    PaymentDueDate,

    [EDIFieldValue("815")]
    MaturityDate,

    [EDIFieldValue("816")]
    TradeDate,

    [EDIFieldValue("817")]
    GallonsPerMinute_GPM_TestPerformed,

    [EDIFieldValue("818")]
    BritishThermalUnit_BTU_TestPerformed,

    [EDIFieldValue("820")]
    RealEstateTaxYear,

    [EDIFieldValue("821")]
    FinalReconciliationValueEstimateAsOf,

    [EDIFieldValue("822")]
    Map,

    [EDIFieldValue("823")]
    Opinion,

    [EDIFieldValue("824")]
    Version,

    [EDIFieldValue("825")]
    OriginalDueDate,

    [EDIFieldValue("826")]
    IncumbencyPeriod,

    [EDIFieldValue("827")]
    AudienceDeficiencyPeriod,

    [EDIFieldValue("828")]
    AiredDate,

    [EDIFieldValue("830")]
    Schedule,

    [EDIFieldValue("831")]
    PaidThroughDateforMinimumPayment,

    [EDIFieldValue("832")]
    PaidThroughDateforTotalPayment,

    [EDIFieldValue("840")]
    Election,

    [EDIFieldValue("841")]
    EngineeringDataList,

    [EDIFieldValue("842")]
    LastProduction,

    [EDIFieldValue("843")]
    NotBefore,

    [EDIFieldValue("844")]
    NotAfter,

    [EDIFieldValue("845")]
    InitialClaim,

    [EDIFieldValue("846")]
    BenefitsPaid,

    [EDIFieldValue("847")]
    WagesEarned,

    [EDIFieldValue("848")]
    AdjustedStart,

    [EDIFieldValue("849")]
    AdjustedEnd,

    [EDIFieldValue("850")]
    RevisedAdjustedStart,

    [EDIFieldValue("851")]
    RevisedAdjustedEnd,

    [EDIFieldValue("853")]
    FieldTest,

    [EDIFieldValue("854")]
    MortgageNoteDate,

    [EDIFieldValue("855")]
    AlternativeDueDate,

    [EDIFieldValue("856")]
    FirstPaymentChange,

    [EDIFieldValue("857")]
    FirstRateAdjustment,

    [EDIFieldValue("858")]
    AlternateBasePeriod,

    [EDIFieldValue("859")]
    PriorNotice,

    [EDIFieldValue("860")]
    AppointmentEffective,

    [EDIFieldValue("861")]
    AppointmentExpiration,

    [EDIFieldValue("862")]
    CompanyTermination,

    [EDIFieldValue("863")]
    ContinuingEducationRequirement,

    [EDIFieldValue("864")]
    DistributorEffective,

    [EDIFieldValue("865")]
    DistributorTermination,

    [EDIFieldValue("866")]
    Examination,

    [EDIFieldValue("867")]
    IncorporationDissolution,

    [EDIFieldValue("868")]
    LastFollow_up,

    [EDIFieldValue("869")]
    LicenseEffective,

    [EDIFieldValue("870")]
    LicenseExpiration,

    [EDIFieldValue("871")]
    LicenseRenewal,

    [EDIFieldValue("872")]
    LicenseRequested,

    [EDIFieldValue("873")]
    Mailed,

    [EDIFieldValue("874")]
    PaperworkMailed,

    [EDIFieldValue("875")]
    PreviousEmployment,

    [EDIFieldValue("876")]
    PreviousEmploymentEnd,

    [EDIFieldValue("877")]
    PreviousEmploymentStart,

    [EDIFieldValue("878")]
    PreviousResidence,

    [EDIFieldValue("879")]
    PreviousResidenceEnd,

    [EDIFieldValue("880")]
    PreviousResidenceStart,

    [EDIFieldValue("881")]
    Request,

    [EDIFieldValue("882")]
    ResidentLicenseEffective,

    [EDIFieldValue("883")]
    ResidentLicenseExpiration,

    [EDIFieldValue("884")]
    StateTermination,

    [EDIFieldValue("885")]
    TexasLineTermination,

    [EDIFieldValue("900")]
    Acceleration,

    [EDIFieldValue("901")]
    AdjustedContestability,

    [EDIFieldValue("903")]
    ApplicationEntry,

    [EDIFieldValue("904")]
    ApprovalOffer,

    [EDIFieldValue("905")]
    AutomaticPremiumLoan,

    [EDIFieldValue("906")]
    Collection,

    [EDIFieldValue("907")]
    ConfinementEnd,

    [EDIFieldValue("908")]
    ConfinementStart,

    [EDIFieldValue("909")]
    Contestability,

    [EDIFieldValue("910")]
    FlatExtraEnd,

    [EDIFieldValue("911")]
    LastActivity,

    [EDIFieldValue("912")]
    LastChange,

    [EDIFieldValue("913")]
    LastEpisode,

    [EDIFieldValue("914")]
    LastMeal,

    [EDIFieldValue("915")]
    Loan,

    [EDIFieldValue("916")]
    ApplicationStatus,

    [EDIFieldValue("917")]
    Maturity,

    [EDIFieldValue("918")]
    MedicalInformationSignature,

    [EDIFieldValue("919")]
    MedicalInformationSystem,

    [EDIFieldValue("920")]
    Note,

    [EDIFieldValue("921")]
    OfferExpiration,

    [EDIFieldValue("922")]
    OriginalReceipt,

    [EDIFieldValue("923")]
    Placement,

    [EDIFieldValue("924")]
    PlacementPeriodExpiration,

    [EDIFieldValue("925")]
    Processing,

    [EDIFieldValue("926")]
    Recapture,

    [EDIFieldValue("927")]
    Re_entry,

    [EDIFieldValue("928")]
    Reissue,

    [EDIFieldValue("929")]
    Reinstatement_929,

    [EDIFieldValue("930")]
    Requalification,

    [EDIFieldValue("931")]
    ReinsuranceEffective,

    [EDIFieldValue("932")]
    ReservationOfFacility,

    [EDIFieldValue("933")]
    SettlementStatus,

    [EDIFieldValue("934")]
    TableRatingEnd,

    [EDIFieldValue("935")]
    TerminationOfFacility,

    [EDIFieldValue("936")]
    Treatment,

    [EDIFieldValue("937")]
    DepartmentOfLaborWageDeterminationDate,

    [EDIFieldValue("938")]
    Order,

    [EDIFieldValue("939")]
    Resolved,

    [EDIFieldValue("940")]
    ExecutionDate,

    [EDIFieldValue("941")]
    CapitationPeriodStart,

    [EDIFieldValue("942")]
    CapitationPeriodEnd,

    [EDIFieldValue("943")]
    LastDateforaGovernmentAgencyToFileAClaim,

    [EDIFieldValue("944")]
    AdjustmentPeriod,

    [EDIFieldValue("945")]
    Activity,

    [EDIFieldValue("946")]
    MailBy,

    [EDIFieldValue("947")]
    Preparation,

    [EDIFieldValue("948")]
    PaymentInitiated,

    [EDIFieldValue("949")]
    PaymentEffective,

    [EDIFieldValue("950")]
    Application,

    [EDIFieldValue("951")]
    Reclassification,

    [EDIFieldValue("952")]
    Reclassification_ExitDate,

    [EDIFieldValue("953")]
    Post_Reclassification,

    [EDIFieldValue("954")]
    Post_Reclassification_FirstReportCard,

    [EDIFieldValue("955")]
    Post_Reclassification_FirstSemi_annual,

    [EDIFieldValue("956")]
    Post_Reclassification_SecondSemi_annual,

    [EDIFieldValue("957")]
    Post_Reclassification_EndOfSecondYear,

    [EDIFieldValue("960")]
    AdjustedDeathBenefit,

    [EDIFieldValue("961")]
    Anniversary,

    [EDIFieldValue("962")]
    Annuitization,

    [EDIFieldValue("963")]
    AnnuityCommencementDate,

    [EDIFieldValue("964")]
    Bill,

    [EDIFieldValue("965")]
    CalendarAnniversary,

    [EDIFieldValue("966")]
    ContractMailed,

    [EDIFieldValue("967")]
    EarlyWithdrawal,

    [EDIFieldValue("968")]
    FiscalAnniversary,

    [EDIFieldValue("969")]
    Income,

    [EDIFieldValue("970")]
    InitialPremium,

    [EDIFieldValue("971")]
    InitialPremiumEffective,

    [EDIFieldValue("972")]
    LastPremiumEffective,

    [EDIFieldValue("973")]
    MinimumRequiredDistribution,

    [EDIFieldValue("974")]
    NextAnniversary,

    [EDIFieldValue("975")]
    Notice,

    [EDIFieldValue("976")]
    NotificationOfDeath,

    [EDIFieldValue("977")]
    PartialAnnuitization,

    [EDIFieldValue("978")]
    PlanAnniversary,

    [EDIFieldValue("979")]
    PolicySurrender,

    [EDIFieldValue("980")]
    PriorContractAnniversary,

    [EDIFieldValue("981")]
    PriorContractIssue,

    [EDIFieldValue("982")]
    SignatureReceived,

    [EDIFieldValue("983")]
    Tax,

    [EDIFieldValue("984")]
    BenefitPeriod,

    [EDIFieldValue("985")]
    MonthtoDate,

    [EDIFieldValue("986")]
    SemiannualEnding,

    [EDIFieldValue("987")]
    Surrender,

    [EDIFieldValue("988")]
    PlanOfTreatmentPeriod,

    [EDIFieldValue("989")]
    PriorHospitalizationDates_RelatedtoCurrentServices,

    [EDIFieldValue("992")]
    DateRequested,

    [EDIFieldValue("993")]
    RequestforQuotation,

    [EDIFieldValue("994")]
    Quote,

    [EDIFieldValue("995")]
    RecordedDate,

    [EDIFieldValue("996")]
    RequiredDelivery,

    [EDIFieldValue("997")]
    QuotetobeReceivedBy,

    [EDIFieldValue("998")]
    ContinuationOfPayStartDate,

    [EDIFieldValue("999")]
    DocumentDate,

    [EDIFieldValue("AA1")]
    EstimatedPointOfArrival,

    [EDIFieldValue("AA2")]
    EstimatedPointOfDischarge,

    [EDIFieldValue("AA3")]
    CancelAfter_ExCountry,

    [EDIFieldValue("AA4")]
    CancelAfter_ExFactory,

    [EDIFieldValue("AA5")]
    DoNotShipBefore_ExCountry,

    [EDIFieldValue("AA6")]
    DoNotShipBefore_ExFactory,

    [EDIFieldValue("AA7")]
    FinalScheduledPayment,

    [EDIFieldValue("AA8")]
    ActualDischarge,

    [EDIFieldValue("AA9")]
    AddressPeriod,

    [EDIFieldValue("AAA")]
    ArrivalinCountry,

    [EDIFieldValue("AAB")]
    Citation,

    [EDIFieldValue("AAD")]
    Crime,

    [EDIFieldValue("AAE")]
    Discharge_Planned,

    [EDIFieldValue("AAF")]
    Draft,

    [EDIFieldValue("AAG")]
    DueDate,

    [EDIFieldValue("AAH")]
    Event,

    [EDIFieldValue("AAI")]
    FirstInvolvement,

    [EDIFieldValue("AAJ")]
    GuaranteePeriod,

    [EDIFieldValue("AAK")]
    IncomeIncreasePeriod,

    [EDIFieldValue("AAL")]
    InstallmentDate,

    [EDIFieldValue("AAM")]
    LastCivilianFlight,

    [EDIFieldValue("AAN")]
    LastFlight,

    [EDIFieldValue("AAO")]
    LastInsuranceMedical,

    [EDIFieldValue("AAP")]
    LastMilitaryFlight,

    [EDIFieldValue("AAQ")]
    LastPhysical,

    [EDIFieldValue("AAR")]
    License,

    [EDIFieldValue("AAS")]
    MedicalCertificate,

    [EDIFieldValue("AAT")]
    Medication,

    [EDIFieldValue("AAU")]
    NetWorthDate,

    [EDIFieldValue("AAV")]
    NextActivity,

    [EDIFieldValue("AAW")]
    OwnershipChange,

    [EDIFieldValue("AAX")]
    OwnershipPeriod,

    [EDIFieldValue("AAY")]
    RateDate,

    [EDIFieldValue("AAZ")]
    RequestedContract,

    [EDIFieldValue("AB1")]
    RequestedOffer,

    [EDIFieldValue("AB2")]
    SalesPeriod,

    [EDIFieldValue("AB3")]
    TaxYear,

    [EDIFieldValue("AB4")]
    TimePeriod,

    [EDIFieldValue("AB5")]
    Travel,

    [EDIFieldValue("AB6")]
    TreatmentEnd,

    [EDIFieldValue("AB7")]
    TreatmentStart,

    [EDIFieldValue("AB8")]
    Trust,

    [EDIFieldValue("AB9")]
    WorstTimetoCall,

    [EDIFieldValue("ABA")]
    Registration,

    [EDIFieldValue("ABB")]
    Revoked,

    [EDIFieldValue("ABC")]
    EstimatedDateOfBirth,

    [EDIFieldValue("ABD")]
    LastAnnualReport,

    [EDIFieldValue("ABE")]
    LegalActionStarted,

    [EDIFieldValue("ABG")]
    PaymentPeriod,

    [EDIFieldValue("ABH")]
    ProfitPeriod,

    [EDIFieldValue("ABI")]
    Registered,

    [EDIFieldValue("ABK")]
    Consolidated,

    [EDIFieldValue("ABL")]
    BoardOfDirectorsNotAuthorizedAsOf,

    [EDIFieldValue("ABM")]
    BoardOfDirectorsIncompleteAsOf,

    [EDIFieldValue("ABN")]
    ManagerNotRegisteredAsOf,

    [EDIFieldValue("ABO")]
    CitizenshipChange,

    [EDIFieldValue("ABP")]
    Participation,

    [EDIFieldValue("ABQ")]
    Capitalization,

    [EDIFieldValue("ABR")]
    RegistrationOfBoardOfDirectors,

    [EDIFieldValue("ABS")]
    CeasedOperations,

    [EDIFieldValue("ABT")]
    Satisfied,

    [EDIFieldValue("ABU")]
    TermsMet,

    [EDIFieldValue("ABV")]
    AssetDocumentationExpiration,

    [EDIFieldValue("ABW")]
    CreditDocumentationExpiration,

    [EDIFieldValue("ABX")]
    IncomeDocumentationExpiration,

    [EDIFieldValue("ABY")]
    ProductHeldUntil,

    [EDIFieldValue("ACA")]
    ImmigrationDate,

    [EDIFieldValue("ACB")]
    EstimatedImmigrationDate,

    [EDIFieldValue("ACK")]
    Acknowledgment,

    [EDIFieldValue("ADB")]
    BusinessControlChange,

    [EDIFieldValue("ADC")]
    CourtRegistration,

    [EDIFieldValue("ADD")]
    AnnualReportDue,

    [EDIFieldValue("ADL")]
    AssetandLiabilitySchedule,

    [EDIFieldValue("ADM")]
    AnnualReportMailed,

    [EDIFieldValue("ADR")]
    AnnualReportFiled,

    [EDIFieldValue("ARD")]
    AnnualReportDelinquency,

    [EDIFieldValue("CAD")]
    ChangedAccountingDate,

    [EDIFieldValue("CCR")]
    CustomsCargoRelease,

    [EDIFieldValue("CDT")]
    MaintenanceComment,

    [EDIFieldValue("CEA")]
    Formation,

    [EDIFieldValue("CEB")]
    Continuance,

    [EDIFieldValue("CEC")]
    Merger,

    [EDIFieldValue("CED")]
    YearDue,

    [EDIFieldValue("CEE")]
    NextAnnualMeeting,

    [EDIFieldValue("CEF")]
    EndOfLastFiscalYear,

    [EDIFieldValue("CEH")]
    YearBeginning,

    [EDIFieldValue("CEJ")]
    StartedDoingBusiness,

    [EDIFieldValue("CEK")]
    SwornandSubscribed,

    [EDIFieldValue("CEL")]
    CalendarYear,

    [EDIFieldValue("CEM")]
    Asset,

    [EDIFieldValue("CEN")]
    Inactivity,

    [EDIFieldValue("CEO")]
    HighCapitalYear,

    [EDIFieldValue("CLO")]
    ClosingDateOfFirstBalanceSheet,

    [EDIFieldValue("CLU")]
    ClosedUntil,

    [EDIFieldValue("COM")]
    Compliance,

    [EDIFieldValue("CON")]
    ConvertedintoHoldingCompany,

    [EDIFieldValue("CUR")]
    CurrentList,

    [EDIFieldValue("DDO")]
    Declaration,

    [EDIFieldValue("DEE")]
    DeedNotAvailable,

    [EDIFieldValue("DET")]
    DetrimentalInformationReceived,

    [EDIFieldValue("DFF")]
    Deferral,

    [EDIFieldValue("DFS")]
    DepartureFromSpecification,

    [EDIFieldValue("DIS")]
    Disposition,

    [EDIFieldValue("DOI")]
    DeliveryOrderIssued,

    [EDIFieldValue("DSP")]
    Disposal,

    [EDIFieldValue("ECD")]
    EstimatedConstructionDate,

    [EDIFieldValue("ECF")]
    EstimatedCompletion_FirstPriorMonth,

    [EDIFieldValue("ECS")]
    EstimatedCompletion_SecondPriorMonth,

    [EDIFieldValue("ECT")]
    EstimatedCompletion_ThirdPriorMonth,

    [EDIFieldValue("EPP")]
    EstimatePreparation,

    [EDIFieldValue("ESC")]
    EstimateComment,

    [EDIFieldValue("ESF")]
    EstimatedStart_FirstPriorMonth,

    [EDIFieldValue("ESS")]
    EstimatedStart_SecondPriorMonth,

    [EDIFieldValue("EST")]
    EstimatedStart_ThirdPriorMonth,

    [EDIFieldValue("ETP")]
    EarliestFilingPeriod,

    [EDIFieldValue("EXO")]
    Exposure,

    [EDIFieldValue("EXP")]
    Export,

    [EDIFieldValue("FFI")]
    FinancialInformation,

    [EDIFieldValue("GRD")]
    Graduated,

    [EDIFieldValue("ICF")]
    ConvertedtoElectronicDate,

    [EDIFieldValue("IDG")]
    InsolvencyDischargeGranted,

    [EDIFieldValue("III")]
    Incorporation,

    [EDIFieldValue("IMP")]
    Import,

    [EDIFieldValue("INC")]
    Incident,

    [EDIFieldValue("INT")]
    InactiveUntil,

    [EDIFieldValue("KEV")]
    KeyEventFiscalYear,

    [EDIFieldValue("KEW")]
    KeyEventCalendarYear,

    [EDIFieldValue("LAS")]
    LastCheckforBalanceSheetUpdate,

    [EDIFieldValue("LCC")]
    LastCapitalChange,

    [EDIFieldValue("LEA")]
    LetterOfAgreement,

    [EDIFieldValue("LEL")]
    LetterOfLiability,

    [EDIFieldValue("LIQ")]
    Liquidation,

    [EDIFieldValue("LLP")]
    LowPeriod,

    [EDIFieldValue("LOG")]
    EquipmentLogEntry,

    [EDIFieldValue("LPC")]
    ListPriceChange,

    [EDIFieldValue("LSC")]
    LegalStructureChange,

    [EDIFieldValue("LTP")]
    LatestFilingPeriod,

    [EDIFieldValue("MRR")]
    MeterReading,

    [EDIFieldValue("MSD")]
    LatestMaterialSafetyDataSheetDate,

    [EDIFieldValue("NAM")]
    PresentName,

    [EDIFieldValue("NFD")]
    NegotiatedFinish,

    [EDIFieldValue("NRG")]
    NotRegistered,

    [EDIFieldValue("NSD")]
    NegotiatedStart,

    [EDIFieldValue("ORG")]
    OriginalList,

    [EDIFieldValue("PBC")]
    PresentControl,

    [EDIFieldValue("PDV")]
    PrivilegeDetailsVerification,

    [EDIFieldValue("PLS")]
    PresentLegalStructure,

    [EDIFieldValue("PPP")]
    PeakPeriod,

    [EDIFieldValue("PRD")]
    PreviouslyReportedDateOfBirth,

    [EDIFieldValue("PRR")]
    PresentedtoReceivers,

    [EDIFieldValue("PTD")]
    PaidToDate,

    [EDIFieldValue("RAP")]
    ReceiverAppointed,

    [EDIFieldValue("RES")]
    Resigned,

    [EDIFieldValue("RFD")]
    RequestedFinish,

    [EDIFieldValue("RFF")]
    RecoveryFinish,

    [EDIFieldValue("RFO")]
    ReferredFrom,

    [EDIFieldValue("RNT")]
    RentSurvey,

    [EDIFieldValue("RRM")]
    ReceivedintheMail,

    [EDIFieldValue("RRT")]
    Revocation,

    [EDIFieldValue("RSD")]
    RequestedStart,

    [EDIFieldValue("RSS")]
    RecoveryStart,

    [EDIFieldValue("RTO")]
    ReferredTo,

    [EDIFieldValue("SCV")]
    SocialSecurityClaimsVerification,

    [EDIFieldValue("SDD")]
    SoleDirectorshipDate,

    [EDIFieldValue("STN")]
    Transition,

    [EDIFieldValue("TSR")]
    TradeStyleRegistered,

    [EDIFieldValue("TSS")]
    TrialStarted,

    [EDIFieldValue("TST")]
    TrialSet,

    [EDIFieldValue("VAT")]
    ValueAddedTax_VAT_ClaimsVerification,

    [EDIFieldValue("VLU")]
    ValidUntil,

    [EDIFieldValue("W01")]
    SampleCollected,

    [EDIFieldValue("W02")]
    StatusChange,

    [EDIFieldValue("W03")]
    ConstructionStart,

    [EDIFieldValue("W05")]
    Recompletion,

    [EDIFieldValue("W06")]
    LastLogged,

    [EDIFieldValue("W07")]
    WellLogRun,

    [EDIFieldValue("W08")]
    SurfaceCasingAuthorityApproval,

    [EDIFieldValue("W09")]
    ReachedTotalDepth,

    [EDIFieldValue("W10")]
    SpacingOrderUnitAssigned,

    [EDIFieldValue("W11")]
    RigArrival,

    [EDIFieldValue("W12")]
    LocationExceptionOrderNumberAssigned,

    [EDIFieldValue("W13")]
    SidetrackedWellbore,

    [EDIFieldValue("WAY")]
    Waybill,

    [EDIFieldValue("YXX")]
    ProgrammedFiscalYear,

    [EDIFieldValue("YXY")]
    ProgrammedCalendarYear,

    [EDIFieldValue("ZZZ")]
    MutuallyDefined,

    [EDIFieldValue("340")]
    ConsolidatedOmnibusBudgetReconciliationAct,

    [EDIFieldValue("341")]
    ConsolidatedOmnibusBudgetReconciliationAct_COBRA
  }
}