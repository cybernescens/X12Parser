using System;

namespace X12.Parsing
{
  public class X12DelimiterSet
  {
    public X12DelimiterSet(char segmentTerminator, char elementSeparator, char subElementSeparator)
    {
      SegmentTerminator = segmentTerminator;
      ElementSeparator = elementSeparator;
      SubElementSeparator = subElementSeparator;
    }

    internal X12DelimiterSet(char[] isaSegmentAndTerminator)
    {
      var prefix = new string(isaSegmentAndTerminator).Substring(0, 3);

      if (isaSegmentAndTerminator.Length < 105)
        throw new ArgumentException("ISA segment and terminator is expected to be exactly 106 characters.");

      if (prefix.ToUpper() != "ISA")
        throw new ArgumentException("First segment must start with ISA");

      ElementSeparator = isaSegmentAndTerminator[3];
      SubElementSeparator = isaSegmentAndTerminator[104];

      if (isaSegmentAndTerminator.Length >= 106)
        SegmentTerminator = isaSegmentAndTerminator[105];

      if (char.IsLetterOrDigit(ElementSeparator))
        throw new ArgumentException(ElementSeparator + " is not a valid element separator in position 4 of the file.");

      if (char.IsLetterOrDigit(SubElementSeparator))
        throw new ArgumentException(
          SubElementSeparator + " is not a valid subelement separator in position 105 of the file.");

      if (char.IsLetterOrDigit(SegmentTerminator))
        throw new ArgumentException(
          SegmentTerminator + " is not a valid segment terminator in position 106 of the file.");
    }

    public char SegmentTerminator { get; }

    public char ElementSeparator { get; }

    public char SubElementSeparator { get; }
  }
}