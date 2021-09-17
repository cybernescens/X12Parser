using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using X12.Model;
using X12.Parsing;
using X12.Validation;

namespace X12.X12Parser.Acknowledge
{
  internal class AcknowledgeX12ParserCommand : ParserCommand
  {
    private readonly AcknowledgeX12Args args;
    private readonly AcknowledgeX12Configuration config;

    public AcknowledgeX12ParserCommand(AcknowledgeX12Args args, AcknowledgeX12Configuration config)
    {
      this.args = args;
      this.config = config;
    }

    public override Task<int> Execute(CancellationToken ct)
    {
      var service = new X12AcknowledgmentService();

      using (var fs = new FileStream(args.InputXml, FileMode.Open, FileAccess.Read))
      {
        using var reader = new X12StreamReader(fs, Encoding.UTF8);
        var firstTrans = reader.ReadNextTransaction();

        if (reader.LastTransactionCode == "837")
        {
          if (reader.TransactionContainsSegment(firstTrans.Transactions[0], "SV2"))
            service = new InstitutionalClaimAcknowledgmentService();

          if (reader.TransactionContainsSegment(firstTrans.Transactions[0], "SV1"))
            service = new X12AcknowledgmentService(new ProfessionalClaimSpecificationFinder());
        }
      }

      using (var fs = new FileStream(args.InputXml, FileMode.Open, FileAccess.Read))
      {
        // Create aknowledgements and identify errors
        var responses = service.AcknowledgeTransactions(fs);

        // Change any acknowledgment codes here to reject transactions with errors
        // CUSTOM BUSINESS LOGIC HERE

        // Transform to outbound interchange for serialization
        var interchange = new Interchange(DateTime.Now, args.IsaControlNumber, true);
        interchange.AuthorInfoQualifier = config.AuthorInfoQualifier;
        interchange.AuthorInfo = config.AuthorInfo;
        interchange.SecurityInfoQualifier = config.SecurityInfoQualifier;
        interchange.SecurityInfo = config.SecurityInfo;
        interchange.InterchangeSenderIdQualifier = config.InterchangeSenderIdQualifier;
        interchange.InterchangeSenderId = config.InterchangeSenderId;
        interchange.InterchangeReceiverIdQualifier = responses.First().SenderIdQualifier;
        interchange.InterchangeReceiverId = responses.First().SenderId;
        interchange.SetElement(12, "00501");

        var group = interchange.AddFunctionGroup("FA", DateTime.Now, args.GsControlNumber);
        group.ApplicationSendersCode = config.InterchangeSenderId;
        group.VersionIdentifierCode = "005010X231A1";

        //group.Add999Transaction(responses);

        // This is a demonstration example only, change true to false to create continous x12 without line feeds.
        File.WriteAllText(args.OutputX12, interchange.SerializeToX12(true));
        return Task.FromResult(0);
      }
    }
  }
}