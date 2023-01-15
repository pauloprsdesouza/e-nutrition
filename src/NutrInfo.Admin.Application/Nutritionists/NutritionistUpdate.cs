using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Contracts.Nutritionists;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistUpdate
    {
        private readonly INutritionistRepository _repository;

        public NutritionistUpdate(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Update(int nutritionistId, PutNutritionistRequest nutritionistRequest)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionist = await nutritionistSearch.Find(nutritionistId);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            if (nutritionistRequest.Street is not null)
            {
                nutritionist.User.Address = new();
            }

            nutritionistRequest.MapTo(nutritionist);

            nutritionist.User.UpdatedAt = DateTimeOffset.UtcNow;
            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);

            return await _repository.Update(nutritionist);
        }
    }
}
