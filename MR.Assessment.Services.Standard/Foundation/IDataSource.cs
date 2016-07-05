using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Services.Standard.AdsWcfService;

namespace MR.Assessment.Services.Standard.Foundation
{
    public interface IDataSource
    {
        Task<IQueryable<Ad>> GetAll();
    }
}
