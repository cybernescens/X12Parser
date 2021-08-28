using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace X12.Hipaa.Claims.Forms
{
  public enum TextAlignEnum
  {
    left,
    center,
    right
  }

  public class FormBlock
  {
    public string LetterSpacing { get; set; }
    public TextAlignEnum TextAlign { get; set; }
    public decimal Left { get; set; }
    public decimal Top { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string Text { get; set; }
  }

  public class FormPage
  {
    public FormPage()
    {
      if (Blocks == null) Blocks = new List<FormBlock>();
    }

    public string MasterReference { get; set; }
    public string ImagePath { get; set; }

    [XmlElement(ElementName = "Block")]
    public List<FormBlock> Blocks { get; set; }
  }

  public class FormDocument
  {
    public FormDocument()
    {
      if (Pages == null) Pages = new List<FormPage>();
    }

    [XmlElement(ElementName = "Page")]
    public List<FormPage> Pages { get; set; }

    #region Serialization Methods

    public string Serialize()
    {
      var writer = new StringWriter();
      new XmlSerializer(typeof(FormDocument)).Serialize(writer, this);
      return writer.ToString();
    }

    public static FormDocument Deserialize(string xml)
    {
      var serializer = new XmlSerializer(typeof(FormDocument));
      return (FormDocument) serializer.Deserialize(new StringReader(xml));
    }

    #endregion
  }
}