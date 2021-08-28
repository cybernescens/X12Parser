using X12.Parsing.Specification;

namespace X12.Parsing
{
  public class DentalClaimSpecificationFinder : SpecificationFinder
  {
    public override TransactionSpecification FindTransactionSpec(
      string functionalCode,
      string versionCode,
      string transactionSetCode)
    {
      if (transactionSetCode == "837")
        //if (versionCode.Contains("5010"))
        //    return SpecificationFinder.GetSpecification("837D-5010");
        //else
        return GetSpecification("837D-4010");

      return base.FindTransactionSpec(functionalCode, versionCode, transactionSetCode);
    }
  }
}