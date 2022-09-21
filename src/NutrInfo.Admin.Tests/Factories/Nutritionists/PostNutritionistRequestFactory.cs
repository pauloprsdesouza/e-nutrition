using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Contracts.Nutritionists;

namespace NutrInfo.Admin.Tests.Factories.Nutritionists
{
    public static class PostNutritionistRequestFactory
    {
        public static PostNutritionistRequest To(this PostNutritionistRequest nutritionistRequest, Nutritionist nutritionist)
        {
            nutritionistRequest.Name = nutritionist.User.Name;
            nutritionistRequest.Crn = nutritionist.Crn;
            nutritionistRequest.Cpf = nutritionist.User.Cpf;
            nutritionistRequest.Email = nutritionist.User.Email;
            nutritionistRequest.Password = nutritionist.Password;
            nutritionistRequest.ConfirmPassword = nutritionist.Password;

            return nutritionistRequest;
        }
    }
}
