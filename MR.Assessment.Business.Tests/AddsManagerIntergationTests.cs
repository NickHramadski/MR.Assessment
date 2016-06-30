using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace MR.Assessment.Business.Tests
{
    [TestClass]
    public class AddsManagerIntergationTests
    {
        [TestMethod]
        public async Task ServiceUpAndRunningAndReturnsDataTest()
        {
            var service = new AddsService();
            var data = await service.GetAdds();

            Assert.IsNotNull(data);
        }
    }
}
