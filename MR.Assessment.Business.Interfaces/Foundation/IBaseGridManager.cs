using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR.Assessment.Business.Interfaces.Foundation
{
    public interface IBaseGridManager<TEntity, in TFilter>
    {
        Task<IEnumerable<TEntity>> GetAll(TFilter filter);
    }
}
