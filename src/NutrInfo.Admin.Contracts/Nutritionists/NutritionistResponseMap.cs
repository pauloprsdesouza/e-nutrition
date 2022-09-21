using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public static class NutritionistResponseMap
    {
        public static NutritionistResponse MapToResponse(this Nutritionist nutritionist)
        {
            return new NutritionistResponse()
            {
                Crn = nutritionist.Crn,
                Name = nutritionist.User.Name.ToUpperInvariant(),
                Email = nutritionist.User.Email,
                Status = nutritionist.User.Status,
                CreatedAt = nutritionist.User.CreatedAt,
                UpdatedAt = nutritionist.User.UpdatedAt
            };
        }
    }
}
