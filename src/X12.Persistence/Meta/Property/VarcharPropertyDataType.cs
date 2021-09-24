namespace X12.Persistence.Meta.Property
{
  public class VarcharPropertyDataType : PropertyDataType
  {
    public short Size { get; }
    public bool Unicode { get; }

    public VarcharPropertyDataType(int size, bool unicode = false)
    {
      Size = size > 8000 ? short.MaxValue : (short) size;
      Unicode = unicode;
    }
    
    public override string Render() => $"{(Unicode ? "n" : string.Empty)}varchar({(Size == short.MaxValue ? "max" : Size)})";
  }
}