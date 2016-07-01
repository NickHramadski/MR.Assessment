using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MR.Assessment.Services.Standard;
using MR.Assessment.Services.Standard.Specific.Ads;

namespace MR.Assessment.Business.Tests
{
    [TestClass]
    public class AddsManagerIntergationTests
    {
        [TestMethod]
        public async Task ServiceUpAndRunningAndReturnsDataTest()
        {
            var service = new AdsDataService();
            var data = await service.GetAll();

            Assert.IsNotNull(data);
        }
    }
}
