using System;
using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public enum GenderEnum
  {
    Unknown,
    Male,
    Female
  }

  public class Member : Entity
  {
    [XmlAttribute]
    public GenderEnum Gender { get; set; }

    [XmlIgnore]
    public DateTime? DateOfBirth { get; set; }

    public Lookup Relationship { get; set; }

    [XmlAttribute]
    public string MemberId
    {
      get {
        if (Name != null && Name.Identification != null && Name.Identification.Qualifier == "MI")
          return Name.Identification.Id;

        return GetReferenceId("1W");
      }
      set { }
    }

    [XmlAttribute]
    public string Ssn
    {
      get => GetReferenceId("SY");
      set { }
    }

    [XmlAttribute]
    public string PlanNumber
    {
      get => GetReferenceId("18");
      set { }
    }

    [XmlAttribute]
    public string GroupNumber => GetReferenceId("6P");

    #region Serializable DateOfBirth Properties

    [XmlAttribute(AttributeName = "DateOfBirth", DataType = "date")]
    public DateTime SerializableDateOfBirth
    {
      get => DateOfBirth ?? DateTime.MinValue;
      set => DateOfBirth = value;
    }

    [XmlIgnore]
    public bool SerializableDateOfBirthSpecified
    {
      get => DateOfBirth.HasValue;
      set { }
    }

    #endregion
  }
}