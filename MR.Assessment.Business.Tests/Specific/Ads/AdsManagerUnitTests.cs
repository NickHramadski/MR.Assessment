using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MR.Assessment.Business.Interfaces.Specific.Ads;
using MR.Assessment.Business.Standard.Specific.Ads;
using MR.Assessment.Business.Tests.Utils;
using MR.Assessment.Services.Standard.Foundation;

namespace MR.Assessment.Business.Tests.Specific.Ads
{
    [TestClass]
    public class AdsManagerUnitTests
    {
        private IAdsGridManager _manager;

        [TestInitialize]
        public void OnTestInit()
        {
            var serviceMock = Mock.Of<IDataSource>(_ => _.GetAll() == TestDataUtils.Ads.AdsListValid.Value);
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
        public async Task GetAllMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetAll();
            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             */
        }

        [TestMethod]
        public async Task GetAllCoverPositionMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetAllCoverPosition();
            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */
        }

        [TestMethod]
        public async Task GetTopFiveByPageCoverageDistinctByBrandMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetTopAdsByPageCoverageDistinctByBrand();
            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection has exactly 5 items
             * 4. Assert that returned collection has valid ads being displayed
             */
        }
    }
}
