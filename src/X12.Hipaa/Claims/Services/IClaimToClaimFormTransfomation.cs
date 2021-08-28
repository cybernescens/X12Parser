using System.Collections.Generic;
using X12.Hipaa.Claims.Forms;

namespace X12.Hipaa.Claims.Services
{
  public interface IClaimToClaimFormTransfomation
  {
    List<FormPage> TransformClaimToClaimFormFoXml(Claim claim);
  }
}