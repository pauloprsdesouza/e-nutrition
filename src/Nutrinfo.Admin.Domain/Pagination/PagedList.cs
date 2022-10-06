using Microsoft.EntityFrameworkCore;

namespace Nutrinfo.Admin.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        private const int PAGE_SIZE = 2;
        public PagedList(IEnumerable<T> currentPage, int count, int pageNumber)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PAGE_SIZE);
            PageSize = PAGE_SIZE;
            TotalCount = count;
            AddRange(currentPage);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber) * PAGE_SIZE).Take(PAGE_SIZE).ToListAsync();
            return new PagedList<T>(items, count, pageNumber);
        }
    }
}
