using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MR.Assessment.Web.Services
{
    /// <summary>
    /// Local .net core implementation. For a full implementation see MR.Assessment.Business.Standard class library
    /// </summary>
    public interface IAdsGridManager
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<IEnumerable<dynamic>> GetAllCoverPosition();
        Task<IEnumerable<dynamic>> GetTopAdsByPageCoverageDistinctByBrand();
    }

    /// <summary>
    /// Local .net core implementation. For a full implementation see MR.Assessment.Business.Standard class library
    /// </summary>
    public interface IBrandsGridManager
    {
        Task<IEnumerable<dynamic>> GetTopBrandsByPageCoverage();
    }
}
