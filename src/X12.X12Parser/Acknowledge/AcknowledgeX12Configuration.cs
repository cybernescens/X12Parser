namespace X12.X12Parser.Acknowledge
{
  internal class AcknowledgeX12Configuration
  {
    public string AuthorInfoQualifier { get; set; }
    public string AuthorInfo { get; set; }
    public string SecurityInfoQualifier { get; set; }
    public string SecurityInfo { get; set; }
    public string InterchangeSenderIdQualifier { get; set; }
    public string InterchangeSenderId { get; set; }
  }
}