using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistRegistration
    {
        private readonly INutritionistRepository _repository;

        public NutritionistRegistration(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistAlreadyExists { get; private set; }

        public async Task<Nutritionist> Register(Nutritionist nutritionist)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionistContext = await nutritionistSearch.Find(nutritionist.Crn);

            if (nutritionistContext != null)
            {
                NutritionistAlreadyExists = true;
                return null;
            }

            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);
            nutritionist.User.Status = UserStatusEnum.Active;
            nutritionist.User.CreatedAt = DateTimeOffset.UtcNow;

            return await _repository.Create(nutritionist);
        }
    }
}
