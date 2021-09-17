using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Meta;

namespace X12.Persistence.Config
{
  public class ColumnMetaBuilderConfiguration
  {
    public static ColumnMetaBuilderConfiguration Default => new();

    private readonly IDictionary<SegmentType, IColumnMetaBuilder> _overrides =
      new Dictionary<SegmentType, IColumnMetaBuilder>();

    public ColumnMetaBuilderConfiguration Override(SegmentType segmentType, IColumnMetaBuilder factory)
    {
      if (_overrides.ContainsKey(segmentType))
        _overrides.Remove(segmentType);

      _overrides.Add(segmentType, factory);
      return this;
    }

    internal IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton<IColumnMetaBuilderFactory, ServiceProviderColumnMetaBuilderFactory>();

      var typeMapGeneric = typeof(IColumnMetaBuilderTypeMap<>);
      var implMapGeneric = typeof(ColumnMetaBuilderTypeMap<>);

      foreach (var kvp in _overrides)
      {
        var mapped = typeMapGeneric.MakeGenericType(kvp.Key.GetType());
        var impl = implMapGeneric.MakeGenericType(kvp.Key.GetType());

        var instance = Activator.CreateInstance(
          impl,
          BindingFlags.Instance | BindingFlags.Public,
          null,
          new[] { kvp.Value });

        sc.AddSingleton(mapped, instance!);
      }

      if (!_overrides.ContainsKey(SegmentType.File))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<FileSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<FileSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.File.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Interchange))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<InterchangeSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<InterchangeSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.Interchange.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.FunctionGroup))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<FunctionGroupSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<FunctionGroupSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.FunctionGroup.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.TransactionSet))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<TransactionSetSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<TransactionSetSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.TransactionSet.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Loop))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<LoopSegmentType>>(
          sp => new ColumnMetaBuilderTypeMap<LoopSegmentType>(
            new AnnotatedColumnMetaBuilder(
              SegmentType.Loop.EntityType,
              sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Segment))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<SegmentSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<SegmentSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.Segment.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }
      
      if (!_overrides.ContainsKey(SegmentType.ParsingError))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<ParsingErrorSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<ParsingErrorSegmentType>(
              new AnnotatedColumnMetaBuilder(
                SegmentType.ParsingError.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.IndexedSegment))
      {
        sc.AddSingleton<IColumnMetaBuilderTypeMap<IndexSegmentSegmentType>>(
          sp =>
            new ColumnMetaBuilderTypeMap<IndexSegmentSegmentType>(
              new SegmentSpecificationColumnMetaBuilder(
                sp.GetRequiredService<IIdentityProvider>())));
      }

      return sc;
    }
  }
}