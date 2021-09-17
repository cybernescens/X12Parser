using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using X12.Parsing;
using X12.Parsing.Specification;

namespace X12.Persistence.Config
{
  public class IndexedSegmentConfiguration
  {
    public static readonly IndexedSegmentConfiguration Default = new();

    public static readonly IndexedSegmentConfiguration X820 =
      new("ADX,BPR,DTM,ENT,N1,NM1,REF,RMR,TRN");

    public static readonly IndexedSegmentConfiguration X834 = 
      new("AMT,BGN,COB,DMG,DSB,DTP,HD,INS,LS,LUI,LX,N1,N3,N4,NM1,PER,REF");

    public static readonly IndexedSegmentConfiguration X837 = 
      new ("AMT,BHT,CAS,CL1,CLM,CN1,CR1,CR2,CR3,CR4,CR5,CR6,CR7,CR8,CRC,CTP,DMG,DN1,DN2,DSB,DTP,FRM,HCP,HI,HL,HSD,IMM,K3,LIN,LQ,LX,MEA,MIA,MOA,N1,N3,N4,NM1,NTE,OI,PAT,PER,PRV,PS1,QTY,RAS,REF,SBR,SV1,SV2,SV3,SV4,SV7,SVD,TOO");
    
    private const string FiftyTen = "5010";

    private readonly HashSet<string> _segments = new();

    public IndexedSegmentConfiguration(string segments)
    {
      Parse(segments);
    }

    public IndexedSegmentConfiguration() { }

    public ISpecificationFinder SpecificationFinder { get; set; } = new SpecificationFinder();

    public IndexedSegmentConfiguration Finder(ISpecificationFinder finder)
    {
      SpecificationFinder = finder;
      return this;
    }

    public IndexedSegmentConfiguration Parse(string list)
    {
      foreach (var segment in list.Split(
        new[] { "," },
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        _segments.Add(segment);

      return this;
    }

    public IndexedSegmentConfiguration Add(string item)
    {
      _segments.Add(item);
      return this;
    }

    public IndexedSegmentConfiguration Add(string item, params string[] items)
    {
      _segments.Add(item);
      foreach (var i in items)
        _segments.Add(i);

      return this;
    }

    public IndexedSegmentConfiguration Add(string[] items)
    {
      foreach (var i in items)
        _segments.Add(i);

      return this;
    }

    internal IServiceCollection Apply(IServiceCollection sc)
    {
      if (SpecificationFinder == null)
        throw new X12PersistenceConfigurationException(
          $"`{nameof(IndexedSegmentConfiguration)}` missing configuration option `{nameof(SpecificationFinder)}`.");

      var specs = _segments.Select(x => SpecificationFinder.FindSegmentSpec(FiftyTen, x)).ToList();
      sc.AddSingleton(SpecificationFinder);
      sc.AddSingleton<IList<SegmentSpecification>>(specs);
      return sc;
    }
  }
}