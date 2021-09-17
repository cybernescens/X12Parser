using System.Collections;
using System.Data;

namespace X12.Persistence
{
  public interface ISegmentBatch : IEnumerable
  {
    IDataReader GetDataReader();
    void Add(object o);
    void Clear();
  }
}