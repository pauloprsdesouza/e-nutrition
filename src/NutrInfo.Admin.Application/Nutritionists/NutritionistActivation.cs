using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistActivation
    {
        private readonly INutritionistRepository _repository;

        public NutritionistActivation(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Activate(int nutritionistId)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionist = await nutritionistSearch.Find(nutritionistId);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionist.User.Status = UserStatusEnum.ACTIVE;

            return await _repository.Update(nutritionist);
        }
    }
}
