using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Pagination;

namespace NutrInfo.Admin.Contracts.Paginations
{
    public class PaginationResponseMap<T>
    {
        public PaginationResponse MapToResponse(PagedList<T> pagedList)
        {
            return new PaginationResponse()
            {
                CurrentPage = pagedList.CurrentPage,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                PageSize = pagedList.PageSize,
            };
        }
    }
}
