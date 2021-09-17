using System;
using System.IO;
using System.Linq;
using System.Reflection;
using PowerArgs;

namespace X12.X12Parser
{
  public abstract class RelativeDirectoryArgs : IRelativeDirectories
  {
    public void Configure()
    {
      var property = GetType().GetProperties()
        .FirstOrDefault(x => CustomAttributeExtensions.GetCustomAttribute<ArgDirectoryBaseline>((MemberInfo) x) != null);
      
      if (property == null)
        throw new ValidationArgException(
          $"Expected to find property with [ArgDirectoryBaseline] attribute defined on object:" +
          $" `{GetType().FullName}`");

      var baselinedir = GetProperty<string>(property.Name);
      EnsureBaselineDirectory(ref baselinedir);
      SetProperty(property.Name, baselinedir);
      EnsureRelativeDirectories(baselinedir);
    }

    private void EnsureRelativeDirectories(string baselinedir)
    {
      var properties = GetType().GetProperties()
        .Where(x => x.GetCustomAttribute<ArgRelativeDirectory>() != null);

      foreach (var pi in properties)
      {
        var existing = GetProperty<string>(pi.Name);
        if (!string.IsNullOrEmpty(existing))
          continue;

        var attr = pi.GetCustomAttribute<ArgRelativeDirectory>();
        var dir = Path.Combine(baselinedir, attr!.AppendDirectory);
        Directory.CreateDirectory(dir);
        SetProperty(pi.Name, dir);
      }
    }

    private void EnsureBaselineDirectory(ref string baselinedir)
    {
      if (string.IsNullOrEmpty(baselinedir))
        baselinedir = Environment.CurrentDirectory;

      Directory.CreateDirectory(baselinedir);
    }

    private T GetProperty<T>(string propertyName) => (T) GetType().GetProperty(propertyName)!.GetValue(this);

    private void SetProperty<T>(string propertyName, T value)
    {
      GetType().GetProperty(propertyName)!.SetValue(this, value);
    }
  }
}