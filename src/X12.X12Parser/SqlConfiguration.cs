using System;

namespace X12.X12Parser
{
  internal class SqlConfiguration
  {
    public string[] IndexedSegments { get; set; } =
      "AMT,BHT,CLM,DMG,DSB,DTP,HI,HL,LIN,LQ,LX,MEA,N3,N4,NM1,NTE,PAT,PER,PRV,QTY,REF,SBR,SV1,SV2".Split(
        new [] { ',' },
        StringSplitOptions.RemoveEmptyEntries);

    public string IdentityType { get; set; } = typeof(int).FullName;
    public string SchemaName { get; set; } = "x12";
    public int SegmentBatchSize { get; set; } = 10 * 1000;
    public string SqlDateType { get; set; } = "date";
    public string ApplicationId { get; set; }
    public string TenantId { get; set; }
    public string Certificate { get; set; }

    public object GetIdentityInstance() => Activator.CreateInstance(Type.GetType(IdentityType)!);
  }
}