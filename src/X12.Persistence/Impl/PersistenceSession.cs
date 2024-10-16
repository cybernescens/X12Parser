﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using X12.Model;
using X12.Persistence.Batch;
using X12.Persistence.Meta;
using X12.Persistence.Model;

namespace X12.Persistence.Impl
{
  public class PersistenceSession : IIdentifiablePersistenceSession
  {
    private readonly IPropertyMetaBuilderFactory _metaBuilderFactory;
    private readonly IPersistStartHandler _startHandler;
    private readonly IPersistCompleteHandler _completeHandler;
    private readonly IPersistRollbackHandler _rollbackHandler;
    private readonly Dictionary<SegmentType, ISegmentBatch> _batches;
    private readonly ILogger<PersistenceSession> _logger;

    private bool _disposed;

    internal IServiceProvider ServiceProvider { get; }
    internal IIdentityProvider IdentityProvider { get; }

    public PersistenceSession(
      IPersistenceSessionFactory sessionFactory,
      IPropertyMetaBuilderFactory metaBuilderFactory,
      IIdentityProvider identityProvider,
      IServiceProvider serviceProvider,
      IPersistStartHandler startHandler,
      IPersistCompleteHandler completeHandler,
      IPersistRollbackHandler rollbackHandler,
      ILoggerFactory lf)
    {
      Id = Guid.NewGuid();
      SessionFactory = (PersistenceSessionFactory)sessionFactory;
      ServiceProvider = serviceProvider;
      IdentityProvider = identityProvider;
      _metaBuilderFactory = metaBuilderFactory;
      _startHandler = startHandler;
      _completeHandler = completeHandler;
      _rollbackHandler = rollbackHandler;
      _logger = lf.CreateLogger<PersistenceSession>();

      _batches = new Dictionary<SegmentType, ISegmentBatch> {
        { SegmentType.File, new FileSegmentBatch() },
        { SegmentType.Interchange, new InterchangeSegmentBatch() },
        { SegmentType.FunctionGroup, new FunctionGroupSegmentBatch() },
        { SegmentType.TransactionSet, new TransactionSetSegmentBatch() },
        { SegmentType.Loop, new LoopSegmentBatch() },
        { SegmentType.Segment, new SegmentSegmentBatch() },
        { SegmentType.ParsingError, new ParsingErrorSegmentBatch() }
      };

      foreach (var indexSegment in SessionFactory.IndexedSegmentBatchMap)
        _batches.Add(indexSegment.Key, indexSegment.Value());
    }

    EventHandler<SessionPersistEventArgs>? IIdentifiablePersistenceSession.OnPersistComplete { get; set; }
    internal PersistenceSessionFactory SessionFactory { get; }
    public Guid Id { get; set; }

    public void Persist(IEnumerable<Interchange> interchanges, FileHash sourceFile)
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(PersistenceSession));

      var fileId = AddFile((FileEntity)sourceFile);

      foreach (var interchange in interchanges)
      {
        long pii = 1;
        var isaId = AddInterchange(interchange, fileId);
        AddSegment(interchange, pii, isaId);

        foreach (var isaChild in interchange.Segments)
        {
          ++pii;

          if (isaChild is not FunctionGroup fg)
          {
            AddSegment(isaChild, pii, isaId);
            continue;
          }

          var fgId = AddFunctionalGroup(fg, isaId);
          AddSegment(fg, pii, isaId, fgId);

          foreach (var fgChild in fg.Segments)
          {
            ++pii;

            if (fgChild is not Transaction tx)
            {
              AddSegment(fgChild, pii, isaId, fgId);
              continue;
            }

            var txId = AddTransactionSet(tx, isaId, fgId);
            ProcessLoop(tx, ref pii, isaId, fgId, txId, tx.TransactionSetCode);
          }
        }
      }

      Commit();
    }

    private void Commit()
    {
      if (_disposed)
        throw new ObjectDisposedException(nameof(PersistenceSession));

      using (var conn = SessionFactory.ConnectionManager.CreateConnection())
      {
        _startHandler.OnStart(this, conn);

        try
        {
          for (var i = 0; i < SegmentType.Ordered.Length; i++)
          {
            var st = SegmentType.Ordered[i];
            var cmb = _metaBuilderFactory.Resolve(st);
            using var bp = ServiceProvider.GetRequiredService<IBatchPersister>();
            bp.Configure(conn, st, cmb.Describe(st.EntityType));
            bp.Persist(_batches[st]);
          }

          foreach (var st in SessionFactory.IndexedSegmentBatchMap.Keys)
          {
            var cmb = _metaBuilderFactory.Resolve(st);
            using var bp = ServiceProvider.GetRequiredService<IBatchPersister>();
            bp.Configure(conn, st, cmb.Describe(st.Specification));
            bp.Persist(_batches[st]);
          }
        }
        catch (Exception e)
        {
          _logger.LogWarning(e, $"Exception encountered while persisting batches. Invoking {nameof(IPersistRollbackHandler)}s.");
          _rollbackHandler.OnRollback(this, conn, e);
          throw;
        }

        _completeHandler.OnComplete(this, conn);
      }

      ((IIdentifiablePersistenceSession)this).OnPersistComplete!(this, new SessionPersistEventArgs(Id));
    }

    /// <inheritdoc />
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

      foreach (var batch in _batches.Values)
        batch.Clear();

      _batches.Clear();
      _disposed = true;
    }

    private void ProcessLoop(HierarchicalLoopContainer loop, ref long position, object interchangeId, object functionGroupId, object txid, string txcode, object? parentId = null)
    {
      var loopId = loop switch {
        HierarchicalLoop hl => AddLoop(hl, interchangeId, txid, txcode, parentId),
        Loop l              => AddLoop(l, interchangeId, txid, txcode, parentId),
        Transaction         => null,
        _ => throw new InvalidOperationException(
          $"Loop could not be created for interchange `{interchangeId}` position `{position}`")
      };

      AddSegment(loop, position, interchangeId, functionGroupId, txid, parentId, loopId);

      foreach (var child in loop.Segments)
      {
        ++position;

        switch (child)
        {
          case HierarchicalLoop hl:
            ProcessLoop(hl, ref position, interchangeId, functionGroupId, txid, txcode, loopId);
            continue;
          case HierarchicalLoopContainer container:
            ProcessLoop(container, ref position, interchangeId, functionGroupId, txid, txcode, loopId);
            continue;
          default: 
            AddSegment(child, position, interchangeId, functionGroupId, txid, loopId);
            break;
        }
      }
    }
    
    private object AddLoop(HierarchicalLoop loop, object isaId, object txId, string txCode, object? parentId) =>
      Add(
        SegmentType.Loop,
        loop,
        model => {
          var entity = LoopEntity.ToLoopEntity(isaId, txId, txCode, model);
          entity.ParentLoopId = parentId;
          return entity;
        });

    private object AddLoop(Loop loop, object isaId, object txId, string txCode, object? parentId) =>
      Add(
        SegmentType.Loop,
        loop,
        model => {
          var entity = LoopEntity.ToLoopEntity(isaId, txId, txCode, model);
          entity.ParentLoopId = parentId;
          return entity;
        });

    private object AddTransactionSet(Transaction transaction, object isaId, object fgId) =>
      Add(
        SegmentType.TransactionSet,
        transaction,
        model => {
          var entity = (TransactionSetEntity)model;
          entity.InterchangeId = isaId;
          entity.FunctionalGroupId = fgId;
          return entity;
        }); 

    private object AddFunctionalGroup(FunctionGroup functionGroup, object isaId) =>
      Add(
        SegmentType.FunctionGroup, 
        functionGroup,
        model => {
          var entity = (FunctionalGroupEntity)model;
          entity.InterchangeId = isaId;
          return entity;
        });

    private object AddInterchange(Interchange interchange, object fileId) =>
      Add(
        SegmentType.Interchange, 
        interchange,
        model => {
          var entity = (InterchangeEntity)model;
          entity.FileId = fileId;
          return entity;
        });
    
    private object AddFile(FileEntity file) =>
      Add(
        SegmentType.File,
        file,
        model => model);

    private object AddSegment(
      Segment segment,
      long position,
      object isaId,
      object? fgId = null,
      object? txId = null,
      object? parentLoopId = null,
      object? loopId = null)
    {
      var segmentId = Add(
        SegmentType.Segment,
        segment,
        model => {
          var entity = SegmentEntity.ToSegmentEntity(isaId, position, model);
          entity.FunctionalGroupId = fgId;
          entity.TransactionSetId = txId;
          entity.ParentLoopId = parentLoopId;
          entity.LoopId = loopId;
          return entity;
        });

      if (SessionFactory.IndexedSegmentSegmentTypeMap.TryGetValue(segment.SegmentId, out var indexSegmentSegmentType))
      {
        Add(
          indexSegmentSegmentType!,
          segment,
          model => {
            var entity = new IndexedSegmentEntity(model, isaId, txId!);
            entity.PositionInInterchange = position;
            entity.ParentLoopId = parentLoopId;
            entity.LoopId = loopId;
            return entity;
          }
        );
      }

      return segmentId;
    }

    private object Add<TModel, TEntity>(SegmentType segmentType, TModel model, Func<TModel, TEntity> configure)
      where TEntity : Entity
    {
      var id = IdentityProvider.NextId(segmentType);
      var entity = configure(model);
      entity.Id = id;
      _batches[segmentType].Add(entity);
      return id;
    }
  }
}