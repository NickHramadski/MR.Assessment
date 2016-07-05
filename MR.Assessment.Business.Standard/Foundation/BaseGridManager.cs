using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Foundation;
using MR.Assessment.DataModels.Foundation;

namespace MR.Assessment.Business.Standard.Foundation
{
    public abstract class BaseGridManager<TEntity, TFilter, TDataSource> : IBaseGridManager<TEntity, TFilter>
        where TFilter : BaseFilter, new()
    {
        protected BaseGridManager(TDataSource service)
        {
            Service = service;
        }

        protected TDataSource Service { get; }

        public abstract Task<IEnumerable<TEntity>> GetAll(TFilter filter = null);
    }
}
