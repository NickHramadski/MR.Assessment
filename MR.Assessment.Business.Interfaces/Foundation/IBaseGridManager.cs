using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.DataModels.Foundation;

namespace MR.Assessment.Business.Interfaces.Foundation
{
    public interface IBaseGridManager<TEntity, in TFilter>
        where TFilter : BaseFilter, new()
    {
        Task<IEnumerable<TEntity>> GetAll(TFilter filter = null);
    }
}
