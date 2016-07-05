using System.Collections.Generic;
using MR.Assessment.Services.Standard.AdsWcfService;

namespace MR.Assessment.Services.Standard.Generic
{
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