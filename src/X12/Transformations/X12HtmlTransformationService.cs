using System.Reflection;
using System.Xml;
using System.Xml.Xsl;

namespace X12.Transformations
{
  public class X12HtmlTransformationService : X12TransformationService
  {
    private static XslCompiledTransform _transform;
    private ITransformationService _preProcessor;

    public X12HtmlTransformationService(ITransformationService preProcessor)
      : base(preProcessor)
    {
      _preProcessor = preProcessor;
    }

    protected override XslCompiledTransform GetTransform()
    {
      if (_transform == null)
      {
        _transform = new XslCompiledTransform();
        _transform.Load(
          XmlReader.Create(
            Assembly.GetExecutingAssembly()
              .GetManifestResourceStream("X12.Transformations.X12-XML-to-HTML.xslt")));
      }

      return _transform;
    }
  }
}