using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.DataModels.Specific.Ads;
using MR.Assessment.DataModels.Specific.Brands;
using MR.Assessment.Services.Standard.AdsWcfService;

namespace MR.Assessment.Business.Standard.Utils
{
    // Automapper is a good enterprize level tool to perform such operations
    internal static class Mapper
    {
        internal static IEnumerable<AdViewModel> MapAds(IQueryable<Ad> dataQueryable)
        {
            return dataQueryable.Select(ad => new AdViewModel
            {
                AdId = ad.AdId,
                BrandId = ad.Brand.BrandId,
                BrandName = ad.Brand.BrandName,
                NumPages = ad.NumPages,
                Position = ad.Position
            });
        }

        internal static IEnumerable<BrandViewModel> MapBrands(IQueryable<Ad> dataQueryable)
        {
            return dataQueryable.Select(ad => new BrandViewModel
            {
                BrandId = ad.Brand.BrandId,
                BrandName = ad.Brand.BrandName
            });
        }

        internal static BrandsAggregatedViewModel MapBrands(IEnumerable<Ad> dataQueryable)
        {
            var adFirst = dataQueryable?.FirstOrDefault();

            return (adFirst == null) ? null : new BrandsAggregatedViewModel
            {
                BrandId = adFirst.Brand.BrandId,
                BrandName = adFirst.Brand.BrandName,
                NumPages = dataQueryable.Sum(ad => ad.NumPages)
            };
        }
    }
}
