using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Models.Nutritionists;

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

        public async Task<Nutritionist> Update(int crn, PutNutritionistRequest nutritionistRequest)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionistRequest.MapTo(nutritionist);

            nutritionist.User.UpdatedAt = DateTimeOffset.UtcNow;
            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);

            return await _repository.Update(nutritionist);
        }
    }
}
