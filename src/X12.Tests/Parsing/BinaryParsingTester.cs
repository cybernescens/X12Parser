﻿using NUnit.Framework;
using X12.Model;

namespace X12.Tests.Parsing
{
  [TestFixture]
  public class BinaryParsingTester
  {
    [Test]
    public void BinSegmentTester()
    {
      int start;
      long size = Segment.ParseBinarySize(
        '*',
        @"BIN*268*<levelone xmlns=""urn:hl7-org:v3/cda"" xmlns:v3dt=""urn:hl7-org:v3/v3dt"" xmlns:xsi=""http://www.w3.org/2001/XMLSchemainstance"" xsi:schemaLocation=""urn:hl7-org:v3/cdalevelone_1.0.attachments.xsd""><clinical_document_header></clinical_document_header><body></body></levelone>~",
        out start);

      Assert.AreEqual(268, size);
      Assert.AreEqual(8, start);
    }

    [Test]
    public void BdsSegmentTester()
    {
      int start;
      long size = Segment.ParseBinarySize('*', "BDS*NOF*18*Binary Data*: Here~", out start);

      Assert.AreEqual(18, size);
      Assert.AreEqual(11, start);
    }
  }
}