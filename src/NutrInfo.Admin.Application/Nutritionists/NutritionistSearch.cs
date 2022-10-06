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

        public async Task<Nutritionist> Find(int userId)
        {
            var nutritionist = await _repository.FindById(userId);

            NutritionistNotFound = nutritionist == null;

            return nutritionist;
        }

        public async Task<Nutritionist> Find(string cpf)
        {
            var nutritionist = await _repository.FindByCpf(cpf);

            NutritionistNotFound = nutritionist == null;

            return nutritionist;
        }
    }
}
