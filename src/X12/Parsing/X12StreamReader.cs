using System;
using System.IO;
using System.Linq;
using System.Text;

namespace X12.Parsing
{
  public class X12StreamReader : IDisposable
  {
    private readonly char[] _ignoredChars;
    private readonly StreamReader _reader;

    public X12StreamReader(Stream stream, Encoding encoding, char[] ignoredChars)
    {
      _reader = new StreamReader(stream, encoding);
      _reader.BaseStream.Seek(0, SeekOrigin.Begin);
      var header = new char[106];
      if (_reader.Read(header, 0, 106) < 106)
        throw new ArgumentException("ISA segment and terminator is expected to be at least 106 characters.");

      Delimiters = new X12DelimiterSet(header);
      CurrentIsaSegment = new string(header);
      _ignoredChars = ignoredChars;
    }

    public X12StreamReader(Stream stream, Encoding encoding)
      : this(stream, encoding, new char[] { }) { }

    public X12DelimiterSet Delimiters { get; }

    public string CurrentIsaSegment { get; private set; }

    public string CurrentGsSegment { get; private set; }

    public string LastTransactionCode { get; private set; }

    public void Dispose() { _reader.Dispose(); }

    public string ReadSegmentId(string segmentString)
    {
      var index = segmentString.IndexOf(Delimiters.ElementSeparator);
      if (index >= 0)
        return segmentString.Substring(0, index);

      return null;
    }

    public string[] SplitSegment(string segmentString)
    {
      var endSegmentIndex = segmentString.IndexOf(Delimiters.SegmentTerminator);
      if (endSegmentIndex >= 0)
        return segmentString.Substring(0, endSegmentIndex).Split(Delimiters.ElementSeparator);

      return segmentString.Split(Delimiters.ElementSeparator);
    }

    public bool TransactionContainsSegment(string transaction, string segmentId)
    {
      var segments = transaction.Split(Delimiters.SegmentTerminator).ToList();

      return segments.Exists(s => s.StartsWith(segmentId + Delimiters.ElementSeparator));
    }

    public string ReadNextSegment()
    {
      var isBinary = false;
      var sb = new StringBuilder();
      var one = new char[1];
      while (_reader.Read(one, 0, 1) == 1)
      {
        if (_ignoredChars.Contains(one[0]))
          continue;

        if (one[0] == Delimiters.SegmentTerminator && sb.ToString().Trim().Length == 0)
          continue;

        if (one[0] == Delimiters.SegmentTerminator)
          break;

        if (one[0] != 0)
          sb.Append(one);

        if (isBinary && one[0] == Delimiters.ElementSeparator)
        {
          var binarySize = 0;
          var elements = sb.ToString().Split(Delimiters.ElementSeparator);
          if (elements[0] == "BIN" && elements.Length >= 2)
            int.TryParse(sb.ToString().Split(Delimiters.ElementSeparator)[1], out binarySize);
          else if (elements[0] == "BDS" && elements.Length >= 3)
            int.TryParse(sb.ToString().Split(Delimiters.ElementSeparator)[2], out binarySize);

          if (binarySize > 0)
          {
            var buffer = new char[binarySize];
            _reader.Read(buffer, 0, binarySize);
            sb.Append(buffer);
            break;
          }
        }

        if (!isBinary &&
          (sb.ToString() == "BIN" + Delimiters.ElementSeparator ||
            sb.ToString() == "BDS" + Delimiters.ElementSeparator))
          isBinary = true;
      }

      return sb.ToString().TrimStart();
    }

    public X12FlatTransaction ReadNextTransaction()
    {
      var segments = new StringBuilder();

      var segmentString = ReadNextSegment();
      var segmentId = ReadSegmentId(segmentString);
      do
      {
        switch (segmentId)
        {
          case "ISA":
            CurrentIsaSegment = segmentString + Delimiters.SegmentTerminator;
            break;
          case "GS":
            CurrentGsSegment = segmentString + Delimiters.SegmentTerminator;
            break;
          case "IEA":
          case "GE":
            break;
          default:
            if (segmentId == "ST")
              LastTransactionCode = SplitSegment(segmentString)[1];

            segments.Append(segmentString);
            segments.Append(Delimiters.SegmentTerminator);
            break;
        }

        segmentString = ReadNextSegment();
        segmentId = ReadSegmentId(segmentString);
      } while (!string.IsNullOrEmpty(segmentString) && segmentId != "SE"); // transaction trailer segment

      return new X12FlatTransaction(
        CurrentIsaSegment,
        CurrentGsSegment,
        segments.ToString());
    }
  }
}