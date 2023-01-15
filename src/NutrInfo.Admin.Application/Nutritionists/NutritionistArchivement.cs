using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistArchivement
    {
        private readonly INutritionistRepository _repository;

        public List<string> ValidationErrors { get; private set; }

        public NutritionistArchivement(INutritionistRepository repository)
        {
            _repository = repository;
            ValidationErrors = new();
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Archive(int nutritionistId)
        {
            var nutritionistSearch = new NutritionistSearch(_repository);
            var nutritionist = await nutritionistSearch.Find(nutritionistId);

            if (nutritionist != null)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionist.User.Status = UserStatusEnum.ARCHIVED;

            return await _repository.Create(nutritionist);
        }
    }
}
