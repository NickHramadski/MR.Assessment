using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Services.Standard.AdsWcfService;
using MR.Assessment.Services.Standard.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MR.Assessment.Services.Standard.Specific.Ads
{
    public class AdsDataService : IAdsDataService
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
