using System;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using X12.Persistence.Meta;

namespace X12.Persistence.Sql.Mssql
{
  public class LongHiLoIdentityProvider : HiLoIdentityProvider<long>
  {
    public LongHiLoIdentityProvider(PersistenceOptions options, DbConnectionStringBuilder connectionStringBuilder, ILoggerFactory lf)
      : base(options, connectionStringBuilder, lf) { }

    public override SqlDataType ToSqlDataType() => IntegerSqlType.Big();
    protected override long ConvertResult(object o) => Convert.ToInt64(o);
    protected override bool IsLessThan(long a, long b) => a < b;
    protected override long Increment(ref Ids id) => ++id.NextId;

    protected override void ConfigureId(ref Ids id, long hi, int lo)
    {
      id.NextId = hi;
      id.MaxId = hi + lo;
    }
  }
}