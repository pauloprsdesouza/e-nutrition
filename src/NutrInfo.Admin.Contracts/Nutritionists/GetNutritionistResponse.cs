using System.Collections.Generic;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class GetNutritionistResponse
    {
        public IEnumerable<NutritionistResponse> Nutritionists { get; set; }
    }
}
