using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using X12.Parsing;

namespace X12.Model
{
  public class DetachedSegment
  {
    internal X12DelimiterSet _delimiters;

    public DetachedSegment(X12DelimiterSet delimiters, string segment)
    {
      _delimiters = delimiters;
      Initialize(segment);
    }

    protected List<string> _dataElements { get; set; }

    public string SegmentId { get; private set; }

    public string SegmentString
    {
      get {
        var sb = new StringBuilder(SegmentId);
        var lastContentIndex = _dataElements.Count - 1;
        for (;lastContentIndex >= 0; lastContentIndex--)
          if (!string.IsNullOrWhiteSpace(_dataElements[lastContentIndex]))
            break;

        for (var i = 0; i <= lastContentIndex; i++)
        {
          sb.Append(_delimiters.ElementSeparator);
          sb.Append(_dataElements[i]);
        }

        return sb.ToString();
      }
    }

    public X12DelimiterSet Delimiters => _delimiters;

    public int ElementCount => _dataElements.Count();

    internal virtual void Initialize(string segment)
    {
      if (segment == null)
        throw new ArgumentNullException(nameof(segment));

      _dataElements = new List<string>();
      var separatorIndex = segment.IndexOf(_delimiters.ElementSeparator);
      if (separatorIndex < 0)
      {
        SegmentId = segment;
        return;
      }

      SegmentId = segment.Substring(0, separatorIndex);
      switch (SegmentId)
      {
        case "BIN": {
          var size = Segment.ParseBinarySize(_delimiters.ElementSeparator, segment, out var binaryStartIndex);
          _dataElements.Add(size.ToString());
          _dataElements.Add(segment.Substring(binaryStartIndex, size));
          return;
        }

        case "BDS": {
          var nextIndex = segment.IndexOf(_delimiters.ElementSeparator, separatorIndex + 1);
          if (nextIndex > separatorIndex + 1)
          {
            _dataElements.Add(segment.Substring(separatorIndex + 1, nextIndex - separatorIndex - 1));

            var size = Segment.ParseBinarySize(_delimiters.ElementSeparator, segment, out var binaryStartIndex);
            _dataElements.Add(size.ToString());
            _dataElements.Add(segment.Substring(binaryStartIndex, size));
          }

          return;
        }

        default: {
          foreach (var element in segment.TrimEnd(_delimiters.SegmentTerminator).Substring(separatorIndex + 1)
            .Split(_delimiters.ElementSeparator))
            _dataElements.Add(element);

          return;
        }
      }
    }

    private void ValidateContentFreeOfDelimiters(string elementId, string value)
    {
      if (value.Contains(_delimiters.SegmentTerminator))
        throw new ElementValidationException(
          "Element {0} cannot contain the value '{1}' with the segment terminator {2}",
          elementId,
          value,
          _delimiters.SegmentTerminator);

      if (value.Contains(_delimiters.ElementSeparator))
        throw new ElementValidationException(
          "Element {0} cannot contain the value '{1}' with the element separator {2}.",
          elementId,
          value,
          _delimiters.ElementSeparator);
    }

    public string GetElement(int elementNumber) => _dataElements.ElementAtOrDefault(elementNumber - 1);

    public decimal? GetDecimalElement(int elementNumber) =>
      decimal.TryParse(GetElement(elementNumber), out var element) ? element : null;

    public int? GetIntElement(int elementNumber) =>
      int.TryParse(GetElement(elementNumber), out var element) ? element : null;

    public long? GetLongElement(int elementNumber) =>
      long.TryParse(GetElement(elementNumber), out var element) ? element : null;

    public DateTime? GetDate8Element(int elementNumber)
    {
      var element = GetElement(elementNumber);
      return element.Length == 8 ? DateTime.ParseExact(element, "yyyyMMdd", null) : null;
    }

    public TimeSpan? GetTimeElement(int elementNumber)
    {
      var element = GetElement(elementNumber);
      return element?.Length switch {
        6 => new TimeSpan(Convert.ToInt32(element[..1]), Convert.ToInt32(element[2..3]), Convert.ToInt32(element[4..5])),
        4 => new TimeSpan(Convert.ToInt32(element[..1]), Convert.ToInt32(element[2..3]), 0),
        _ => null
      };
    }

    public bool GetBooleanElement(int parse) { throw new NotImplementedException(); }

    protected virtual void ValidateAgainstSegmentSpecification(string elementId, int elementNumber, string value)
    {
      // do nothing, this only applies once the segment is attached to an x12 interchange
    }

    public void SetElement(int elementNumber, string value)
    {
      var elementId = $"{SegmentId}{elementNumber:00}";
      ValidateContentFreeOfDelimiters(elementId, value);
      ValidateAgainstSegmentSpecification(elementId, elementNumber, value);
      if (elementNumber > _dataElements.Count)
      {
        for (var i = _dataElements.Count; i < elementNumber; i++)
          _dataElements.Add("");
      }

      _dataElements[elementNumber - 1] = value;
    }

    public void SetElement(int elementNumber, decimal? value) { SetElement(elementNumber, $"{value}"); }

    public void SetElement(int elementNumber, int? value) { SetElement(elementNumber, $"{value}"); }

    public void SetDate8Element(int elementNumber, DateTime? value) { SetElement(elementNumber, $"{value:yyyyMMdd}"); }
  }
}