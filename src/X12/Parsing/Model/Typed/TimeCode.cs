﻿using X12.Attributes;

namespace X12.Parsing.Model.Typed
{
  public enum TimeCode
  {
    [EDIFieldValue("01")]
    EquivalentToIsoP01,

    [EDIFieldValue("02")]
    EquivalentToIsoP02,

    [EDIFieldValue("03")]
    EquivalentToIsoP03,

    [EDIFieldValue("04")]
    EquivalentToIsoP04,

    [EDIFieldValue("05")]
    EquivalentToIsoP05,

    [EDIFieldValue("06")]
    EquivalentToIsoP06,

    [EDIFieldValue("07")]
    EquivalentToIsoP07,

    [EDIFieldValue("08")]
    EquivalentToIsoP08,

    [EDIFieldValue("09")]
    EquivalentToIsoP09,

    [EDIFieldValue("10")]
    EquivalentToIsoP10,

    [EDIFieldValue("11")]
    EquivalentToIsoP11,

    [EDIFieldValue("12")]
    EquivalentToIsoP12,

    [EDIFieldValue("13")]
    EquivalentToIsoM12,

    [EDIFieldValue("14")]
    EquivalentToIsoM11,

    [EDIFieldValue("15")]
    EquivalentToIsoM10,

    [EDIFieldValue("16")]
    EquivalentToIsoM09,

    [EDIFieldValue("17")]
    EquivalentToIsoM08,

    [EDIFieldValue("18")]
    EquivalentToIsoM07,

    [EDIFieldValue("19")]
    EquivalentToIsoM06,

    [EDIFieldValue("20")]
    EquivalentToIsoM05,

    [EDIFieldValue("21")]
    EquivalentToIsoM04,

    [EDIFieldValue("22")]
    EquivalentToIsoM03,

    [EDIFieldValue("23")]
    EquivalentToIsoM02,

    [EDIFieldValue("24")]
    EquivalentToIsoM01,

    [EDIFieldValue("AD")]
    AlaskaDaylightTime,

    [EDIFieldValue("AS")]
    AlaskaStandardTime,

    [EDIFieldValue("AT")]
    AlaskaTime,

    [EDIFieldValue("CD")]
    CentralDaylightTime,

    [EDIFieldValue("CS")]
    CentralStandardTime,

    [EDIFieldValue("CT")]
    CentralTime,

    [EDIFieldValue("ED")]
    EasternDaylightTime,

    [EDIFieldValue("ES")]
    EasternStandardTime,

    [EDIFieldValue("ET")]
    EasternTime,

    [EDIFieldValue("GM")]
    GreenwichMeanTime,

    [EDIFieldValue("HD")]
    Hawaii_AleutianDaylightTime,

    [EDIFieldValue("HS")]
    Hawaii_AleutianStandardTime,

    [EDIFieldValue("HT")]
    Hawaii_AleutianTime,

    [EDIFieldValue("LT")]
    LocalTime,

    [EDIFieldValue("MD")]
    MountainDaylightTime,

    [EDIFieldValue("MS")]
    MountainStandardTime,

    [EDIFieldValue("MT")]
    MountainTime,

    [EDIFieldValue("ND")]
    NewfoundlandDaylightTime,

    [EDIFieldValue("NS")]
    NewfoundlandStandardTime,

    [EDIFieldValue("NT")]
    NewfoundlandTime,

    [EDIFieldValue("PD")]
    PacificDaylightTime,

    [EDIFieldValue("PS")]
    PacificStandardTime,

    [EDIFieldValue("PT")]
    PacificTime,

    [EDIFieldValue("TD")]
    AtlanticDaylightTime,

    [EDIFieldValue("TS")]
    AtlanticStandardTime,

    [EDIFieldValue("TT")]
    AtlanticTime,

    [EDIFieldValue("UT")]
    UniversalTimeCoordinate
  }
}