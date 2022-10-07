using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistDeactivation
    {
        private readonly INutritionistRepository _repository;

        public NutritionistDeactivation(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Deactivate(int nutritionistId)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionist = await nutritionistSearch.Find(nutritionistId);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionist.User.Status = UserStatusEnum.ARCHIVED;

            return await _repository.Update(nutritionist);
        }
    }
}
