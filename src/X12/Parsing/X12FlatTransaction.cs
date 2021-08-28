using System.Collections.Generic;
using System.Text;

namespace X12.Parsing
{
  public class X12FlatTransaction
  {
    internal X12FlatTransaction(string isaSegment, string gsSegment, string transaction)
    {
      IsaSegment = isaSegment;
      GsSegment = gsSegment;
      Transactions = new List<string>();
      Transactions.Add(transaction);
    }

    public string IsaSegment { get; }
    public string GsSegment { get; }
    public List<string> Transactions { get; }

    public int GetSize()
    {
      var size = IsaSegment.Length + GsSegment.Length;
      foreach (var tran in Transactions)
        size += tran.Length;

      return size;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.Append(IsaSegment);
      sb.Append(GsSegment);
      foreach (var tran in Transactions)
        sb.Append(tran);

      var elementDelimiter = IsaSegment[3];
      var segmentDelimiter = IsaSegment[105];
      var isaElements = IsaSegment.Split(elementDelimiter);
      var gsElements = GsSegment.Split(elementDelimiter);

      sb.AppendFormat("GE{1}{2}{1}{3}{0}", segmentDelimiter, elementDelimiter, Transactions.Count, gsElements[6]);
      sb.AppendFormat("IEA{1}1{1}{2}{0}", segmentDelimiter, elementDelimiter, isaElements[13]);
      return sb.ToString();
    }
  }
}