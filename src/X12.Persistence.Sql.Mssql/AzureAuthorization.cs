using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;

namespace X12.Persistence.Sql.Mssql
{
  public abstract class AzureAuthorization
  {
    public abstract ConfidentialClientApplicationBuilder Apply(ConfidentialClientApplicationBuilder ccab);
  }

  public class CertificateAzureAuthorization : AzureAuthorization
  {
    private readonly string _certificate;

    public CertificateAzureAuthorization(string certificate)
    {
      _certificate = certificate;
    }

    public override ConfidentialClientApplicationBuilder Apply(ConfidentialClientApplicationBuilder ccab)
    {
      var cert = ReadCertificate(_certificate);
      if (cert == null)
        throw new X12PersistenceConfigurationException(
          $"Unable to find a certificate with either the name or thumbprint of `{_certificate}`");

      return ccab.WithCertificate(cert);
    }
    
    private static X509Certificate2 ReadCertificate(string thumbprintOrName)
    {
      if (string.IsNullOrWhiteSpace(thumbprintOrName))
        throw new ArgumentException(
          "certificateName should not be empty. Please set the Environment Variable setting `DataDx__Esm_CertificateName`",
          "certificateName");

      X509Certificate2 cert = null;

      using var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
      store.Open(OpenFlags.ReadOnly);
      var certCollection = store.Certificates;

      // Find unexpired certificates.
      var currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
      var byThumbprintCert = certCollection.Find(X509FindType.FindByThumbprint, thumbprintOrName, false);
      cert = byThumbprintCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
      if (cert != null)
        return cert;

      // From the collection of unexpired certificates, find the ones with the correct name.
      var signingCert = currentCerts.Find(X509FindType.FindBySubjectName, thumbprintOrName, false);
      // Return the first certificate in the collection, has the right name and is current.
      cert = signingCert.OfType<X509Certificate2>().OrderByDescending(c => c.NotBefore).FirstOrDefault();
      return cert;
    }
  }
}