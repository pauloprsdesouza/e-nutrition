namespace NutrInfo.Admin.Contracts.Paginations
{
    public class PaginationResponse
    {
        public int PageSize { get; set; }
        public int CurrentPage {get;set;}
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
