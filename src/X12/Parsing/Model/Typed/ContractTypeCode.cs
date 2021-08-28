﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum ContractTypeCode
  {
    [EDIFieldValue("01")]
    DiagnosisRelatedGroup_DRG,

    [EDIFieldValue("02")]
    PerDiem,

    [EDIFieldValue("03")]
    VariablePerDiem,

    [EDIFieldValue("04")]
    Flat,

    [EDIFieldValue("05")]
    Capitated,

    [EDIFieldValue("06")]
    Percent,

    [EDIFieldValue("09")]
    Other,

    [EDIFieldValue("AB")]
    NegotiatedGrowingEquityMortgage_GEM,

    [EDIFieldValue("AC")]
    AnticipatedContract,

    [EDIFieldValue("AD")]
    FederalHousingAuthorityAdjustableRateMortgage,

    [EDIFieldValue("AE")]
    FederalHousingAuthorityVeteransAffairsFixedRateMortgage,

    [EDIFieldValue("AF")]
    ConventionalSecondMortgages,

    [EDIFieldValue("AG")]
    ConventionalFixedRateMortgages,

    [EDIFieldValue("AH")]
    FederalHousingAuthorityVeteransAffairsGraduatedPaymentMortgage,

    [EDIFieldValue("AI")]
    NegotiatedConventional_GraduatedPayment_Or_StepRateMortgage,

    [EDIFieldValue("AJ")]
    ConventionalAdjustableRateMortgage,

    [EDIFieldValue("CA")]
    CostPlusIncentiveFee_WithPerformanceIncentives,

    [EDIFieldValue("CB")]
    CostPlusIncentiveFee_WithoutPerformanceIncentives,

    [EDIFieldValue("CH")]
    CostSharing,

    [EDIFieldValue("CP")]
    CostPlus,

    [EDIFieldValue("CS")]
    Cost,

    [EDIFieldValue("CW")]
    CostPlusAwardFee,

    [EDIFieldValue("CX")]
    CostPlusFixedFee,

    [EDIFieldValue("CY")]
    CostPlusIncentiveFee,

    [EDIFieldValue("DI")]
    Distributor,

    [EDIFieldValue("EA")]
    ExclusiveAgency,

    [EDIFieldValue("ER")]
    ExclusiveRight,

    [EDIFieldValue("FA")]
    FirmorActualContract,

    [EDIFieldValue("FB")]
    FixedPriceIncentiveFirmTarget_WithPerformanceIncentive,

    [EDIFieldValue("FC")]
    FixedPriceIncentiveFirmTarget_WithoutPerformanceIncentive,

    [EDIFieldValue("FD")]
    FixedPriceRedetermination,

    [EDIFieldValue("FE")]
    FixedPricewithEscalation,

    [EDIFieldValue("FF")]
    FixedPriceIncentiveSuccessiveTarget_WithPerformanceIncentive,

    [EDIFieldValue("FG")]
    FixedPriceIncentiveSuccessiveTarget_WithoutPerformanceIncentive,

    [EDIFieldValue("FH")]
    FixedPriceAwardFee,

    [EDIFieldValue("FI")]
    FixedPriceIncentive,

    [EDIFieldValue("FJ")]
    FixedPriceLevelofEffort,

    [EDIFieldValue("FK")]
    NoCost,

    [EDIFieldValue("FL")]
    FlatAmount,

    [EDIFieldValue("FM")]
    RetroactiveFixedPriceRedetermination,

    [EDIFieldValue("FR")]
    FirmFixedPrice,

    [EDIFieldValue("FX")]
    FixedPricewithEconomicPriceAdjustment,

    [EDIFieldValue("LA")]
    Labor,

    [EDIFieldValue("LE")]
    LevelofEffort,

    [EDIFieldValue("LH")]
    LaborHours,

    [EDIFieldValue("OC")]
    OtherContractType,

    [EDIFieldValue("PR")]
    ProspectReservation,

    [EDIFieldValue("SP")]
    SamePercentageasFilmRentalEarned_SPFRE,

    [EDIFieldValue("TM")]
    TimeandMaterials,

    [EDIFieldValue("ZZ")]
    MutuallyDefined
  }
}