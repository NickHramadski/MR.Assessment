using System.Collections.Generic;
using MR.Assessment.Services.Standard.AdsWcfService;

namespace MR.Assessment.Services.Standard.Specific.Ads
{
    public class AdGroped
    {
        public int Key { get; set; }
        public IList<Ad> Ads { get; set; }
    }
}