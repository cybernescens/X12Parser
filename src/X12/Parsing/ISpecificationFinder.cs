using X12.Parsing.Specification;

namespace X12.Parsing
{
  public interface ISpecificationFinder
  {
    TransactionSpecification FindTransactionSpec(string versionCode, string transactionSetCode);
    SegmentSpecification FindSegmentSpec(string versionCode, string segmentId);
  }
}