﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum UnitOrBasisOfMeasurementCode
  {
    [EDIFieldValue("01")]
    ActualPounds,

    [EDIFieldValue("02")]
    StatuteMile,

    [EDIFieldValue("03")]
    Seconds,

    [EDIFieldValue("04")]
    SmallSpray,

    [EDIFieldValue("05")]
    Lifts,

    [EDIFieldValue("06")]
    Digits,

    [EDIFieldValue("07")]
    Strand,

    [EDIFieldValue("08")]
    HeatLots,

    [EDIFieldValue("09")]
    Tire,

    [EDIFieldValue("10")]
    Group,

    [EDIFieldValue("11")]
    Outfit,

    [EDIFieldValue("12")]
    Packet,

    [EDIFieldValue("13")]
    Ration,

    [EDIFieldValue("14")]
    Shot,

    [EDIFieldValue("15")]
    Stick,

    [EDIFieldValue("16")]
    _115KilogramDrum,

    [EDIFieldValue("17")]
    _100PoundDrum,

    [EDIFieldValue("18")]
    _55GallonDrum,

    [EDIFieldValue("19")]
    TankTruck,

    [EDIFieldValue("1A")]
    CarMile,

    [EDIFieldValue("1B")]
    CarCount,

    [EDIFieldValue("1C")]
    LocomotiveCount,

    [EDIFieldValue("1D")]
    CabooseCount,

    [EDIFieldValue("1E")]
    EmptyCar,

    [EDIFieldValue("1F")]
    TrainMile,

    [EDIFieldValue("1G")]
    FuelUsage_Gallons,

    [EDIFieldValue("1H")]
    CabooseMile,

    [EDIFieldValue("1I")]
    FixedRate,

    [EDIFieldValue("1J")]
    TonMiles,

    [EDIFieldValue("1K")]
    LocomotiveMile,

    [EDIFieldValue("1L")]
    TotalCarCount,

    [EDIFieldValue("1M")]
    TotalCarMile,

    [EDIFieldValue("1N")]
    Count,

    [EDIFieldValue("1O")]
    Season,

    [EDIFieldValue("1P")]
    TankCar,

    [EDIFieldValue("1Q")]
    Frames,

    [EDIFieldValue("1R")]
    Transactions,

    [EDIFieldValue("1X")]
    QuarterMile,

    [EDIFieldValue("20")]
    _20FootContainer,

    [EDIFieldValue("21")]
    _40FootContainer,

    [EDIFieldValue("22")]
    DeciliterperGram,

    [EDIFieldValue("23")]
    GramsPerCubicCentimeter,

    [EDIFieldValue("24")]
    TheoreticalPounds,

    [EDIFieldValue("25")]
    GramsPerSquareCentimeter,

    [EDIFieldValue("26")]
    ActualTons,

    [EDIFieldValue("27")]
    TheoreticalTons,

    [EDIFieldValue("28")]
    KilogramsPerSquareMeter,

    [EDIFieldValue("29")]
    PoundsPer1000SquareFeet,

    [EDIFieldValue("2A")]
    RadiansPerSecond,

    [EDIFieldValue("2B")]
    RadiansPerSecondSquared,

    [EDIFieldValue("2C")]
    Roentgen,

    [EDIFieldValue("2F")]
    VoltsPerMeter,

    [EDIFieldValue("2G")]
    Volts_AlternatingCurrent,

    [EDIFieldValue("2H")]
    Volts_DirectCurrent,

    [EDIFieldValue("2I")]
    BritishThermalUnitsPerHour,

    [EDIFieldValue("2J")]
    CubicCentimetersPerSecond,

    [EDIFieldValue("2K")]
    CubicFeetPerHour,

    [EDIFieldValue("2L")]
    CubicFeetPerMinute,

    [EDIFieldValue("2M")]
    CentimetersPerSecond,

    [EDIFieldValue("2N")]
    Decibels,

    [EDIFieldValue("2P")]
    Kilobyte,

    [EDIFieldValue("2Q")]
    Kilobecquerel,

    [EDIFieldValue("2R")]
    Kilocurie,

    [EDIFieldValue("2U")]
    Megagram,

    [EDIFieldValue("2V")]
    MegagramsPerHour,

    [EDIFieldValue("2W")]
    Bin,

    [EDIFieldValue("2X")]
    MetersPerMinute,

    [EDIFieldValue("2Y")]
    Milliroentgen,

    [EDIFieldValue("2Z")]
    Millivolts,

    [EDIFieldValue("30")]
    HorsepowerDaysPerAirDryMetricTons,

    [EDIFieldValue("31")]
    Catchweight,

    [EDIFieldValue("32")]
    KilogramsPerAirDryMetricTons,

    [EDIFieldValue("33")]
    KilopascalSquareMetersPerGram,

    [EDIFieldValue("34")]
    KilopascalsPerMillimeter,

    [EDIFieldValue("35")]
    MillilitersPerSquareCentimeterSecond,

    [EDIFieldValue("36")]
    CubicFeetPerMinutePerSquareFoot,

    [EDIFieldValue("37")]
    OuncesPerSquareFoot,

    [EDIFieldValue("38")]
    OuncesPerSquareFootPerOneHundredthOfAnInch,

    [EDIFieldValue("39")]
    BasisPoints,

    [EDIFieldValue("3B")]
    Megajoule,

    [EDIFieldValue("3C")]
    Manmonth,

    [EDIFieldValue("3E")]
    PoundsPerPoundofProduct,

    [EDIFieldValue("3F")]
    KilogramsPerLiterOfProduct,

    [EDIFieldValue("3G")]
    PoundsPerPieceOfProduct,

    [EDIFieldValue("3H")]
    KilogramsPerKilogramOfProduct,

    [EDIFieldValue("3I")]
    KilogramsPerPieceOfProduct,

    [EDIFieldValue("40")]
    MilliliterPerSecond,

    [EDIFieldValue("41")]
    MilliliterPerMinute,

    [EDIFieldValue("43")]
    SuperBulkBag,

    [EDIFieldValue("44")]
    _500KilogramBulkBag,

    [EDIFieldValue("45")]
    _300KilogramBulkBag,

    [EDIFieldValue("46")]
    _25KilogramBulkBag,

    [EDIFieldValue("47")]
    _50PoundBag,

    [EDIFieldValue("48")]
    BulkCarLoad,

    [EDIFieldValue("4A")]
    Bobbin,

    [EDIFieldValue("4B")]
    Cap,

    [EDIFieldValue("4C")]
    Centistokes,

    [EDIFieldValue("4D")]
    Curie,

    [EDIFieldValue("4E")]
    _20Pack,

    [EDIFieldValue("4F")]
    _100Pack,

    [EDIFieldValue("4G")]
    Microliter,

    [EDIFieldValue("4H")]
    Micrometer,

    [EDIFieldValue("4I")]
    MetersPerSecond,

    [EDIFieldValue("4J")]
    MetersPerSecondPerSecond,

    [EDIFieldValue("4K")]
    Milliamperes,

    [EDIFieldValue("4L")]
    Megabyte,

    [EDIFieldValue("4M")]
    MilligramsPerHour,

    [EDIFieldValue("4N")]
    Megabecquerel,

    [EDIFieldValue("4O")]
    Microfarad,

    [EDIFieldValue("4P")]
    NewtonsPerMeter,

    [EDIFieldValue("4Q")]
    OunceInch,

    [EDIFieldValue("4R")]
    OunceFoot,

    [EDIFieldValue("4S")]
    Pascal,

    [EDIFieldValue("4T")]
    Picofarad,

    [EDIFieldValue("4U")]
    PoundsPerHour,

    [EDIFieldValue("4V")]
    CubicMeterPerHour,

    [EDIFieldValue("4W")]
    TonPerHour,

    [EDIFieldValue("4X")]
    KiloliterPerHour,

    [EDIFieldValue("50")]
    ActualKilograms,

    [EDIFieldValue("51")]
    ActualTonnes,

    [EDIFieldValue("52")]
    Credits,

    [EDIFieldValue("53")]
    TheoreticalKilograms,

    [EDIFieldValue("54")]
    TheoreticalTonnes,

    [EDIFieldValue("56")]
    Sitas,

    [EDIFieldValue("57")]
    Mesh,

    [EDIFieldValue("58")]
    NetKilograms,

    [EDIFieldValue("59")]
    PartsPerMillion,

    [EDIFieldValue("5A")]
    BarrelsPerMinute,

    [EDIFieldValue("5B")]
    Batch,

    [EDIFieldValue("5C")]
    GallonsPerThousand,

    [EDIFieldValue("5E")]
    MMSCFPerDay,

    [EDIFieldValue("5F")]
    PoundsPerThousand,

    [EDIFieldValue("5G")]
    Pump,

    [EDIFieldValue("5H")]
    Stage,

    [EDIFieldValue("5I")]
    StandardCubicFoot,

    [EDIFieldValue("5J")]
    HydraulicHorsePower,

    [EDIFieldValue("5K")]
    CountPerMinute,

    [EDIFieldValue("5P")]
    SeismicLevel,

    [EDIFieldValue("5Q")]
    SeismicLine,

    [EDIFieldValue("60")]
    PercentWeight,

    [EDIFieldValue("61")]
    PartsPerBillion,

    [EDIFieldValue("62")]
    PercentPer1000Hours,

    [EDIFieldValue("63")]
    FailureRateInTime,

    [EDIFieldValue("64")]
    PoundsPerSquareInchGauge,

    [EDIFieldValue("65")]
    Coulomb,

    [EDIFieldValue("66")]
    Oersteds,

    [EDIFieldValue("67")]
    Siemens,

    [EDIFieldValue("68")]
    Ampere,

    [EDIFieldValue("69")]
    TestSpecificScale,

    [EDIFieldValue("70")]
    Volt,

    [EDIFieldValue("71")]
    VoltAmperePerPound,

    [EDIFieldValue("72")]
    WattsPerPound,

    [EDIFieldValue("73")]
    AmpereTurnPerCentimeter,

    [EDIFieldValue("74")]
    MilliPascals,

    [EDIFieldValue("76")]
    Gauss,

    [EDIFieldValue("77")]
    Mil,

    [EDIFieldValue("78")]
    Kilogauss,

    [EDIFieldValue("79")]
    ElectronVolt,

    [EDIFieldValue("80")]
    PoundsPerSquareInchAbsolute,

    [EDIFieldValue("81")]
    Henry,

    [EDIFieldValue("82")]
    Ohm,

    [EDIFieldValue("83")]
    Farad,

    [EDIFieldValue("84")]
    KiloPoundsPerSquareInch_KSI,

    [EDIFieldValue("85")]
    FootPounds,

    [EDIFieldValue("86")]
    Joules,

    [EDIFieldValue("87")]
    PoundsPerCubicFoot,

    [EDIFieldValue("89")]
    Poise,

    [EDIFieldValue("8C")]
    Cord,

    [EDIFieldValue("8D")]
    Duty,

    [EDIFieldValue("8P")]
    Project,

    [EDIFieldValue("8R")]
    Program,

    [EDIFieldValue("8S")]
    Session,

    [EDIFieldValue("8U")]
    SquareKilometer,

    [EDIFieldValue("90")]
    SayboldUniversalSecond,

    [EDIFieldValue("91")]
    Stokes,

    [EDIFieldValue("92")]
    CaloriesPerCubicCentimeter,

    [EDIFieldValue("93")]
    CaloriesPerGram,

    [EDIFieldValue("94")]
    CurlUnits,

    [EDIFieldValue("95")]
    _20kGallonTankcar,

    [EDIFieldValue("96")]
    _10kGallonTankcar,

    [EDIFieldValue("97")]
    _10KilogramDrum,

    [EDIFieldValue("98")]
    _15KilogramDrum,

    [EDIFieldValue("99")]
    Watt,

    [EDIFieldValue("A8")]
    DollarsPerHours,

    [EDIFieldValue("AA")]
    Ball,

    [EDIFieldValue("AB")]
    BulkPack,

    [EDIFieldValue("AC")]
    Acre,

    [EDIFieldValue("AD")]
    Bytes,

    [EDIFieldValue("AE")]
    AmperesPerMeter,

    [EDIFieldValue("AF")]
    Centigram,

    [EDIFieldValue("AG")]
    Angstrom,

    [EDIFieldValue("AH")]
    AdditionalMinutes,

    [EDIFieldValue("AI")]
    AverageMinutesPerCall,

    [EDIFieldValue("AJ")]
    Cop,

    [EDIFieldValue("AK")]
    Fathom,

    [EDIFieldValue("AL")]
    AccessLines,

    [EDIFieldValue("AM")]
    Ampoule,

    [EDIFieldValue("AN")]
    MinutesOrMessages,

    [EDIFieldValue("AO")]
    Ampereturn,

    [EDIFieldValue("AP")]
    AluminumPoundsOnly,

    [EDIFieldValue("AQ")]
    AntihemophilicFactorUnits,

    [EDIFieldValue("AR")]
    Suppository,

    [EDIFieldValue("AS")]
    Assortment,

    [EDIFieldValue("AT")]
    Atmosphere,

    [EDIFieldValue("AU")]
    OcularInsertSystem,

    [EDIFieldValue("AV")]
    Capsule,

    [EDIFieldValue("AW")]
    PowderFilledVials,

    [EDIFieldValue("AX")]
    Twenty,

    [EDIFieldValue("AY")]
    Assembly,

    [EDIFieldValue("AZ")]
    BritishThermalUnitsPerPound,

    [EDIFieldValue("B0")]
    BritishThermalUnitsPerCubicFoot,

    [EDIFieldValue("B1")]
    BarrelsPerDay,

    [EDIFieldValue("B2")]
    Bunks,

    [EDIFieldValue("B3")]
    BattingPound,

    [EDIFieldValue("B4")]
    BarrelImperial,

    [EDIFieldValue("B5")]
    Billet,

    [EDIFieldValue("B6")]
    Bun,

    [EDIFieldValue("B7")]
    Cycles,

    [EDIFieldValue("B8")]
    Board,

    [EDIFieldValue("B9")]
    Batt,

    [EDIFieldValue("BA")]
    Bale,

    [EDIFieldValue("BB")]
    BaseBox,

    [EDIFieldValue("BC")]
    Bucket,

    [EDIFieldValue("BD")]
    Bundle,

    [EDIFieldValue("BE")]
    Beam,

    [EDIFieldValue("BF")]
    BoardFeet,

    [EDIFieldValue("BG")]
    Bag,

    [EDIFieldValue("BH")]
    Brush,

    [EDIFieldValue("BI")]
    Bar,

    [EDIFieldValue("BJ")]
    Band,

    [EDIFieldValue("BK")]
    Book,

    [EDIFieldValue("BL")]
    Block,

    [EDIFieldValue("BM")]
    Bolt,

    [EDIFieldValue("BN")]
    Bulk,

    [EDIFieldValue("BO")]
    Bottle,

    [EDIFieldValue("BP")]
    _100BoardFeet,

    [EDIFieldValue("BQ")]
    Brakehorsepower,

    [EDIFieldValue("BR")]
    Barrel,

    [EDIFieldValue("BS")]
    Basket,

    [EDIFieldValue("BT")]
    Belt,

    [EDIFieldValue("BU")]
    Bushel,

    [EDIFieldValue("BV")]
    BushelDryImperial,

    [EDIFieldValue("BW")]
    BaseWeight,

    [EDIFieldValue("BX")]
    Box,

    [EDIFieldValue("BY")]
    BritishThermalUnit,

    [EDIFieldValue("BZ")]
    MillionBTUs,

    [EDIFieldValue("C0")]
    Calls,

    [EDIFieldValue("C1")]
    CompositeProductPounds_TotalWeight,

    [EDIFieldValue("C2")]
    Carset,

    [EDIFieldValue("C3")]
    Centiliter,

    [EDIFieldValue("C4")]
    Carload,

    [EDIFieldValue("C5")]
    Cost,

    [EDIFieldValue("C6")]
    Cell,

    [EDIFieldValue("C7")]
    Centipoise_CPS,

    [EDIFieldValue("C8")]
    CubicDecimeter,

    [EDIFieldValue("C9")]
    CoilGroup,

    [EDIFieldValue("CA")]
    Case,

    [EDIFieldValue("CB")]
    Carboy,

    [EDIFieldValue("CC")]
    CubicCentimeter,

    [EDIFieldValue("CD")]
    Carat,

    [EDIFieldValue("CE")]
    CentigradeCelsius,

    [EDIFieldValue("CF")]
    CubicFeet,

    [EDIFieldValue("CG")]
    Card,

    [EDIFieldValue("CH")]
    Container,

    [EDIFieldValue("CI")]
    CubicInches,

    [EDIFieldValue("CJ")]
    Cone,

    [EDIFieldValue("CK")]
    Connector,

    [EDIFieldValue("CL")]
    Cylinder,

    [EDIFieldValue("CM")]
    Centimeter,

    [EDIFieldValue("CN")]
    Can,

    [EDIFieldValue("CO")]
    CubicMeters_Net,

    [EDIFieldValue("CP")]
    Crate,

    [EDIFieldValue("CQ")]
    Cartridge,

    [EDIFieldValue("CR")]
    CubicMeter,

    [EDIFieldValue("CS")]
    Cassette,

    [EDIFieldValue("CT")]
    Carton,

    [EDIFieldValue("CU")]
    Cup,

    [EDIFieldValue("CV")]
    Cover,

    [EDIFieldValue("CW")]
    HundredPounds_CWT,

    [EDIFieldValue("CX")]
    Coil,

    [EDIFieldValue("CY")]
    CubicYard,

    [EDIFieldValue("CZ")]
    Combo,

    [EDIFieldValue("D2")]
    Shares,

    [EDIFieldValue("D3")]
    SquareDecimeter,

    [EDIFieldValue("D5")]
    KilogramPerSquareCentimeter,

    [EDIFieldValue("D8")]
    DraizeScore,

    [EDIFieldValue("D9")]
    DynePerSquareCentimeter,

    [EDIFieldValue("DA")]
    Days,

    [EDIFieldValue("DB")]
    DryPounds,

    [EDIFieldValue("DC")]
    Disk,

    [EDIFieldValue("DD")]
    Degree,

    [EDIFieldValue("DE")]
    Deal,

    [EDIFieldValue("DF")]
    Dram,

    [EDIFieldValue("DG")]
    Decigram,

    [EDIFieldValue("DH")]
    Miles,

    [EDIFieldValue("DI")]
    Dispenser,

    [EDIFieldValue("DJ")]
    Decagram,

    [EDIFieldValue("DK")]
    Kilometers,

    [EDIFieldValue("DL")]
    Deciliter,

    [EDIFieldValue("DM")]
    Decimeter,

    [EDIFieldValue("DN")]
    DeciNewtonMeter,

    [EDIFieldValue("DO")]
    DollarsUS,

    [EDIFieldValue("DP")]
    DozenPair,

    [EDIFieldValue("DQ")]
    DataRecords,

    [EDIFieldValue("DR")]
    Drum,

    [EDIFieldValue("DS")]
    Display,

    [EDIFieldValue("DT")]
    DryTon,

    [EDIFieldValue("DU")]
    Dyne,

    [EDIFieldValue("DW")]
    CalendarDays,

    [EDIFieldValue("DX")]
    DynesPerCentimeter,

    [EDIFieldValue("DY")]
    DirectoryBooks,

    [EDIFieldValue("DZ")]
    Dozen,

    [EDIFieldValue("E1")]
    Hectometer,

    [EDIFieldValue("E3")]
    Inches_FractionAverage,

    [EDIFieldValue("E4")]
    Inches_FractionMinimum,

    [EDIFieldValue("E5")]
    Inches_FractionActual,

    [EDIFieldValue("E7")]
    Inches_DecimalAverage,

    [EDIFieldValue("E8")]
    Inches_DecimalActual,

    [EDIFieldValue("E9")]
    English_FeetInches,

    [EDIFieldValue("EA")]
    Each,

    [EDIFieldValue("EB")]
    ElectronicMailBoxes,

    [EDIFieldValue("EC")]
    EachPerMonth,

    [EDIFieldValue("ED")]
    Inches_DecimalNominal,

    [EDIFieldValue("EE")]
    Employees,

    [EDIFieldValue("EF")]
    Inches_FractionNominal,

    [EDIFieldValue("EG")]
    DoubletimeHours,

    [EDIFieldValue("EH")]
    Knots,

    [EDIFieldValue("EJ")]
    Locations,

    [EDIFieldValue("EM")]
    Inches_DecimalMinimum,

    [EDIFieldValue("EP")]
    ElevenPack,

    [EDIFieldValue("EQ")]
    EquivalentGallons,

    [EDIFieldValue("EV")]
    Envelope,

    [EDIFieldValue("EX")]
    Feet_InchesAndFraction,

    [EDIFieldValue("EY")]
    Feet_InchesAndDecimal,

    [EDIFieldValue("EZ")]
    FeetAndDecimal,

    [EDIFieldValue("F1")]
    ThousandCubicFeetPerDay,

    [EDIFieldValue("F2")]
    InternationalUnit,

    [EDIFieldValue("F3")]
    Equivalent,

    [EDIFieldValue("F4")]
    Minim,

    [EDIFieldValue("F5")]
    MOL,

    [EDIFieldValue("F6")]
    PricePerShare,

    [EDIFieldValue("F9")]
    FibersPerCubicCentimeterOfAir,

    [EDIFieldValue("FA")]
    Fahrenheit,

    [EDIFieldValue("FB")]
    Fields,

    [EDIFieldValue("FC")]
    _1000CubicFeet,

    [EDIFieldValue("FD")]
    MillionParticlesPerCubicFoot,

    [EDIFieldValue("FE")]
    TrackFoot,

    [EDIFieldValue("FF")]
    HundredCubicMeters,

    [EDIFieldValue("FG")]
    TransdermalPatch,

    [EDIFieldValue("FH")]
    Micromolar,

    [EDIFieldValue("FJ")]
    SizingFactor,

    [EDIFieldValue("FK")]
    Fibers,

    [EDIFieldValue("FL")]
    FlakeTon,

    [EDIFieldValue("FM")]
    MillionCubicFeet,

    [EDIFieldValue("FO")]
    FluidOunce,

    [EDIFieldValue("FP")]
    PoundsPerSqFt,

    [EDIFieldValue("FR")]
    FeetPerMinute,

    [EDIFieldValue("FS")]
    FeetPerSecond,

    [EDIFieldValue("FT")]
    Foot,

    [EDIFieldValue("FZ")]
    FluidOunce_Imperial,

    [EDIFieldValue("G2")]
    USGallonsPerMinute,

    [EDIFieldValue("G3")]
    ImperialGallonsPerMinute,

    [EDIFieldValue("G4")]
    Gigabecquerel,

    [EDIFieldValue("G5")]
    Gill_Imperial,

    [EDIFieldValue("G7")]
    MicroficheSheet,

    [EDIFieldValue("GA")]
    Gallon,

    [EDIFieldValue("GB")]
    GallonsPerDay,

    [EDIFieldValue("GC")]
    GramsPer100Grams,

    [EDIFieldValue("GD")]
    GrossBarrels,

    [EDIFieldValue("GE")]
    PoundsPerGallon,

    [EDIFieldValue("GF")]
    GramsPer100Centimeters,

    [EDIFieldValue("GG")]
    GreatGross_DozenGross,

    [EDIFieldValue("GH")]
    HalfGallon,

    [EDIFieldValue("GI")]
    ImperialGallons,

    [EDIFieldValue("GJ")]
    GramsPerMilliliter,

    [EDIFieldValue("GK")]
    GramsPerKilogram,

    [EDIFieldValue("GL")]
    GramsPerLiter,

    [EDIFieldValue("GM")]
    GramsPerSqMeter,

    [EDIFieldValue("GN")]
    GrossGallons,

    [EDIFieldValue("GO")]
    MilligramsPerSquareMeter,

    [EDIFieldValue("GP")]
    MilligramsPerCubicMeter,

    [EDIFieldValue("GQ")]
    MicrogramsPerCubicMeter,

    [EDIFieldValue("GR")]
    Gram,

    [EDIFieldValue("GS")]
    Gross,

    [EDIFieldValue("GT")]
    GrossKilogram,

    [EDIFieldValue("GU")]
    GaussPerOersteds,

    [EDIFieldValue("GV")]
    Gigajoules,

    [EDIFieldValue("GW")]
    GallonsPerThousandCubicFeet,

    [EDIFieldValue("GX")]
    Grain,

    [EDIFieldValue("GY")]
    GrossYard,

    [EDIFieldValue("GZ")]
    GageSystems,

    [EDIFieldValue("H1")]
    HalfPages_Electronic,

    [EDIFieldValue("H2")]
    HalfLiter,

    [EDIFieldValue("H4")]
    Hectoliter,

    [EDIFieldValue("HA")]
    Hank,

    [EDIFieldValue("HB")]
    HundredBoxes,

    [EDIFieldValue("HC")]
    HundredCount,

    [EDIFieldValue("HD")]
    HalfDozen,

    [EDIFieldValue("HE")]
    HundredthOfACarat,

    [EDIFieldValue("HF")]
    HundredFeet,

    [EDIFieldValue("HG")]
    Hectogram,

    [EDIFieldValue("HH")]
    HundredCubicFeet,

    [EDIFieldValue("HI")]
    HundredSheets,

    [EDIFieldValue("HJ")]
    Horsepower,

    [EDIFieldValue("HK")]
    HundredKilograms,

    [EDIFieldValue("HL")]
    HundredFeet_Linear,

    [EDIFieldValue("HM")]
    MilesPerHour,

    [EDIFieldValue("HN")]
    MillimetersOfMercury,

    [EDIFieldValue("HO")]
    HundredTroyOunces,

    [EDIFieldValue("HP")]
    MillimeterH20,

    [EDIFieldValue("HQ")]
    Hectare,

    [EDIFieldValue("HR")]
    Hours,

    [EDIFieldValue("HS")]
    HundredSquareFeet,

    [EDIFieldValue("HT")]
    HalfHour,

    [EDIFieldValue("HU")]
    Hundred,

    [EDIFieldValue("HV")]
    HundredWeight_Short,

    [EDIFieldValue("HW")]
    HundredWeight_Long,

    [EDIFieldValue("HY")]
    HundredYards,

    [EDIFieldValue("HZ")]
    Hertz,

    [EDIFieldValue("IA")]
    InchPound,

    [EDIFieldValue("IB")]
    InchesPerSecond_VibrationVelocity,

    [EDIFieldValue("IC")]
    CountsPerInch,

    [EDIFieldValue("IE")]
    Person,

    [EDIFieldValue("IF")]
    InchesOfWater,

    [EDIFieldValue("IH")]
    Inhaler,

    [EDIFieldValue("II")]
    ColumnInches,

    [EDIFieldValue("IK")]
    PeaksPerInch_PPI,

    [EDIFieldValue("IL")]
    InchesPerMinute,

    [EDIFieldValue("IM")]
    Impressions,

    [EDIFieldValue("IN")]
    Inch,

    [EDIFieldValue("IP")]
    InsurancePolicy,

    [EDIFieldValue("IT")]
    CountsPerCentimeter,

    [EDIFieldValue("IU")]
    InchesPerSecond_LinearSpeed,

    [EDIFieldValue("IV")]
    InchesPerSecondPerSecond_Acceleration,

    [EDIFieldValue("IW")]
    InchesPerSecondPerSecond_VibrationAcceleration,

    [EDIFieldValue("J2")]
    JoulePerKilogram,

    [EDIFieldValue("JA")]
    Job,

    [EDIFieldValue("JB")]
    Jumbo,

    [EDIFieldValue("JE")]
    JoulePerKelvin,

    [EDIFieldValue("JG")]
    JoulePerGram,

    [EDIFieldValue("JK")]
    MegaJoulePerKilogram,

    [EDIFieldValue("JM")]
    MegajoulePerCubicMeter,

    [EDIFieldValue("JO")]
    Joint,

    [EDIFieldValue("JR")]
    Jar,

    [EDIFieldValue("JU")]
    Jug,

    [EDIFieldValue("K1")]
    KilowattDemand,

    [EDIFieldValue("K2")]
    KilovoltAmperesReactiveDemand,

    [EDIFieldValue("K3")]
    KilovoltAmperesReactiveHour,

    [EDIFieldValue("K4")]
    KilovoltAmperes,

    [EDIFieldValue("K5")]
    KilovoltAmperesReactive,

    [EDIFieldValue("K6")]
    Kiloliter,

    [EDIFieldValue("K7")]
    Kilowatt,

    [EDIFieldValue("K9")]
    KilogramsPerMillimeterSquared_KGPerMM2,

    [EDIFieldValue("KA")]
    Cake,

    [EDIFieldValue("KB")]
    Kilocharacters,

    [EDIFieldValue("KC")]
    KilogramsPerCubicMeter,

    [EDIFieldValue("KD")]
    KilogramsDecimal,

    [EDIFieldValue("KE")]
    Keg,

    [EDIFieldValue("KF")]
    Kilopackets,

    [EDIFieldValue("KG")]
    Kilogram,

    [EDIFieldValue("KH")]
    KilowattHour,

    [EDIFieldValue("KI")]
    KilogramsPerMillimeterWidth,

    [EDIFieldValue("KJ")]
    Kilosegments,

    [EDIFieldValue("KK")]
    _100Kilograms,

    [EDIFieldValue("KL")]
    KilogramsPerMeter,

    [EDIFieldValue("KM")]
    KilogramsPerSquareMeter_Kilograms_Decimal,

    [EDIFieldValue("KO")]
    MillequivalenceCausticPotashPerGramOfProduct,

    [EDIFieldValue("KP")]
    KilometersPerHour,

    [EDIFieldValue("KQ")]
    Kilopascal,

    [EDIFieldValue("KR")]
    Kiloroentgen,

    [EDIFieldValue("KS")]
    _1000PoundsPerSquareInch,

    [EDIFieldValue("KT")]
    Kit,

    [EDIFieldValue("KU")]
    _Task,

    [EDIFieldValue("KV")]
    Kelvin,

    [EDIFieldValue("KW")]
    KilogramsPerMillimeter,

    [EDIFieldValue("KX")]
    MillilitersPerKilogram,

    [EDIFieldValue("L2")]
    LitersPerMinute,

    [EDIFieldValue("LA")]
    PoundsPerCubicInch,

    [EDIFieldValue("LB")]
    Pound,

    [EDIFieldValue("LC")]
    LinearCentimeter,

    [EDIFieldValue("LE")]
    Lite,

    [EDIFieldValue("LF")]
    LinearFoot,

    [EDIFieldValue("LG")]
    LongTon,

    [EDIFieldValue("LH")]
    LaborHours,

    [EDIFieldValue("LI")]
    LinearInch,

    [EDIFieldValue("LJ")]
    LargeSpray,

    [EDIFieldValue("LK")]
    Link,

    [EDIFieldValue("LL")]
    Lifetime,

    [EDIFieldValue("LM")]
    LinearMeter,

    [EDIFieldValue("LN")]
    Length,

    [EDIFieldValue("LO")]
    Lot,

    [EDIFieldValue("LP")]
    LiquidPounds,

    [EDIFieldValue("LQ")]
    LitersPerDay,

    [EDIFieldValue("LR")]
    Layers,

    [EDIFieldValue("LS")]
    LumpSum,

    [EDIFieldValue("LT")]
    Liter,

    [EDIFieldValue("LX")]
    LinearYardsPerPound,

    [EDIFieldValue("LY")]
    LinearYard,

    [EDIFieldValue("M0")]
    MagneticTapes,

    [EDIFieldValue("M1")]
    MilligramsperLiter,

    [EDIFieldValue("M2")]
    MillimeterActual,

    [EDIFieldValue("M3")]
    Mat,

    [EDIFieldValue("M4")]
    MonetaryValue,

    [EDIFieldValue("M5")]
    Microcurie,

    [EDIFieldValue("M6")]
    Millibar,

    [EDIFieldValue("M7")]
    MicroInch,

    [EDIFieldValue("M8")]
    MegaPascals,

    [EDIFieldValue("M9")]
    MillionBritishThermalUnitsperOneThousandCubicFeet,

    [EDIFieldValue("MA")]
    MachinePerUnit,

    [EDIFieldValue("MB")]
    MillimeterNominal,

    [EDIFieldValue("MC")]
    Microgram,

    [EDIFieldValue("MD")]
    AirDryMetricTon,

    [EDIFieldValue("ME")]
    Milligram,

    [EDIFieldValue("MF")]
    MilligramPerSqFtperSide,

    [EDIFieldValue("MG")]
    MetricGrossTon,

    [EDIFieldValue("MH")]
    Microns_Micrometers,

    [EDIFieldValue("MI")]
    Metric,

    [EDIFieldValue("MJ")]
    Minutes,

    [EDIFieldValue("MK")]
    MilligramsPerSquareInch,

    [EDIFieldValue("ML")]
    Milliliter,

    [EDIFieldValue("MM")]
    Millimeter,

    [EDIFieldValue("MN")]
    MetricNetTon,

    [EDIFieldValue("MO")]
    Months,

    [EDIFieldValue("MP")]
    MetricTon,

    [EDIFieldValue("MQ")]
    _1000Meters,

    [EDIFieldValue("MR")]
    Meter,

    [EDIFieldValue("MS")]
    SquareMillimeter,

    [EDIFieldValue("MT")]
    MetricLongTon,

    [EDIFieldValue("MU")]
    Millicurie,

    [EDIFieldValue("MV")]
    NumberOfMults,

    [EDIFieldValue("MW")]
    MetricTonKilograms,

    [EDIFieldValue("MX")]
    Mixed,

    [EDIFieldValue("MY")]
    MillimeterAverage,

    [EDIFieldValue("MZ")]
    MillimeterMinimum,

    [EDIFieldValue("N1")]
    PenCalories,

    [EDIFieldValue("N2")]
    NumberOfLines,

    [EDIFieldValue("N3")]
    PrintPoint,

    [EDIFieldValue("N4")]
    PenGrams_Protein,

    [EDIFieldValue("N6")]
    Megahertz,

    [EDIFieldValue("N7")]
    Parts,

    [EDIFieldValue("N9")]
    CartridgeNeedle,

    [EDIFieldValue("NA")]
    MilligramsPerKilogram,

    [EDIFieldValue("NB")]
    Barge,

    [EDIFieldValue("NC")]
    Car,

    [EDIFieldValue("ND")]
    NetBarrels,

    [EDIFieldValue("NE")]
    NetLiters,

    [EDIFieldValue("NF")]
    Messages,

    [EDIFieldValue("NG")]
    NetGallons,

    [EDIFieldValue("NH")]
    MessageHours,

    [EDIFieldValue("NI")]
    NetImperialGallons,

    [EDIFieldValue("NJ")]
    NumberOfScreens,

    [EDIFieldValue("NL")]
    Load,

    [EDIFieldValue("NM")]
    NauticalMile,

    [EDIFieldValue("NN")]
    Train,

    [EDIFieldValue("NQ")]
    Mho,

    [EDIFieldValue("NR")]
    MicroMho,

    [EDIFieldValue("NS")]
    ShortTon,

    [EDIFieldValue("NT")]
    Trailer,

    [EDIFieldValue("NU")]
    NewtonMeter,

    [EDIFieldValue("NV")]
    Vehicle,

    [EDIFieldValue("NW")]
    Newton,

    [EDIFieldValue("NX")]
    PartsPerThousand,

    [EDIFieldValue("NY")]
    PoundsPerAirDryMetricTon,

    [EDIFieldValue("OA")]
    Panel,

    [EDIFieldValue("OC")]
    Billboard,

    [EDIFieldValue("ON")]
    OuncesPerSquareYard,

    [EDIFieldValue("OP")]
    TwoPack,

    [EDIFieldValue("OT")]
    OvertimeHours,

    [EDIFieldValue("OZ")]
    Ounce_Av,

    [EDIFieldValue("P0")]
    Pages_Electronic,

    [EDIFieldValue("P1")]
    Percent,

    [EDIFieldValue("P2")]
    Pounds_PerFoot,

    [EDIFieldValue("P3")]
    ThreePack,

    [EDIFieldValue("P4")]
    FourPack,

    [EDIFieldValue("P5")]
    FivePack,

    [EDIFieldValue("P6")]
    SixPack,

    [EDIFieldValue("P7")]
    SevenPack,

    [EDIFieldValue("P8")]
    EightPack,

    [EDIFieldValue("P9")]
    NinePack,

    [EDIFieldValue("PA")]
    Pail,

    [EDIFieldValue("PB")]
    PairInches,

    [EDIFieldValue("PC")]
    Piece,

    [EDIFieldValue("PD")]
    Pad,

    [EDIFieldValue("PE")]
    PoundsEquivalent,

    [EDIFieldValue("PF")]
    Pallet_Lift,

    [EDIFieldValue("PG")]
    PoundsGross,

    [EDIFieldValue("PH")]
    Pack,

    [EDIFieldValue("PI")]
    Pitch,

    [EDIFieldValue("PJ")]
    Pounds_Decimal_PoundsPerSquareFoot_PoundGage,

    [EDIFieldValue("PK")]
    Package,

    [EDIFieldValue("PL")]
    Pallet_UnitLoad,

    [EDIFieldValue("PM")]
    PoundsPercentage,

    [EDIFieldValue("PN")]
    PoundsNet,

    [EDIFieldValue("PO")]
    PoundsPerInchOfLength,

    [EDIFieldValue("PP")]
    Plate,

    [EDIFieldValue("PQ")]
    PagesPerInch,

    [EDIFieldValue("PR")]
    Pair,

    [EDIFieldValue("PS")]
    PoundsPerSqInch,

    [EDIFieldValue("PT")]
    Pint,

    [EDIFieldValue("PU")]
    MassPounds,

    [EDIFieldValue("PV")]
    HalfPint,

    [EDIFieldValue("PW")]
    PoundsPerInchOfWidth,

    [EDIFieldValue("PX")]
    Pint_Imperial,

    [EDIFieldValue("PY")]
    Peck_DryUS,

    [EDIFieldValue("PZ")]
    Peck_DryImperial,

    [EDIFieldValue("Q1")]
    Quarter_Time,

    [EDIFieldValue("Q2")]
    Pint_USDry,

    [EDIFieldValue("Q3")]
    Meal,

    [EDIFieldValue("Q4")]
    Fifty,

    [EDIFieldValue("Q5")]
    TwentyFive,

    [EDIFieldValue("Q6")]
    ThirtySix,

    [EDIFieldValue("Q7")]
    TwentyFour,

    [EDIFieldValue("QA")]
    Pages_Facsimile,

    [EDIFieldValue("QB")]
    Pages_Hardcopy,

    [EDIFieldValue("QC")]
    Channel,

    [EDIFieldValue("QD")]
    QuarterDozen,

    [EDIFieldValue("QE")]
    Photographs,

    [EDIFieldValue("QH")]
    QuarterHours,

    [EDIFieldValue("QK")]
    QuarterKilogram,

    [EDIFieldValue("QR")]
    Quire,

    [EDIFieldValue("QS")]
    Quart_DryUS,

    [EDIFieldValue("QT")]
    Quart,

    [EDIFieldValue("QU")]
    Quart_Imperial,

    [EDIFieldValue("R1")]
    Pica,

    [EDIFieldValue("R2")]
    Becquerel,

    [EDIFieldValue("R3")]
    RevolutionsPerMinute,

    [EDIFieldValue("R4")]
    Calorie,

    [EDIFieldValue("R5")]
    ThousandsOfDollars,

    [EDIFieldValue("R6")]
    MillionsOfDollars,

    [EDIFieldValue("R7")]
    BillionsOfDollars,

    [EDIFieldValue("R8")]
    RoentgenEquivalentInMan_REM,

    [EDIFieldValue("R9")]
    ThousandCubicMeters,

    [EDIFieldValue("RA")]
    Rack,

    [EDIFieldValue("RB")]
    Radian,

    [EDIFieldValue("RC")]
    Rod_area_16Pt25SquareYards,

    [EDIFieldValue("RD")]
    Rod_length_5Pt5Yards,

    [EDIFieldValue("RE")]
    Reel,

    [EDIFieldValue("RG")]
    Ring,

    [EDIFieldValue("RH")]
    RunningOrOperatingHours,

    [EDIFieldValue("RK")]
    RollMetricMeasure,

    [EDIFieldValue("RL")]
    Roll,

    [EDIFieldValue("RM")]
    Ream,

    [EDIFieldValue("RN")]
    ReamMetricMeasure,

    [EDIFieldValue("RO")]
    Round,

    [EDIFieldValue("RP")]
    PoundsPerReam,

    [EDIFieldValue("RS")]
    Resets,

    [EDIFieldValue("RT")]
    RevenueTonMiles,

    [EDIFieldValue("RU")]
    Run,

    [EDIFieldValue("S1")]
    Semester,

    [EDIFieldValue("S2")]
    Trimester,

    [EDIFieldValue("S3")]
    SquareFeetPerSecond,

    [EDIFieldValue("S4")]
    SquareMetersPerSecond,

    [EDIFieldValue("S5")]
    SixtyFourthsOfAnInch,

    [EDIFieldValue("S6")]
    Sessions,

    [EDIFieldValue("S7")]
    StorageUnits,

    [EDIFieldValue("S8")]
    StandardAdvertisingUnits_SAUs,

    [EDIFieldValue("S9")]
    SlipSheet,

    [EDIFieldValue("SA")]
    Sandwich,

    [EDIFieldValue("SB")]
    SquareMile,

    [EDIFieldValue("SC")]
    SquareCentimeter,

    [EDIFieldValue("SD")]
    SolidPounds,

    [EDIFieldValue("SE")]
    Section,

    [EDIFieldValue("SF")]
    SquareFoot,

    [EDIFieldValue("SG")]
    Segment,

    [EDIFieldValue("SH")]
    Sheet,

    [EDIFieldValue("SI")]
    SquareInch,

    [EDIFieldValue("SJ")]
    Sack,

    [EDIFieldValue("SK")]
    SplitTanktruck,

    [EDIFieldValue("SL")]
    Sleeve,

    [EDIFieldValue("SM")]
    SquareMeter,

    [EDIFieldValue("SN")]
    SquareRod,

    [EDIFieldValue("SO")]
    Spool,

    [EDIFieldValue("SP")]
    ShelfPackage,

    [EDIFieldValue("SQ")]
    Square,

    [EDIFieldValue("SR")]
    Strip,

    [EDIFieldValue("SS")]
    SheetMetricMeasure,

    [EDIFieldValue("ST")]
    Set,

    [EDIFieldValue("SV")]
    Skid,

    [EDIFieldValue("SW")]
    Skein,

    [EDIFieldValue("SX")]
    Shipment,

    [EDIFieldValue("SY")]
    SquareYard,

    [EDIFieldValue("SZ")]
    Syringe,

    [EDIFieldValue("T0")]
    TelecommunicationsLinesInService,

    [EDIFieldValue("T1")]
    ThousandPoundsGross,

    [EDIFieldValue("T2")]
    ThousandthsOfAnInch,

    [EDIFieldValue("T3")]
    ThousandPieces,

    [EDIFieldValue("T4")]
    ThousandBags,

    [EDIFieldValue("T5")]
    ThousandCasings,

    [EDIFieldValue("T6")]
    ThousandGallons,

    [EDIFieldValue("T7")]
    ThousandImpressions,

    [EDIFieldValue("T8")]
    ThousandLinearInches,

    [EDIFieldValue("T9")]
    ThousandKilowattHours,

    [EDIFieldValue("TA")]
    TenthCubicFoot,

    [EDIFieldValue("TB")]
    Tube,

    [EDIFieldValue("TC")]
    Truckload,

    [EDIFieldValue("TD")]
    Therms,

    [EDIFieldValue("TE")]
    Tote,

    [EDIFieldValue("TF")]
    TenSquareYards,

    [EDIFieldValue("TG")]
    GrossTon,

    [EDIFieldValue("TH")]
    Thousand,

    [EDIFieldValue("TI")]
    ThousandSquareInches,

    [EDIFieldValue("TJ")]
    ThousandSqCentimeters,

    [EDIFieldValue("TK")]
    Tank,

    [EDIFieldValue("TL")]
    ThousandFeet_Linear,

    [EDIFieldValue("TM")]
    ThousandFeet_Board,

    [EDIFieldValue("TN")]
    NetTon,

    [EDIFieldValue("TO")]
    TroyOunce,

    [EDIFieldValue("TP")]
    TenPack,

    [EDIFieldValue("TQ")]
    ThousandFeet,

    [EDIFieldValue("TR")]
    TenSquareFeet,

    [EDIFieldValue("TS")]
    ThousandSquareFeet,

    [EDIFieldValue("TT")]
    ThousandLinearMeters,

    [EDIFieldValue("TU")]
    ThousandLinearYards,

    [EDIFieldValue("TV")]
    ThousandKilograms,

    [EDIFieldValue("TW")]
    ThousandSheets,

    [EDIFieldValue("TX")]
    TroyPound,

    [EDIFieldValue("TY")]
    Tray,

    [EDIFieldValue("TZ")]
    ThousandCubicFeet,

    [EDIFieldValue("U1")]
    Treatments,

    [EDIFieldValue("U2")]
    Tablet,

    [EDIFieldValue("U3")]
    Ten,

    [EDIFieldValue("U5")]
    TwoHundredFifty,

    [EDIFieldValue("UA")]
    Torr,

    [EDIFieldValue("UB")]
    TelecommunicationsLinesInService_Average,

    [EDIFieldValue("UC")]
    TelecommunicationsPorts,

    [EDIFieldValue("UD")]
    TenthMinutes,

    [EDIFieldValue("UE")]
    TenthHours,

    [EDIFieldValue("UF")]
    UsagePerTelecommunicationsLine_Average,

    [EDIFieldValue("UH")]
    TenThousandYards,

    [EDIFieldValue("UL")]
    Unitless,

    [EDIFieldValue("UM")]
    MillionUnits,

    [EDIFieldValue("UN")]
    Unit,

    [EDIFieldValue("UP")]
    Troche,

    [EDIFieldValue("UQ")]
    Wafer,

    [EDIFieldValue("UR")]
    Application,

    [EDIFieldValue("US")]
    DosageForm,

    [EDIFieldValue("UT")]
    Inhalation,

    [EDIFieldValue("UU")]
    Lozenge,

    [EDIFieldValue("UV")]
    PercentTopicalOnly,

    [EDIFieldValue("UW")]
    Milliequivalent,

    [EDIFieldValue("UX")]
    Dram_Minim,

    [EDIFieldValue("UY")]
    FiftySquareFeet,

    [EDIFieldValue("UZ")]
    FiftyCount,

    [EDIFieldValue("V1")]
    Flat,

    [EDIFieldValue("V2")]
    Pouch,

    [EDIFieldValue("VA")]
    VoltAmperePerKilogram,

    [EDIFieldValue("VC")]
    FiveHundred,

    [EDIFieldValue("VI")]
    Vial,

    [EDIFieldValue("VP")]
    PercentVolume,

    [EDIFieldValue("VR")]
    VoltAmpereReactive,

    [EDIFieldValue("VS")]
    Visit,

    [EDIFieldValue("W2")]
    WetKilo,

    [EDIFieldValue("WA")]
    WattsPerKilogram,

    [EDIFieldValue("WB")]
    WetPound,

    [EDIFieldValue("WD")]
    WorkDays,

    [EDIFieldValue("WE")]
    WetTon,

    [EDIFieldValue("WG")]
    WineGallon,

    [EDIFieldValue("WH")]
    Wheel,

    [EDIFieldValue("WI")]
    WeightPerSquareInch,

    [EDIFieldValue("WK")]
    Week,

    [EDIFieldValue("WM")]
    WorkingMonths,

    [EDIFieldValue("WP")]
    Pennyweight,

    [EDIFieldValue("WR")]
    Wrap,

    [EDIFieldValue("WW")]
    MillilitersOfWater,

    [EDIFieldValue("X1")]
    Chains_LandSurvey,

    [EDIFieldValue("X2")]
    Bunch,

    [EDIFieldValue("X3")]
    Clove,

    [EDIFieldValue("X4")]
    Drop,

    [EDIFieldValue("X5")]
    Head,

    [EDIFieldValue("X6")]
    Heart,

    [EDIFieldValue("X7")]
    Leaf,

    [EDIFieldValue("X8")]
    Loaf,

    [EDIFieldValue("X9")]
    Portion,

    [EDIFieldValue("XP")]
    BaseBoxPerPound,

    [EDIFieldValue("Y1")]
    Slice,

    [EDIFieldValue("Y2")]
    Tablespoon,

    [EDIFieldValue("Y3")]
    Teaspoon,

    [EDIFieldValue("Y4")]
    Tub,

    [EDIFieldValue("YD")]
    Yard,

    [EDIFieldValue("YL")]
    _100LinealYards,

    [EDIFieldValue("YR")]
    Years,

    [EDIFieldValue("YT")]
    TenYards,

    [EDIFieldValue("Z1")]
    LiftVan,

    [EDIFieldValue("Z2")]
    Chest,

    [EDIFieldValue("Z3")]
    Cask,

    [EDIFieldValue("Z4")]
    Hogshead,

    [EDIFieldValue("Z5")]
    Lug,

    [EDIFieldValue("Z6")]
    ConferencePoints,

    [EDIFieldValue("Z8")]
    NewspaperAgateLine,

    [EDIFieldValue("ZA")]
    Bimonthly,

    [EDIFieldValue("ZB")]
    Biweekly,

    [EDIFieldValue("ZC")]
    Semiannual,

    [EDIFieldValue("ZP")]
    Page,

    [EDIFieldValue("ZZ")]
    MutuallyDefined
  }
}