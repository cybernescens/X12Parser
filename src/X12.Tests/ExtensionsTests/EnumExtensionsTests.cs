using System;
using NUnit.Framework;
using X12.Attributes;
using X12.Extensions;

namespace X12.Tests.ExtensionsTests
{
  [TestFixture]
  public class EnumExtensionsTests
  {
    #region ToEnumFromEDIFieldValue Tests

    [Test]
    public void ToEnumFromEDIFieldValue_WhenValidEnumEDIFieldValues_ShouldReturnEnum()
    {
      Assert.AreEqual(TestEDIField.Value1, "101".ToEnumFromEdiFieldValue<TestEDIField>());
      Assert.AreEqual(TestEDIField.Value2, "102".ToEnumFromEdiFieldValue<TestEDIField>());
    }

    #endregion

    private enum TestEDIField
    {
      [EdiFieldValue("101")]
      Value1,

      [EdiFieldValue("102")]
      Value2,

      Value3
    }

    #region EDIFieldValue Tests

    [Test]
    public void EDIFieldValue_WhenAttributeExists_ShouldReturnAttributeValue()
    {
      Assert.AreEqual("101", TestEDIField.Value1.EdiFieldValue());
      Assert.AreEqual("102", TestEDIField.Value2.EdiFieldValue());
    }

    [Test]
    public void EDIFieldValue_WhenNoAttributeExists_ShouldThrowInvalidException()
    {
      // Arrange

      // Act
      InvalidOperationException exceptionThrown = null;
      try
      {
        TestEDIField.Value3.EdiFieldValue();
      }
      catch (InvalidOperationException exception)
      {
        exceptionThrown = exception;
      }

      // Assert
      Assert.IsNotNull(exceptionThrown);
    }

    #endregion
  }
}