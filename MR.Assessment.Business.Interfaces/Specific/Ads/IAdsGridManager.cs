using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Foundation;
using MR.Assessment.DataModels.Specific.Ads;
using MR.Assessment.DataModels.Specific.Brands;

namespace MR.Assessment.Business.Interfaces.Specific.Ads
{
    public interface IAdsGridManager : IBaseGridManager<AdViewModel, AdsFilter>
    {
        Task<IEnumerable<AdViewModel>> GetAllCoverPosition(AdsFilter filter = null);

        Task<IEnumerable<AdViewModel>> GetTopAdsByPageCoverageDistinctByBrand(AdsAggregatedFilter filter = null);
    }
}
