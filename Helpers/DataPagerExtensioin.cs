using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;

namespace SouvenirShop.Helpers
{
    public static class DataPagerExtensioin
    {
        public static BaseSearchDto<TModel> Paginate<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit)
            where TModel : class
        {

            var paged = new BaseSearchDto<TModel>();

            page = (page <= 0) ? 0 : page;

            paged.currentPage = page;
            paged.recordOfPage = limit;

            var totalItemsCountTask = query.Count();

            var startRow = (page) * limit;
            paged.result = query
                       .Skip(startRow)
                       .Take(limit)
                       .ToList();

            paged.totalRecords = totalItemsCountTask;

            return paged;
        }
    }
}