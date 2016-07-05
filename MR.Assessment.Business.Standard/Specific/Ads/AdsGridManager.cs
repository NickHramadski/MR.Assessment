using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Specific.Ads;
using MR.Assessment.Business.Standard.Foundation;
using MR.Assessment.Business.Standard.Utils;
using MR.Assessment.DataModels.Specific.Ads;
using MR.Assessment.DataModels.Specific.Brands;
using MR.Assessment.Services.Standard.Foundation;
using MR.Assessment.Services.Standard.Generic;

namespace MR.Assessment.Business.Standard.Specific.Ads
{
    public class AdsGridManager : BaseGridManager<AdViewModel, AdsFilter, IDataSource>, IAdsGridManager
    {
        private const string PositionTypeCover = "Cover";
        private const decimal PageCoverageFiftyPercents = 0.5M;

        public AdsGridManager(IDataSource service) : base(service)
        {
            
        }

        /// <summary>
        /// A full list of the ads, including all object data(AdId, Brand Id and Name, NumPages, and Position). 
        /// NumPages refers to how many pages the ad takes up in a magazine(0.5 would be a half-page ad) and Position is 
        /// a string that is either “Page” or “Cover,” describing where in the magazine the ad ran.This list should be
        /// sortable and paged.You may use client-side or server-side code to accomplish this. Default sort should be by
        /// brand name alphabetically.
        /// </summary>
        public override async Task<IEnumerable<AdViewModel>> GetAll(AdsFilter filter = null)
        {
            var dataQueryable = await Service.GetAll();
            var dataPaged = DataUtils.GetPagedData(dataQueryable, filter);
            return Mapper.MapAds(dataPaged);
        }

        /// <summary>
        /// A list of ads which appeared in the “Cover” position and also had at least 50% page coverage.
        /// This list should also be sortable and paged, and sorted by brand name alphabetically.
        /// </summary>
        public async Task<IEnumerable<AdViewModel>> GetAllCoverPosition(AdsFilter filter = null)
        {
            var dataQueryable = await Service.GetAll();

            dataQueryable = dataQueryable
                .Where(ad => (ad.Position == PositionTypeCover) && (ad.NumPages >= PageCoverageFiftyPercents));

            var dataPaged = DataUtils.GetPagedData(dataQueryable, filter);

            return Mapper.MapAds(dataPaged);

        }

        /// <summary>
        /// The top five ads by page coverage amount, distinct by brand. Sort by page coverage amount (descending),
        /// then brand name alphabetically.
        /// </summary>
        public async Task<IEnumerable<AdViewModel>> GetTopAdsByPageCoverageDistinctByBrand(AdsAggregatedFilter filter = null)
        {
            var dataQueryable = await Service.GetAll();

            dataQueryable = dataQueryable
                .OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.Brand.BrandName)
                .Distinct(new BrandIdEqualityComparer())
                .Aggregate(filter);

            return Mapper.MapAds(dataQueryable);
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
    }
}
