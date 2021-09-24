using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using X12.Persistence.Meta;

namespace X12.Persistence.Config
{
  public class PropertyMetaBuilderConfiguration
  {
    public static PropertyMetaBuilderConfiguration Default => new();

    private readonly IDictionary<SegmentType, IPropertyMetaBuilder> _overrides =
      new Dictionary<SegmentType, IPropertyMetaBuilder>();

    public PropertyMetaBuilderConfiguration Override(SegmentType segmentType, IPropertyMetaBuilder factory)
    {
      if (_overrides.ContainsKey(segmentType))
        _overrides.Remove(segmentType);

      _overrides.Add(segmentType, factory);
      return this;
    }

    internal IServiceCollection Apply(IServiceCollection sc)
    {
      sc.AddSingleton<IPropertyMetaBuilderFactory, ServiceProviderPropertyMetaBuilderFactory>();

      var typeMapGeneric = typeof(IPropertyMetaBuilderTypeMap<>);
      var implMapGeneric = typeof(PropertyMetaBuilderTypeMap<>);

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
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<FileSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<FileSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.File.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Interchange))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<InterchangeSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<InterchangeSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.Interchange.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.FunctionGroup))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<FunctionGroupSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<FunctionGroupSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.FunctionGroup.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.TransactionSet))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<TransactionSetSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<TransactionSetSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.TransactionSet.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Loop))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<LoopSegmentType>>(
          sp => new PropertyMetaBuilderTypeMap<LoopSegmentType>(
            new AnnotatedPropertyMetaBuilder(
              SegmentType.Loop.EntityType,
              sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.Segment))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<SegmentSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<SegmentSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.Segment.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }
      
      if (!_overrides.ContainsKey(SegmentType.ParsingError))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<ParsingErrorSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<ParsingErrorSegmentType>(
              new AnnotatedPropertyMetaBuilder(
                SegmentType.ParsingError.EntityType,
                sp.GetRequiredService<IIdentityProvider>())));
      }

      if (!_overrides.ContainsKey(SegmentType.IndexedSegment))
      {
        sc.AddSingleton<IPropertyMetaBuilderTypeMap<IndexSegmentSegmentType>>(
          sp =>
            new PropertyMetaBuilderTypeMap<IndexSegmentSegmentType>(
              new SegmentSpecificationPropertyMetaBuilder(
                sp.GetRequiredService<IIdentityProvider>())));
      }

      return sc;
    }
  }
}