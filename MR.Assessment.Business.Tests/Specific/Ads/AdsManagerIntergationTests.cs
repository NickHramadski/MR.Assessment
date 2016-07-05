using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MR.Assessment.Services.Standard.Specific.DataSources;

namespace MR.Assessment.Business.Tests.Specific.Ads
{
    [TestClass]
    public class AdsManagerIntergationTests
    {
        [TestMethod]
        public async Task ServiceUpAndRunningAndReturnsDataTest()
        {
            var service = new WcfServiceDataSource();
            var data = await service.GetAll();

            Assert.IsNotNull(data);
        }
    }
}
