using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace X12.Hipaa.Common
{
  public class Entity
  {
    public Entity()
    {
      if (Name == null) Name = new EntityName();
      if (Identifications == null) Identifications = new List<Identification>();
      if (Contacts == null) Contacts = new List<Contact>();
      if (RequestValidations != null) RequestValidations = new List<RequestValidation>();
    }

    public EntityName Name { get; set; }
    public PostalAddress Address { get; set; }

    [XmlElement(ElementName = "Identification")]
    public List<Identification> Identifications { get; set; }

    [XmlElement(ElementName = "Contact")]
    public List<Contact> Contacts { get; set; }

    [XmlElement(ElementName = "RequestValidation")]
    public List<RequestValidation> RequestValidations { get; set; }

    protected string GetReferenceId(string qualifier)
    {
      var reference = Identifications.FirstOrDefault(id => id.Qualifier == qualifier);
      if (reference != null)
        return reference.Id;

      return null;
    }
  }
}