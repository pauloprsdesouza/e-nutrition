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
            var nutritionistContext = await nutritionistSearch.Find(nutritionist.User.Cpf);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            var isValid = BCrypt.Net.BCrypt.Verify(nutritionist.Password, nutritionistContext.Password);

            if (!isValid)
            {
                InvalidPassword = true;
                return null;
            }

            return nutritionistContext;
        }
    }
}
