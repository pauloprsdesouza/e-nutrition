using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistSearch
    {
        private readonly INutritionistRepository _repository;

        public NutritionistSearch(INutritionistRepository repository)
        {
            _repository = repository;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Find(int crn)
        {
            var nutritionist = await _repository.FindByCrn(crn);

            NutritionistNotFound = nutritionist == null;

            return nutritionist;
        }
    }
}
