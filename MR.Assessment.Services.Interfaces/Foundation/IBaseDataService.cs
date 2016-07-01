using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR.Assessment.Services.Interfaces.Foundation
{
    public interface IBaseDataService<TEntity>
    {
        Task<IQueryable<TEntity>> GetAll();
    }
}
