using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace X12.Testing.Samples
{
  public static class Samples
  {
    public static IList<TestCaseData> SampleFiles(Func<string, string> testName)
    {
      var assembly = typeof(SampleCategory).Assembly;
      return assembly.GetManifestResourceNames()
        .SelectMany(
          _ => new[] { ".txt", ".x12" },
          (x, y) => (Name: x, Applicable: x.EndsWith(y, StringComparison.CurrentCultureIgnoreCase) && 
            !x.Contains("_811") && 
            !x.Contains("Unicode", StringComparison.OrdinalIgnoreCase)))
        .Where(x => x.Applicable)
        .Select(x => (File: x.Name, Stream: assembly.GetManifestResourceStream(x.Name)))
        .Select(x => new TestCaseData(x) { TestName = testName(x.File) })
        .ToList();
    }
  }
}