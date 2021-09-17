using System;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using X12.Persistence.Meta;

namespace X12.Persistence.Sql.Mssql
{
  public class IntHiLoIdentityProvider : HiLoIdentityProvider<int>
  {
    public IntHiLoIdentityProvider(PersistenceOptions options, DbConnectionStringBuilder connectionStringBuilder, ILoggerFactory lf) 
      : base(options, connectionStringBuilder, lf) { }

    public override SqlDataType ToSqlDataType() => IntegerSqlType.Regular();
    protected override int ConvertResult(object o) => Convert.ToInt32(o);
    protected override bool IsLessThan(int a, int b) => a < b;
    protected override int Increment(ref Ids id) => ++id.NextId;

    protected override void ConfigureId(ref Ids id, int hi, int lo)
    {
      id.NextId = hi;
      id.MaxId = hi + lo;
    }
  }
}