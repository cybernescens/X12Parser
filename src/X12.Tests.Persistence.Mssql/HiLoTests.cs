using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using X12.Persistence;
using X12.Persistence.Config;
using X12.Persistence.Impl;
using X12.Testing.Persistence.Mssql;

namespace X12.Tests.Persistence.Mssql
{
  [TestFixture]
  public class HiLoTests : IRequirePersistenceSessionFactory
  {
    [Test]
    public async Task ThreeSessionsShouldCreateThreeRanges()
    {
      var ids = new ConcurrentBag<long>();
      await Task.WhenAll(
        Enumerable.Range(0, 3).Select(
          _ => Task.Run(
            () => {
              using var session = CurrentPersistenceSessionFactory.OpenSession();
              var ip = ((PersistenceSession)session).IdentityProvider;

              for (var i = 0; i < new Random().Next(0, 10); i++)
                ip.NextId(SegmentType.Interchange);

              ids.Add((long)ip.NextId(SegmentType.Interchange));

              return Task.CompletedTask;
            })));

      Assert.AreEqual(3, ids.Count);
      ids.Should().Contain(x => x >= 1000000 && x <= 1000010);
      ids.Should().Contain(x => x >= 1010000 && x <= 1010010);
      ids.Should().Contain(x => x >= 1020000 && x <= 1020010);
    }

    [Test]
    public async Task ThreeSessionsWithAllExceedingLoSizeShouldCreateRangeOverflow()
    {
      var ids = new ConcurrentBag<long>();
      await Task.WhenAll(
        Enumerable.Range(0, 3).Select(
          _ => Task.Run(
            () => {
              using var session = CurrentPersistenceSessionFactory.OpenSession();
              var ip = ((PersistenceSession)session).IdentityProvider;
              var opts = ((PersistenceSession)session).ServiceProvider
                .GetRequiredService<PersistenceOptions>();

              for (var i = 0; i < opts.BatchSize + new Random().Next(5, 10); i++)
                ip.NextId(SegmentType.Interchange);

              ids.Add((long)ip.NextId(SegmentType.Interchange));

              return Task.CompletedTask;
            })));

      Assert.AreEqual(3, ids.Count);
      ids.Should().Contain(x => x >= 1030000 && x <= 1030010);
      ids.Should().Contain(x => x >= 1040000 && x <= 1040010);
      ids.Should().Contain(x => x >= 1050000 && x <= 1050010);
    }

    public GenerateSegments GenerateSegments { get; set; } = GenerateSegments.None;
    public string DataSource { get; set; }
    public string DatabaseName { get; set; }
    public string Segments { get; set; }
    public string CurrentConnectionString { get; set; }
    public PersistenceConfiguration CurrentPersistenceConfiguration { get; set; }
    public IPersistenceSessionFactory CurrentPersistenceSessionFactory { get; set; }
  }
}