using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Specific.Ads;
using MR.Assessment.Business.Interfaces.Specific.Brands;
using MR.Assessment.Business.Standard.Foundation;
using MR.Assessment.Business.Standard.Utils;
using MR.Assessment.DataModels.Specific.Brands;
using MR.Assessment.Services.Standard.Foundation;

namespace MR.Assessment.Business.Standard.Specific.Brands
{
    public class BrandsGridManager : BaseGridManager<BrandViewModel, BrandsFilter, IDataSource>, IBrandsGridManager
    {
        public BrandsGridManager(IDataSource service) : base(service)
        {
            
        }

        /// <summary>
        /// The top five brands by page coverage amount. Keep in mind that a single brand may run multiple ads.
        /// Also sorted by page coverage amount (descending), then brand name alphabetically.
        /// </summary>
        public async Task<IEnumerable<BrandsAggregatedViewModel>> GetTopBrandsByPageCoverage(BrandsAggregatedFilter filter = null)
        {
            var dataQueryable = await Service.GetAll();

            var dataGrouped = dataQueryable
                .GroupBy(ad => ad.Brand.BrandId)
                .Select(g => Mapper.MapBrands(g))
                .OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.BrandName)
                .Aggregate(filter);

            return dataGrouped;
        }

        #region BaseGridManager Members

        public override async Task<IEnumerable<BrandViewModel>> GetAll(BrandsFilter filter = null)
        {
            // Out of scope for current assessment
            var dataQueryable = await Service.GetAll();
            var dataPaged = DataUtils.GetPagedData(dataQueryable, filter);
            return Mapper.MapBrands(dataPaged);
        }

        #endregion
    }
}
