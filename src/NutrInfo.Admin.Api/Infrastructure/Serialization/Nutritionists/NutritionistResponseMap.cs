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
                Name = nutritionist.User.Name,
                Email = nutritionist.User.Email,
                Status = nutritionist.User.Status,
                CreatedAt = nutritionist.User.CreatedAt,
                UpdatedAt = nutritionist.User.UpdatedAt
            };
        }
    }
}
