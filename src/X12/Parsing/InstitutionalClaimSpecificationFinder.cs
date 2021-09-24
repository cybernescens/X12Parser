using X12.Parsing.Specification;

namespace X12.Parsing
{
  public class InstitutionalClaimSpecificationFinder : SpecificationFinder
  {
    public override TransactionSpecification FindTransactionSpec(
      string versionCode,
      string transactionSetCode)
    {
      if (transactionSetCode == "837")
      {
        if (versionCode.Contains("5010"))
          return GetSpecification("837I-5010");

        return GetSpecification("837I-4010");
      }

      return base.FindTransactionSpec(versionCode, transactionSetCode);
    }
  }
}