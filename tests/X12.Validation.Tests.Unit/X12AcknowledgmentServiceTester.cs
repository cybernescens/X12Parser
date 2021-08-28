﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X12.Parsing.Model;

namespace X12.Validation.Tests.Unit
{
  [TestClass]
  public class X12AcknowledgmentServiceTester
  {
    private Stream GetEdi(string filename) =>
      Assembly.GetExecutingAssembly()
        .GetManifestResourceStream("X12.Validation.Tests.Unit.Data." + filename);

    [TestMethod]
    public void Acknowledge837ITest()
    {
      var service = new InstitutionalClaimAcknowledgmentService();
      var responses = service.AcknowledgeTransactions(GetEdi("837I_4010_Batch1.txt"));

      Assert.AreEqual(1, responses.Count);
      var response = responses.First();
      Assert.AreEqual("612200041", response.GroupControlNumber);
      Assert.AreEqual(54, response.TransactionSetResponses.Count);

      var interchange = new Interchange(DateTime.Now, 1, true);
      var group = interchange.AddFunctionGroup("FA", DateTime.Now, 1);
      group.VersionIdentifierCode = "005010X231A1";
      group.Add999Transaction(responses);

      Trace.WriteLine(interchange.SerializeToX12(true));
    }
  }
}