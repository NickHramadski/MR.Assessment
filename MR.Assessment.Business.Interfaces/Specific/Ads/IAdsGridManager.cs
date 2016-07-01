using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Foundation;
using MR.Assessment.DataModels.Specific.Ads;
using MR.Assessment.Services.Standard.AdsWcfService;

namespace MR.Assessment.Business.Interfaces.Specific.Ads
{
    public interface IAdsGridManager : IBaseGridManager<Ad, AdsFilter>
    {
        Task<IEnumerable<Ad>> GetAllCoverPosition(AdsFilter filter = null);

        Task<IEnumerable<Ad>> GetTopFiveByPageCoverageDistinctByBrand();

        Task<IEnumerable<Ad>> GetTopFiveByPageCoverage();
    }
}
