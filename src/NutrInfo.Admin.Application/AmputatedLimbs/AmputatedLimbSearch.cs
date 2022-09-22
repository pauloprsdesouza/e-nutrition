using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Limbs;

namespace NutrInfo.Admin.Application.AmputatedLimbs
{
    public class AmputatedLimbSearch
    {
        private readonly ILimbRepository _repository;

        public AmputatedLimbSearch(ILimbRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Limb>> Find(List<int> amputatedLimbIds)
        {
            return await _repository.FindByIdsIn(amputatedLimbIds);
        }
    }
}
