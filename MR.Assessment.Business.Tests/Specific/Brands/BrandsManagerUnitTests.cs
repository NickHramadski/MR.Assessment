using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MR.Assessment.Business.Interfaces.Specific.Brands;
using MR.Assessment.Business.Standard.Specific.Brands;
using MR.Assessment.Business.Tests.Utils;
using MR.Assessment.Services.Standard.Foundation;

namespace MR.Assessment.Business.Tests.Specific.Brands
{
    [TestClass]
    public class BrandsManagerUnitTests
    {
        private IBrandsGridManager _manager;

        [TestInitialize]
        public void OnTestInit()
        {
            var serviceMock = Mock.Of<IDataSource>(_ => _.GetAll() == TestDataUtils.Ads.AdsListValid.Value);
            _manager = new BrandsGridManager(serviceMock);

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
        public async Task GetTopFiveByPageCoverageMethodReturnsExpectedDataTest()
        {
            var data = await _manager.GetTopBrandsByPageCoverage();
            Assert.IsNotNull(data);

            /* 1. Retrieve data to test
             * 2. Assert that returned collection has data
             * 3. Assert that returned collection has exactly 5 items
             * 4. Assert that returned collection has valid brands being displayed
             */
        }
    }
}
