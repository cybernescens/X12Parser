using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Serilog;
using X12.Config;
using X12.Parsing;
using X12.Testing;
using X12.Testing.Samples;
using X12.Transformations;

namespace X12.Tests.Parsing
{
  /// <summary>
  ///   Summary description for ParsingTester
  /// </summary>
  [TestFixture]
  //[Ignore("These tests need rewritten as they were utilizing an interesting extension method to TestContext")]
  public class ParsingTester : IRequireParser
  {
    private static readonly Regex BeginningWhitespaceRegex = new(@"^\s*", RegexOptions.Compiled | RegexOptions.Multiline);
    private static readonly Regex NewLineRegex = new(@"(?:\r\n|\r|\n)", RegexOptions.Compiled);

    [Test]
    [TestCaseSource(nameof(SampleFiles))]
    public void Parse_and_reserialize_are_the_same((string File, Stream Stream) file)
    {
      using var reader = new StreamReader(file.Stream, leaveOpen: true);
      var originalX12 = 
        BeginningWhitespaceRegex.Replace(
          NewLineRegex.Replace(reader.ReadToEnd(), Environment.NewLine), string.Empty).TrimEnd();
      //var originalX12 = NewLineRegex.Replace(reader.ReadToEnd(), Environment.NewLine).TrimEnd();

      var interchanges = Parser.Parse(file.Stream);

      var sb = new StringBuilder();
      foreach (var interchange in interchanges)
        sb.AppendLine(interchange.SerializeToX12(true));

      var x12 = sb.ToString().Trim();
      Assert.AreEqual(
        originalX12,
        x12,
        $"Reserialized X12:{Environment.NewLine}{interchanges[0].SerializeToX12(true, 2)}");
    }

    public static IList<TestCaseData> SampleFiles() =>
      Samples.SampleFiles(x => $"Parse_Reserialize-{x.Replace("X12.Testing.Samples.", string.Empty)}");
    
    [Test]
    public void Can_parse_unicode_file()
    {
      var fs = typeof(SampleCategory).Assembly.GetManifestResourceStream(
        "X12.Testing.Samples.INS._837P._5010.08.Unicode.x12");

      var parser = new X12Parser(ParserSettings.Default);
      var interchange = parser.Parse(fs, Encoding.Unicode);
      Trace.Write(interchange.First().Serialize());
    }
    
    public ParserConfiguration CurrentParserConfiguration { get; set; }
    public IX12Parser Parser { get; set; }

    public void ApplySettings(ParserSettings settings)
    {
      settings.ThrowExceptionOnSyntaxErrors = false;
      //settings.OnParserWarning = (_, e) => Log.Warning(e.Message);
    }
  }
}