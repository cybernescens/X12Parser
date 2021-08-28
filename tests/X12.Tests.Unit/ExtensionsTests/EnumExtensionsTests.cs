using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X12.Attributes;
using X12.Extensions;

namespace X12.Tests.Unit.ExtensionsTests
{
  [TestClass]
  public class EnumExtensionsTests
  {
    #region ToEnumFromEDIFieldValue Tests

    [TestMethod]
    public void ToEnumFromEDIFieldValue_WhenValidEnumEDIFieldValues_ShouldReturnEnum()
    {
      Assert.AreEqual(TestEDIField.Value1, "101".ToEnumFromEDIFieldValue<TestEDIField>());
      Assert.AreEqual(TestEDIField.Value2, "102".ToEnumFromEDIFieldValue<TestEDIField>());
    }

    #endregion

    private enum TestEDIField
    {
      [EDIFieldValue("101")]
      Value1,

      [EDIFieldValue("102")]
      Value2,

      Value3
    }

    #region EDIFieldValue Tests

    [TestMethod]
    public void EDIFieldValue_WhenAttributeExists_ShouldReturnAttributeValue()
    {
      Assert.AreEqual("101", TestEDIField.Value1.EDIFieldValue());
      Assert.AreEqual("102", TestEDIField.Value2.EDIFieldValue());
    }

    [TestMethod]
    public void EDIFieldValue_WhenNoAttributeExists_ShouldThrowInvalidException()
    {
      // Arrange

      // Act
      InvalidOperationException exceptionThrown = null;
      try
      {
        TestEDIField.Value3.EDIFieldValue();
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