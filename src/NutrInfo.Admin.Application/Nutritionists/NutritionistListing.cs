using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Application.Nutritionists
{
    public class NutritionistListing
    {
        private readonly INutritionistRepository _nutritionistRepository;

        public NutritionistListing(INutritionistRepository nutritionistRepository)
        {
            _nutritionistRepository = nutritionistRepository;
        }

        public async Task<List<Nutritionist>> List(int page) {
            //_nutritionistRepository.FindAll()

            return null;
        }
    }
}
