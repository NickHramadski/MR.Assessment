using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Specific.Ads;
using MR.Assessment.Business.Standard.Foundation;
using MR.Assessment.DataModels.Specific.Ads;
using MR.Assessment.Services.Standard.AdsWcfService;
using MR.Assessment.Services.Standard.Specific.Ads;

namespace MR.Assessment.Business.Standard.Specific.Ads
{
    public class AdsGridManager : BaseGridManager<Ad, AdsFilter, IAdsDataService>, IAdsGridManager
    {
        public AdsGridManager(IAdsDataService service) : base(service)
        {
            
        }

        //private static IList<AdViewModel> ToViewModel(IQueryable<Ad> dataQueryable)
        //{
        //    var result = dataQueryable.Select(ad => new AdViewModel
        //    {
        //        AdId = ad.AdId,
        //        BrandId = ad.Brand.BrandId,
        //        BrandName = ad.Brand.BrandName,
        //        NumPages = ad.NumPages,
        //        Position = ad.Position,
        //    });

        //    return result.ToList();
        //}

        private const string PositionTypeCover = "Cover";
        private const decimal PageCoverageFiftyPercents = 0.5M;
        

        public async Task<IEnumerable<Ad>> GetAllCoverPosition(AdsFilter filter)
        {
            var dataQueryable = await GetAddsPagedAsQueryable(filter);

            dataQueryable = dataQueryable
                .Where(ad => (ad.Position == PositionTypeCover) && (ad.NumPages >= PageCoverageFiftyPercents));

            return dataQueryable;

        }

        public async Task<IEnumerable<Ad>> GetTopFiveByPageCoverageDistinctByBrand()
        {
            var dataQueryable = await Service.GetAll();

            var xxxxxx = from dataItem in dataQueryable
                         group dataItem by dataItem.Brand.BrandId
                into g
                         select new AdGroped { Key = g.Key, Ads = g.ToList() };
            var count1 = xxxxxx.Count();
            var count11 = xxxxxx.Count(ad => ad.Ads.Count > 1);
            var items = xxxxxx.Where(ad => ad.Ads.Count > 1);

            var xxxPPP = dataQueryable.GroupBy(ad => ad.Brand.BrandId, ad => ad).Select(ad => new AdGroped { Key = ad.Key, Ads = ad.ToList() }).ToList();
            var itemsPPP = xxxPPP.Where(ad => ad.Ads.Count > 1);

            dataQueryable = dataQueryable.Distinct(new BrandIdEqualityComparer());

            var xxxXXXX = dataQueryable.GroupBy(ad => ad.Brand.BrandId, ad => ad).Select(ad => new AdGroped { Key = ad.Key, Ads = ad.ToList() }).ToList();
            var itemsXXXXX = xxxPPP.Where(ad => ad.Ads.Count > 1);

            var yyyyy = from dataItem in dataQueryable
                        group dataItem by dataItem.Brand.BrandId
                into g
                        select new AdGroped { Key = g.Key, Ads = g.ToList() };

            //var results = from p in persons
            //              group p.car by p.PersonId into g
            //              select new { PersonId = g.Key, Cars = g.ToList() };

            var count2 = yyyyy.Count();
            var count3 = yyyyy.Count(ad => ad.Ads.Count > 1);

            dataQueryable = dataQueryable.OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.Brand.BrandName)
                .Take(5);

            return dataQueryable;
        }

        public async Task<IEnumerable<Ad>> GetTopFiveByPageCoverage()
        {
            var dataQueryable = await Service.GetAll();

            dataQueryable = dataQueryable
                .Distinct(new BrandIdEqualityComparer())
                .OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.Brand.BrandName)
                .Take(5);

            return dataQueryable;
        }
    }

    //1. A full list of the ads, including all object data(AdId, Brand Id and Name, NumPages, and Position). 
    //   NumPages refers to how many pages the ad takes up in a magazine(0.5 would be a half-page ad) and Position is a string that is either “Page” or “Cover,” describing where in the magazine the ad ran.This list should be sortable and paged.You may use client-side or server-side code to accomplish this. Default sort should be by brand name alphabetically.
    //2. A list of ads which appeared in the “Cover” position and also had at least 50% page coverage. 
    //   This list should also be sortable and paged, and sorted by brand name alphabetically.
    //3. The top five ads by page coverage amount, distinct by brand. Sort by page coverage amount (descending), 
    //   then brand name alphabetically.
    //4. The top five brands by page coverage amount. Keep in mind that a single brand may run multiple ads. 
    //   Also sorted by page coverage amount (descending), then brand name alphabetically.
}
