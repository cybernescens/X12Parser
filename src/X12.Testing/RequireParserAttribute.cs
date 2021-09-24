using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using X12.Config;

namespace X12.Testing
{
  public class RequireParserAttribute : TestActionAttribute
  {
    public override void BeforeTest(ITest test)
    {
      if (test.Fixture is not IRequireParser fixture)
        throw new InvalidOperationException($"Expected Fixture to implement {nameof(IRequireParser)}");

      var config = ParserConfiguration.Default.Parser(fixture.ApplySettings);
      fixture.CurrentParserConfiguration = config;
      fixture.Parser = config.CreateParser();
    }

    public override ActionTargets Targets => ActionTargets.Test;
  }
}