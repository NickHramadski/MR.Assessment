using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MR.Assessment.Business.Interfaces.Specific.Ads;
using MR.Assessment.Business.Standard.Specific.Ads;
using MR.Assessment.Business.Tests.Utils;
using MR.Assessment.Services.Standard.Specific.Ads;
using Moq;

namespace MR.Assessment.Business.Tests
{
    [TestClass]
    public class AddsManagerUnitTests
    {
        private IAdsGridManager _manager = null;

        [TestInitialize]
        public void OnTestInit()
        {
            var serviceMock = Mock.Of<IAdsDataService>(_ => _.GetAll() == TestDataUtils.Ads.AdsListValid.Value);
            _manager = new AdsGridManager(serviceMock);

            /* 1. Mock or fake WCF call with test data with mixed NumPages and Position values
             * 2. Create new instance of the AddsManager
             */
        }

        [TestCleanup]
        public void OnTestCleanup()
        {
            _manager = null;
            /* 1. Cleanup test data
             */
        }

        [TestMethod]
        public async Task GetAllCoverPositionMethodReturnsExpectedDataTest()
        {
            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */

            var data = await _manager.GetAllCoverPosition();

            Assert.IsNotNull(data);
        }

        [TestMethod]
        public async Task GetTopFiveByPageCoverageDistinctByBrandMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetTopFiveByPageCoverageDistinctByBrand();

            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection has exactly 5 items
             * 4. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */
        }

        [TestMethod]
        public async Task GetTopFiveByPageCoverageMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetTopFiveByPageCoverage();

            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection has exactly 5 items
             * 4. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */
        }
    }
}
