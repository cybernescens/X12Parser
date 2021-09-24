using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Model
{
  public class Segment : DetachedSegment, IXmlSerializable, IEquatable<Segment>
  {
    internal Segment(Container parent, X12DelimiterSet delimiters, string segment)
      : base(delimiters, segment)
    {
      Parent = parent;
      _delimiters = delimiters;
      Initialize(segment);
    }

    public virtual int Count => 1;

    public bool Equals(Segment other)
    {
      if (ReferenceEquals(null, other))
        return false;
        
      if (!ReferenceEquals(Parent, other.Parent))
        return false;

      if (SegmentId != other.SegmentId)
        return false;

      for(var i = 0; i < ElementCount; i++)
        if (GetElement(i) != other.GetElement(i))
          return false;

      return true;
    }

    public override bool Equals(object obj) =>
      !ReferenceEquals(null, obj) &&
      (ReferenceEquals(this, obj) || 
        obj.GetType() == GetType() && Equals((Segment)obj));

    public override int GetHashCode()
    {
      unchecked
      {
        return (397 * Parent?.GetHashCode() ?? 0) ^ string.GetHashCode(SegmentString);
      }
    }

    public Container Parent { get; }

    public virtual FunctionGroup Group =>
      Parent switch {
        Interchange      => null,
        FunctionGroup fg => fg,
        Transaction tx   => tx.Group,
        _                => Parent.Transaction.Group
      };

    public virtual string TransactionSetCode =>
      Parent switch {
        Interchange    => null,
        FunctionGroup  => null,
        Transaction tx => tx.IdentifierCode,
        _              => Parent.Transaction.IdentifierCode
      };
    
    protected internal virtual ISpecificationFinder SpecFinder => Group?.SpecFinder ?? Parent?.SpecFinder;

    private SegmentSpecification SegmentSpec => 
      SpecFinder.FindSegmentSpec(Group != null ? Group.VersionIdentifierCode : string.Empty, SegmentId);

    public static int ParseBinarySize(char elementSeparator, string segment, out int binaryStart)
    {
      binaryStart = -1;
      var firstIndex = segment.IndexOf(elementSeparator);
      var segmentId = segment.Substring(0, firstIndex);

      if (segmentId == "BDS")
        firstIndex = segment.IndexOf(elementSeparator, firstIndex + 1);

      var nextIndex = segment.IndexOf(elementSeparator, firstIndex + 1);
      if (nextIndex <= firstIndex)
        return 0;

      var slength = segment.Substring(firstIndex + 1, nextIndex - firstIndex - 1);
      binaryStart = nextIndex + 1;
      int.TryParse(slength, out var length);
      return length;
    }

    protected override void ValidateAgainstSegmentSpecification(string elementId, int elementNumber, string value)
    {
      if (SegmentSpec == null)
        return;

      var spec = SegmentSpec.Elements[elementNumber - 1];
      if (spec == null)
        return;

      if (value.Length == 0 && spec.Required)
        throw new ElementValidationException("Element {0} is required.", elementId, value);

      if (value.Length > 0 && (value.Length < spec.MinLength || spec.MaxLength > 0 && value.Length > spec.MaxLength))
        throw new ElementValidationException(
          "Element {0} cannot contain the value '{1}' because it must be between {2} and {3} characters in length.",
          elementId,
          value,
          spec.MinLength,
          spec.MaxLength);

      switch (spec.Type)
      {
        case ElementDataTypeEnum.Numeric:
          if (!int.TryParse(value, out _))
            throw new ElementValidationException(
              "Element {0} cannot contain the value '{1}' because it is constrained to be an implied decimal.",
              elementId,
              value);

          break;

        case ElementDataTypeEnum.Decimal:
          if (!decimal.TryParse(value, out _))
            throw new ElementValidationException(
              "Element {0} cannot contain the value '{1}' because it is constrained to be a decimal.",
              elementId,
              value);

          break;

        case ElementDataTypeEnum.Identifier:
          if (spec.AllowedListInclusive && 
            spec.AllowedIdentifiers.Count > 0 && 
            spec.AllowedIdentifiers.FirstOrDefault(ai => ai.ID == value) == null)
          {
            var ids = new string[spec.AllowedIdentifiers.Count];
            for (var i = 0; i < spec.AllowedIdentifiers.Count; i++)
              ids[i] = spec.AllowedIdentifiers[i].ID;

            string expected;
            if (ids.Length > 1)
            {
              expected = string.Join(", ", ids, 0, ids.Length - 1);
              expected += " or " + ids[^1];
            }
            else
            {
              expected = ids[0];
            }

            throw new ElementValidationException(
              "Element '{0}' cannot contain the value '{1}'.  Specification restricts this to {2}.",
              elementId,
              value,
              expected);
          }

          break;
      }
    }

    internal virtual string ToX12String(bool addWhitespace = false, int indent = 0, int step = 0)
    {
      var sb = new StringBuilder();
      if (addWhitespace)
        sb.AppendLine();

      sb.Append(string.Empty.PadLeft(indent, ' '));
      sb.Append(SegmentString);

      if (_delimiters.SegmentTerminator != '\r' && _delimiters.SegmentTerminator != '\n')
        sb.Append(_delimiters.SegmentTerminator);

      return sb.ToString();
    }

    public string SerializeToX12(bool addWhitespace, int indent = 0) => ToX12String(addWhitespace, 0, indent).Trim();

    #region IXmlSerializable Members

    XmlSchema IXmlSerializable.GetSchema() => throw new NotImplementedException();

    void IXmlSerializable.ReadXml(XmlReader reader) { throw new NotImplementedException(); }

    void IXmlSerializable.WriteXml(XmlWriter writer) { WriteXml(writer); }

    internal virtual void WriteXml(XmlWriter writer)
    {
      if (string.IsNullOrEmpty(SegmentId))
        return;

      writer.WriteStartElement(SegmentId);
      for (var i = 0; i < _dataElements.Count; i++)
      {
        var elementName = $"{SegmentId}{i + 1:00}";

        var identifiers = new List<AllowedIdentifier>();

        if (SegmentSpec != null && SegmentSpec.Elements.Count > i && !string.IsNullOrEmpty(_dataElements[i]))
        {
          writer.WriteComment(SegmentSpec.Elements[i].Name);
          identifiers = SegmentSpec.Elements[i].AllowedIdentifiers;
        }

        if (_dataElements[i].IndexOf(this._delimiters.SubElementSeparator) < 0 ||
          SegmentId == "BIN" ||
          SegmentId == "BDS")
        {
          writer.WriteStartElement(elementName);
          writer.WriteValue(_dataElements[i]);
          if (SegmentSpec != null &&
            SegmentSpec.Elements.Count > i &&
            SegmentSpec.Elements[i].Type == ElementDataTypeEnum.Identifier)
          {
            var allowedValue = identifiers.FirstOrDefault(ai => ai.ID == _dataElements[i]);
            if (allowedValue != null)
              writer.WriteComment(allowedValue.Description);
          }

          writer.WriteEndElement();
        }
        else
        {
          writer.WriteStartElement(elementName);
          var subElements = _dataElements[i].Split(this._delimiters.SubElementSeparator);
          for (var j = 0; j < subElements.Length; j++)
          {
            var subElementName = $"{elementName}{j + 1:00}";
            writer.WriteStartElement(subElementName);
            writer.WriteValue(subElements[j]);
            if (SegmentSpec != null &&
              SegmentSpec.Elements.Count > i &&
              SegmentSpec.Elements[i].Type == ElementDataTypeEnum.Identifier)
            {
              var allowedValue = identifiers.FirstOrDefault(ai => ai.ID == subElements[j]);
              if (allowedValue != null)
                writer.WriteComment(allowedValue.Description);
            }

            writer.WriteEndElement();
          }

          writer.WriteEndElement();
        }
      }

      writer.WriteEndElement();
    }

    public override string ToString() => SegmentString;

    #endregion
  }

  public class SegmentEqualityComparer : IEqualityComparer<Segment>
  {
    public static SegmentEqualityComparer Default => new();

    public bool Equals(Segment x, Segment y) =>
      (x, y) switch {
        ({ }, { })   => x.Equals(y),
        (null, null) => true,
        _            => false
      };

    public int GetHashCode(Segment obj) => obj.GetHashCode();
  }
}