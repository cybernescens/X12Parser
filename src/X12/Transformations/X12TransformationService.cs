using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace X12.Transformations
{
  public abstract class X12TransformationService : ITransformationService
  {
    private readonly ITransformationService _preProcessor;

    public X12TransformationService(ITransformationService preProcessor) { _preProcessor = preProcessor; }

    #region ITransformationService Members

    public virtual string Transform(string x12)
    {
      var xml = _preProcessor.Transform(x12);

      var transform = GetTransform();

      var writer = new StringWriter();

      transform.Transform(XmlReader.Create(new StringReader(xml)), GetArguments(), writer);
      return writer.GetStringBuilder().ToString();
    }

    #endregion

    protected abstract XslCompiledTransform GetTransform();

    protected virtual XsltArgumentList GetArguments() => new XsltArgumentList();
  }
}