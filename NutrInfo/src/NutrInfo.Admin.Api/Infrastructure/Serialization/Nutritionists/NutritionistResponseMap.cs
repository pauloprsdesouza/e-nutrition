using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Models.Nutritionists;

namespace NutrInfo.Admin.Api.Infrastructure.Serialization.Nutritionists
{
    public static class NutritionistResponseMap
    {
        public static NutritionistResponse MapToResponse(this Nutritionist nutritionist)
        {
            return new NutritionistResponse()
            {
                Crn = nutritionist.Crn,
                Name = nutritionist.Name,
                Email = nutritionist.Email,
                Status = nutritionist.Status,
                CreatedAt = nutritionist.CreatedAt,
                UpdatedAt = nutritionist.UpdatedAt
            };
        }
    }
}
