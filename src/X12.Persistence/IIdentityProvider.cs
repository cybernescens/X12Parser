using X12.Persistence.Meta;
using X12.Persistence.Meta.Property;

namespace X12.Persistence
{
  public interface IIdentityProvider
  {
    object NextId(SegmentType segment);
    PropertyDataType ToSqlDataType();
  }
}