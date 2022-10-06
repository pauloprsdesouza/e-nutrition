using NutrInfo.Admin.Contracts.Paginations;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class GetNutritionistResponse
    {
        public IEnumerable<NutritionistResponse> Nutritionists { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
