using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using X12.Persistence;
using X12.Persistence.Sql.Mssql;

namespace X12.Testing.Persistence.Mssql
{
  [RequireDatabase]
  [RequirePersistence]
  public interface IRequirePersistenceSessionFactory : IRequireDatabase
  {
    IPersistenceSessionFactory CurrentPersistenceSessionFactory { get; set; }
  }

  public class RequirePersistenceAttribute : TestActionAttribute
  {
    public override void BeforeTest(ITest test)
    {
      if (test.Fixture is not IRequirePersistenceSessionFactory fixture)
        throw new InvalidOperationException($"Expected Fixture to implement {nameof(IRequirePersistenceSessionFactory)}");
      
      fixture.CurrentPersistenceConfiguration
        .BatchPersister(BulkCopyBatchPersisterConfiguration.Default)
        .Session(MssqlPersistenceSessionConfiguration.Default);

      fixture.CurrentPersistenceSessionFactory = fixture.CurrentPersistenceConfiguration.Build();
    }

    public override ActionTargets Targets => ActionTargets.Test;
  }
}