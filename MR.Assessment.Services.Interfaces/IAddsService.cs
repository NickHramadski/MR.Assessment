using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Models;

namespace MR.Assessment.Services.Interfaces
{
    public interface IAddsService
    {
        IEnumerable<dynamic> GetAll(AddsFilter filter);

        IEnumerable<dynamic> GetAllCoverPosition(AddsFilter filter);

        IEnumerable<dynamic> GetTopFiveByPageCoverageDistinctByBrand();

        IEnumerable<dynamic> GetTopFiveByPageCoverage();
    }
}
