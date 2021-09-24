using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using X12.Parsing.Specification;

namespace X12.Parsing
{
  public class SpecificationFinder : ISpecificationFinder
  {
    private static readonly object syncObject = new object();

    private static Dictionary<string, SegmentSpecification> _4010Specification;

    private static Dictionary<string, SegmentSpecification> _5010Specification;

    private static readonly ConcurrentDictionary<string, TransactionSpecification> _specifications;

    static SpecificationFinder() { _specifications = new ConcurrentDictionary<string, TransactionSpecification>(); }

    public virtual TransactionSpecification FindTransactionSpec(
      string versionCode,
      string transactionSetCode)
    {
      return (versionCode, transactionSetCode) switch {
        ("5010", "270") => GetSpecification("270-5010"),
        (_, "270")      => GetSpecification("270-4010"),
        ("5010", "271") => GetSpecification("271-5010"),
        (_, "271")      => GetSpecification("271-4010"),
        (_, "275")      => GetSpecification("275-4050"),
        (_, "276")      => GetSpecification("276-5010"),
        (_, "277")      => GetSpecification("276-5010"),
        ("5010", "278") => GetSpecification("278-5010"),
        (_, "278")      => GetSpecification("278-4010"),
        ("5010", "834") => GetSpecification("834-5010"),
        (_, "834")      => GetSpecification("834-4010"),
        ("5010", "835") => GetSpecification("835-5010"),
        (_, "835")      => GetSpecification("835-4010"),
        ("5010", "837") => GetSpecification("837-5010"),
        (_, "837")      => GetSpecification("837-4010"),
        (_, "875")      => GetSpecification("875-5010"),
        ("5050", "880") => GetSpecification("880-5050"),
        (_, "880")      => GetSpecification("880-4010"),
        (_, "999")      => GetSpecification("999-5010"),
        (_, _)          => Find()
      };

      TransactionSpecification Find()
      {
        var manifests = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        var name = 
          manifests.FirstOrDefault(
            x => x.Contains(transactionSetCode, StringComparison.OrdinalIgnoreCase) &&
              x.Contains(versionCode, StringComparison.OrdinalIgnoreCase)) ??
          manifests.FirstOrDefault(
            x => x.Contains(transactionSetCode, StringComparison.OrdinalIgnoreCase));

        if (string.IsNullOrEmpty(name))
          throw new NotSupportedException($"Transaction Set {transactionSetCode} is not supported.");

        var key = $"{transactionSetCode}-{versionCode}";

        return _specifications.GetOrAdd(
          key,
          _ => {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            using var reader = new StreamReader(stream);
            return TransactionSpecification.Deserialize(reader.ReadToEnd());
          });
      }
    }
    
    public virtual SegmentSpecification FindSegmentSpec(string versionCode, string segmentId)
    {
      if (versionCode.Contains("5010"))
      {
        var idMap5010 = Get5010Spec();
        if (idMap5010.ContainsKey(segmentId))
          return idMap5010[segmentId];
      }

      var idMap4010 = Get4010Spec();
      if (idMap4010.ContainsKey(segmentId))
        return idMap4010[segmentId];

      return null;
    }

    private static Dictionary<string, SegmentSpecification> Get4010Spec()
    {
      lock (syncObject)
      {
        if (_4010Specification == null)
        {
          var specStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("X12.Specifications.Ansi-4010Specification.xml");

          var reader = new StreamReader(specStream);
          var set = SegmentSet.Deserialize(reader.ReadToEnd());
          _4010Specification = new Dictionary<string, SegmentSpecification>();
          foreach (var segment in set.Segments)
          {
            foreach (var element in segment.Elements)
              if (element.Type == ElementDataTypeEnum.Identifier && !string.IsNullOrEmpty(element.QualifierSetRef))
              {
                var qualifierSet = set.QualifierSets.FirstOrDefault(qs => qs.Name == element.QualifierSetRef);
                if (qualifierSet != null)
                  element.AllowedIdentifiers.AddRange(qualifierSet.AllowedIdentifiers);
              }

            _4010Specification.Add(segment.SegmentId, segment);
          }
        }
      }

      return _4010Specification;
    }

    private static Dictionary<string, SegmentSpecification> Get5010Spec()
    {
      lock (syncObject)
      {
        if (_5010Specification == null)
        {
          var specStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("X12.Specifications.Ansi-5010Specification.xml");

          var reader = new StreamReader(specStream);
          var set = SegmentSet.Deserialize(reader.ReadToEnd());
          _5010Specification = new Dictionary<string, SegmentSpecification>();
          foreach (var segment in set.Segments)
          {
            foreach (var element in segment.Elements)
              if (element.Type == ElementDataTypeEnum.Identifier && !string.IsNullOrEmpty(element.QualifierSetRef))
              {
                var qualifierSet = set.QualifierSets.FirstOrDefault(qs => qs.Name == element.QualifierSetRef);
                if (qualifierSet != null)
                {
                  element.AllowedIdentifiers.AddRange(qualifierSet.AllowedIdentifiers);
                  element.QualifierSetId = qualifierSet.Id;
                }
              }

            _5010Specification.Add(segment.SegmentId, segment);
          }
        }
      }

      return _5010Specification;
    }

    internal static TransactionSpecification GetSpecification(string specKey)
    {
      return _specifications.GetOrAdd(
        specKey,
        key => {
          var specStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
            string.Format("X12.Specifications.Ansi-{0}Specification.xml", key));

          return TransactionSpecification.Deserialize(new StreamReader(specStream).ReadToEnd());
        });
    }
  }
}