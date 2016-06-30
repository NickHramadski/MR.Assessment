using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace MR.Assessment.Business.Tests
{
    [TestClass]
    public class AddsManagerUnitTests
    {
        [TestMethod]
        public async Task GetAllCoverPositionMethodReturnsExpectedDataTest()
        {
            /* 1. Mock WCF call with test data with mixed NumPages and Position values
             * 2. Create new instance of the AddsManager
             * 3. Assert that returned collection has data
             * 4. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */

            var service = new AddsService();
            var data = await service.GetAdds();

            Assert.IsNotNull(data);
        }

        [TestMethod]
        public async Task GetTopFiveByPageCoverageDistinctByBrandMethodReturnsExpectedDataTest()
        {
            var service = new AddsService();
            var data = await service.GetTopFiveByPageCoverageDistinctByBrand();

            Assert.IsNotNull(data);

            /* 1. Mock WCF call with test data with mixed NumPages and Position values
             * 2. Create new instance of the AddsManager
             * 3. Assert that returned collection has data
             * 4. Assert that returned collection has exactly 5 items
             * 5. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */
        }

        //The top five ads by page coverage amount, distinct by brand. Sort by page coverage amount (descending), 
        //then brand name alphabetically.
        //The top five brands by page coverage amount. Keep in mind that a single brand may run multiple ads.
        //Also sorted by page coverage amount (descending), then brand name alphabetically.


      [TestMethod]
        public async Task GetTopFiveByPageCoverageMethodReturnsExpectedDataTest()
        {
            var service = new AddsService();
            var data = await service.GetTopFiveByPageCoverage();

            Assert.IsNotNull(data);

            /* 1. Mock WCF call with test data with mixed NumPages and Position values
             * 2. Create new instance of the AddsManager
             * 3. Assert that returned collection has data
             * 4. Assert that returned collection has exactly 5 items
             * 5. Assert that returned collection contains only "Cover" position and also had at least 50% page coverage
             */
        }

        //IEnumerable<dynamic> GetAllCoverPosition(dynamic filter);

        //IEnumerable<dynamic> GetTopFiveByPageCoverageDistinctByBrand();

        //IEnumerable<dynamic> GetTopFiveByPageCoverage();
    }
}
