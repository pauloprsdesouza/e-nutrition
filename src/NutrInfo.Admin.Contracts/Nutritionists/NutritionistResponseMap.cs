using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public static class NutritionistResponseMap
    {
        public static NutritionistResponse MapToResponse(this Nutritionist nutritionist)
        {
            return new NutritionistResponse()
            {
                Id = nutritionist.UserId,
                Crn = nutritionist.Crn,
                Cpf = nutritionist.User.Cpf,
                Gender = nutritionist.User.Gender,
                Name = nutritionist.User.Name.ToUpperInvariant(),
                Email = nutritionist.User.Email,
                Status = nutritionist.User.Status,
                BirthDate = nutritionist.User.BirthDate,
                CreatedAt = nutritionist.User.CreatedAt,
                UpdatedAt = nutritionist.User.UpdatedAt
            };
        }
    }
}
