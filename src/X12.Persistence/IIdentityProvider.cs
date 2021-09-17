using X12.Persistence.Meta;

namespace X12.Persistence
{
  public interface IIdentityProvider
  {
    object NextId(SegmentType segment);
    SqlDataType ToSqlDataType();
  }
}