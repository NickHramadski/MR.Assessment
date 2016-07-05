using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MR.Assessment.DataModels.Foundation;
using MR.Assessment.DataModels.Specific.Ads;

namespace MR.Assessment.Business.Standard.Utils
{
     internal static class DataUtils
    {
        internal static IQueryable<TEntity> GetPagedData<TEntity, TFilter>(IQueryable<TEntity> dataQueryable, TFilter filter = null)
            where TFilter : BaseFilter, new()
        {
            // Init filter (if null) and perform common paging operations 
            if (filter == null)
            {
                filter = new TFilter();
            }

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


        internal static IQueryable<TEntity> Aggregate<TEntity, TFilter>(this IQueryable<TEntity> dataQueryable, TFilter filter = null)
            where TFilter : BaseAggregatedFilter, new()
        {
            // Init filter (if null) and perform common aggregation operations 
            if (filter == null)
            {
                filter = new TFilter();
            }

            return dataQueryable.Take(filter.RecordsCount);
        }
    }
}
