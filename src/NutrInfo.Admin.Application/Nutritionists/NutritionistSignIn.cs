using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistSignIn
    {
        private readonly INutritionistRepository _repository;

        public NutritionistSignIn(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistNotFound { get; private set; }
        public bool InvalidPassword { get; private set; }

        public async Task<Nutritionist> Validate(Nutritionist nutritionist)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionistContext = await nutritionistSearch.Find(nutritionist.UserId);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            var password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);

            var isValid = !BCrypt.Net.BCrypt.Verify(password, nutritionistContext.Password);

            if (!isValid)
            {
                InvalidPassword = true;
                return null;
            }

            return nutritionistContext;
        }
    }
}
