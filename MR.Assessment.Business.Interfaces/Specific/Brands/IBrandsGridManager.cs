using System.Collections.Generic;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Foundation;
using MR.Assessment.DataModels.Specific.Brands;

namespace MR.Assessment.Business.Interfaces.Specific.Brands
{
    public interface IBrandsGridManager : IBaseGridManager<BrandViewModel, BrandsFilter>
    {
        Task<IEnumerable<BrandsAggregatedViewModel>> GetTopBrandsByPageCoverage(BrandsAggregatedFilter filter = null);
    }
}
