using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TestLib.ServiceReference1;

namespace TestLib
{
    public class AddsService
    {
        private static readonly DateTime StartDate = new DateTime(2011, 1, 1);
        private static readonly DateTime EndDate = new DateTime(2011, 4, 1);

        private const string JsonDataFilePath = "ads.json";

        private static readonly string JsonDataFileDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

        private static readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });

        public async Task<IQueryable<ServiceReference1.Ad>> GetAddsAsQueryable()
        {
            try
            {
                var dataFilePath = Path.Combine(JsonDataFileDirectory, JsonDataFilePath);
                var jsonString = File.ReadAllText(dataFilePath);
                var data = JsonConvert.DeserializeObject<IEnumerable<Ad>>(jsonString);

                //var service = new ServiceReference1.AdDataServiceClient();
                //var data = await service.GetAdDataByDateRangeAsync(StartDate, EndDate);

                return data.AsQueryable();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IQueryable<ServiceReference1.Ad>> GetAddsPagedAsQueryable(AddsFilter filter = null)
        {
            if (filter == null)
            {
                filter = new AddsFilter();
            }

            var dataQueryable = await GetAddsAsQueryable();

            if (filter.PageNumber.HasValue)
            {
                dataQueryable = dataQueryable.Skip(filter.PageNumber.Value);
            }

            if (filter.PageSize.HasValue)
            {
                dataQueryable = dataQueryable.Take(filter.PageSize.Value);
            }

            return dataQueryable;
        }

        private static IList<AddViewModel> ToViewModel(IQueryable<Ad> dataQueryable)
        {
            var result = dataQueryable.Select(ad => new AddViewModel
            {
                AdId = ad.AdId,
                BrandId = ad.Brand.BrandId,
                BrandName = ad.Brand.BrandName,
                NumPages = ad.NumPages,
                Position = ad.Position,
            });

            return result.ToList();
        }

        public async Task<IList<AddViewModel>> GetAdds(AddsFilter filter = null)
        {
            var dataQueryable = await GetAddsPagedAsQueryable(filter);
            return ToViewModel(dataQueryable);
        }

        private const string PositionTypeCover = "Cover";
        private const decimal PageCoverageFiftyPercents = 0.5M;

        public async Task<IList<AddViewModel>> GetAllCoverPosition(AddsFilter filter)
        {
            var dataQueryable = await GetAddsPagedAsQueryable(filter);

            dataQueryable = dataQueryable
                .Where(ad => (ad.Position == PositionTypeCover) && (ad.NumPages >= PageCoverageFiftyPercents));

            return ToViewModel(dataQueryable);

        }

        public class AddGroped
        {
            public int Key { get; set; }
            public IList<Ad> Ads { get; set; }
        }

        public async Task<IList<AddViewModel>> GetTopFiveByPageCoverageDistinctByBrand()
        {
            var dataQueryable = await GetAddsAsQueryable();

            var xxxxxx = from dataItem in dataQueryable
                        group dataItem by dataItem.Brand.BrandId
                into g
                        select new AddGroped { Key = g.Key, Ads = g.ToList() };
            var count1 = xxxxxx.Count();
            var count11 = xxxxxx.Count(ad => ad.Ads.Count > 1);
            var items = xxxxxx.Where(ad => ad.Ads.Count > 1);

            var xxxPPP = dataQueryable.GroupBy(ad => ad.Brand.BrandId, ad => ad).Select(ad => new AddGroped { Key = ad.Key, Ads = ad.ToList()}).ToList();
            var itemsPPP = xxxPPP.Where(ad => ad.Ads.Count > 1);

            dataQueryable = dataQueryable.Distinct(new BrandIdEqualityComparer());

            var xxxXXXX = dataQueryable.GroupBy(ad => ad.Brand.BrandId, ad => ad).Select(ad => new AddGroped { Key = ad.Key, Ads = ad.ToList() }).ToList();
            var itemsXXXXX = xxxPPP.Where(ad => ad.Ads.Count > 1);

            var yyyyy = from dataItem in dataQueryable
                group dataItem by dataItem.Brand.BrandId
                into g
                select new AddGroped {Key = g.Key, Ads = g.ToList()};

                        //var results = from p in persons
                        //              group p.car by p.PersonId into g
                        //              select new { PersonId = g.Key, Cars = g.ToList() };

            var count2 = yyyyy.Count();
            var count3 = yyyyy.Count(ad => ad.Ads.Count > 1);

            dataQueryable = dataQueryable.OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.Brand.BrandName)
                .Take(5);

            return ToViewModel(dataQueryable);
        }

        public async Task<IList<AddViewModel>> GetTopFiveByPageCoverage()
        {
            var dataQueryable = await GetAddsAsQueryable();

            dataQueryable = dataQueryable
                .Distinct(new BrandIdEqualityComparer())
                .OrderByDescending(ad => ad.NumPages)
                .ThenBy(ad => ad.Brand.BrandName)
                .Take(5);

            return ToViewModel(dataQueryable);
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

    public class BaseFilter
    {
        public BaseFilter() : this(20)
        {
            
        }

        public BaseFilter(int? pageSize, int? pageNumber = null)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }

    public class AddsFilter : BaseFilter
    {
        public AddsFilter() : base()
        {

        }

        public AddsFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            
        }
    }

    public class AddViewModel
    {
        public int AdId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public decimal NumPages { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"AdId: '{AdId}' | " +
                   $"BrandId: '{BrandId}' | " +
                   $"BrandName: '{BrandName}' | " +
                   $"NumPages: '{NumPages}' | " +
                   $"Position: '{Position}'";
        }
    }

    public class BrandIdEqualityComparer : IEqualityComparer<Ad>
    {
        public bool Equals(Ad x, Ad y)
        {
            return ((x == null) && (y == null)) ||
                   (
                       (x != null) && (y != null) &&
                       (x.Brand != null) && (y.Brand != null) &&
                       (x.Brand.BrandId == y.Brand.BrandId)
                    );
        }

        public int GetHashCode(Ad obj)
        {
            return obj.Brand.BrandId.GetHashCode();
        }
    }
}
