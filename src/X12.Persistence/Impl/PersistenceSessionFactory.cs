using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using X12.Parsing;
using X12.Parsing.Specification;
using X12.Persistence.Batch;
using X12.Persistence.Meta;

namespace X12.Persistence.Impl
{
  internal class PersistenceSessionFactory : IPersistenceSessionFactory
  {
    private readonly IDictionary<Guid, SessionContainer> _sessions =
      new ConcurrentDictionary<Guid, SessionContainer>();

    public PersistenceSessionFactory(
      IServiceProvider serviceProvider,
      IConnectionManager connectionManager,
      IPropertyMetaBuilderFactory metaBuilderFactory,
      IFileHashService fileHashService,
      IList<SegmentSpecification> indexedSegments)
    {
      ServiceProvider = serviceProvider;
      ConnectionManager = connectionManager;
      FileHashService = fileHashService;
      MetaBuilderFactory = metaBuilderFactory;
      var indexedSegmentMetaBuilder = MetaBuilderFactory.Resolve<IndexSegmentSegmentType>();

      for (var i = 0; i < indexedSegments.Count; i++)
      {
        var segment = indexedSegments[i];
        var st = new IndexSegmentSegmentType(segment, i);
        IndexedSegmentSegmentTypeMap.Add(segment.SegmentId, st);
        IndexedSegmentBatchMap.Add(
          st,
          () => new IndexedSegmentBatch(segment.SegmentId, indexedSegmentMetaBuilder.Describe(segment)));
      }
    }

    private IPropertyMetaBuilderFactory MetaBuilderFactory { get; }
    internal IServiceProvider ServiceProvider { get; }
    internal IConnectionManager ConnectionManager { get; }

    internal IDictionary<IndexSegmentSegmentType, Func<IndexedSegmentBatch>> IndexedSegmentBatchMap { get; } =
      new Dictionary<IndexSegmentSegmentType, Func<IndexedSegmentBatch>>();

    internal IDictionary<string, IndexSegmentSegmentType> IndexedSegmentSegmentTypeMap { get; } =
      new Dictionary<string, IndexSegmentSegmentType>();

    public IFileHashService FileHashService { get; }

    public IPersistenceSession OpenPersistence()
    {
      var scope = ServiceProvider.CreateScope();
      var session = scope.ServiceProvider.GetRequiredService<IIdentifiablePersistenceSession>();

      _sessions.TryAdd(session.Id, new SessionContainer(scope, session));
      session.OnPersistComplete += RemoveSession;
      return session;
    }

    public IHydrationSession OpenHydration()
    {
      var scope = ServiceProvider.CreateScope();
      var session = scope.ServiceProvider.GetRequiredService<IIdentifiableHydrationSession>();
      _sessions.TryAdd(session.Id, new SessionContainer(scope, session));
      session.OnHydrateComplete += RemoveSession;
      return session;
    }

    private void RemoveSession(object? _, SessionPersistEventArgs e)
    {
      _sessions.Remove(e.SessionId, out var sc);
      sc?.Dispose();
    }
    
    public IX12Parser CreateParser() => ServiceProvider.GetRequiredService<IX12Parser>();

    private class SessionContainer : IDisposable
    {
      public SessionContainer(IServiceScope scope, IIdentifiableSession session)
      {
        _scope = scope;
        _session = session;
      }

      private readonly IServiceScope _scope;
      private readonly IIdentifiableSession _session;
      private bool _disposed;
      
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    
      private void Dispose(bool disposing)
      {
        if (!disposing)
          return;

        if (_disposed)
          return;

        _scope?.Dispose();
        _session?.Dispose();
        _disposed = true;
      }
    }
  }
}