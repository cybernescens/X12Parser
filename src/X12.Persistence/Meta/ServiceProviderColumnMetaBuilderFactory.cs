using System;
using Microsoft.Extensions.DependencyInjection;

namespace X12.Persistence.Meta
{
  public class ServiceProviderColumnMetaBuilderFactory : IColumnMetaBuilderFactory
  {
    public ServiceProviderColumnMetaBuilderFactory(IServiceProvider serviceProvider)
    {
      ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; }

    public IColumnMetaBuilder Resolve(SegmentType segmentType)
    {
      var genericType = typeof(IColumnMetaBuilderTypeMap<>);
      var typeMapType = genericType.MakeGenericType(segmentType.GetType());
      var typeMap = (IColumnMetaBuilderTypeMap<SegmentType>)ServiceProvider.GetRequiredService(typeMapType);
      return typeMap.Value;
    }

    public IColumnMetaBuilder Resolve<T>()
      where T : SegmentType
    {
      var typeMap = ServiceProvider.GetRequiredService<IColumnMetaBuilderTypeMap<T>>();
      return typeMap.Value;
    }
  }
}