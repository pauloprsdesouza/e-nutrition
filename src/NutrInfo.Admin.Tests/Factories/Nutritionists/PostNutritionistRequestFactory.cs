using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Models.Nutritionists;

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
            nutritionistRequest.City = nutritionist.User.Address.City;
            nutritionistRequest.Complement = nutritionist.User.Address.Complement;
            nutritionistRequest.Neighborhood = nutritionist.User.Address.Neighborhood;
            nutritionistRequest.State = nutritionist.User.Address.State;
            nutritionistRequest.Street = nutritionist.User.Address.Street;
            nutritionistRequest.ZipCode = nutritionist.User.Address.ZipCode;
            nutritionistRequest.Number = nutritionist.User.Address.Number;

            return nutritionistRequest;
        }
    }
}
