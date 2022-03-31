using System.Collections.Generic;

namespace NutrInfo.Admin.Api.Models.Nutritionists
{
    public class GetNutritionistResponse
    {
        public IEnumerable<NutritionistResponse> Nutritionists { get; set; }
    }
}
