using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.Business.Interfaces.Foundation;
using MR.Assessment.Business.Standard.Specific.Ads;
using MR.Assessment.DataModels.Foundation;
using MR.Assessment.Services.Interfaces.Foundation;

namespace MR.Assessment.Business.Standard.Foundation
{
    public class BaseGridManager<TEntity, TFilter, TDataService> : IBaseGridManager<TEntity, TFilter>
        where TFilter : BaseFilter, new()
        where TDataService : IBaseDataService<TEntity>
    {
        public BaseGridManager(TDataService service)
        {
            Service = service;
        }

        protected TDataService Service { get; }

        public virtual async Task<IEnumerable<TEntity>> GetAll(TFilter filter = null)
        {
            return await GetAddsPagedAsQueryable(filter);
        }

        public async Task<IQueryable<TEntity>> GetAddsPagedAsQueryable(TFilter filter = null)
        {
            if (filter == null)
            {
                filter = new TFilter();
            }

            var dataQueryable = await Service.GetAll();

            if (filter.PageNumber.HasValue)
            {
                dataQueryable = dataQueryable.Skip(filter.PageNumber.Value);
            }

            if (filter.PageSize.HasValue)
            {
                dataQueryable = dataQueryable.Take(filter.PageSize.Value);
            }

            return dataQueryable;
        }
    }
}
