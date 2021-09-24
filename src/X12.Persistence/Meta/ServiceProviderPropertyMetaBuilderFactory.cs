using System;
using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Meta
{
  public class ServiceProviderPropertyMetaBuilderFactory : IPropertyMetaBuilderFactory
  {
    public ServiceProviderPropertyMetaBuilderFactory(IServiceProvider serviceProvider)
    {
      ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; }

    private IPropertyMetaBuilder Resolve(SegmentType segmentType)
    {
      var genericType = typeof(IPropertyMetaBuilderTypeMap<>);
      var typeMapType = genericType.MakeGenericType(segmentType.GetType());
      var typeMap = (IPropertyMetaBuilderTypeMap<SegmentType>)ServiceProvider.GetRequiredService(typeMapType);
      return typeMap.Value;
    }

    public IPropertyMetaBuilder Resolve<T>(T? @object = null)
      where T : SegmentType =>
      @object switch {
        SegmentType st => Resolve(st),
        _              => ServiceProvider.GetRequiredService<IPropertyMetaBuilderTypeMap<T>>().Value
      };
  }
}