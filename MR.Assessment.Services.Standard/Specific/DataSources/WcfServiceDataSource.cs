using System;
using System.Linq;
using System.Threading.Tasks;
using MR.Assessment.Services.Standard.AdsWcfService;
using MR.Assessment.Services.Standard.Exceptions;
using MR.Assessment.Services.Standard.Foundation;

namespace MR.Assessment.Services.Standard.Specific.DataSources
{
    public class WcfServiceDataSource : IDataSource
    {
        private static readonly DateTime StartDate = new DateTime(2011, 1, 1);
        private static readonly DateTime EndDate = new DateTime(2011, 4, 1);

        public async Task<IQueryable<Ad>> GetAll()
        {
            try
            {
                var service = new AdDataServiceClient();
                var data = await service.GetAdDataByDateRangeAsync(StartDate, EndDate);

                return data.AsQueryable();
            }
            catch (Exception exception)
            {
                throw new WcfServiceException(exception);
            }
        }
    }
}
