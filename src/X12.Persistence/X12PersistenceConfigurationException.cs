using System;

namespace X12.Persistence
{
  public class X12PersistenceConfigurationException : Exception
  {
    public X12PersistenceConfigurationException(string msg) : base(msg) { }
  }
}