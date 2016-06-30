using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR.Assessment.Business.Interfaces
{
    public interface IAddsManager
    {
        IEnumerable<dynamic> GetAll(dynamic filter);

        IEnumerable<dynamic> GetAllCoverPosition(dynamic filter);

        IEnumerable<dynamic> GetTopFiveByPageCoverageDistinctByBrand();

        IEnumerable<dynamic> GetTopFiveByPageCoverage();
    }
}
