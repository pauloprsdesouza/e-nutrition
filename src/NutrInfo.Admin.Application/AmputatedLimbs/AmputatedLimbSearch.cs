using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.AmputatedLimbs;

namespace NutrInfo.Admin.Application.AmputatedLimbs
{
    public class AmputatedLimbSearch
    {
        private readonly IAmputatedLimbRepository _repository;

        public AmputatedLimbSearch(IAmputatedLimbRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AmputatedLimb>> Find(List<int> amputatedLimbIds, int patientId)
        {
            return await _repository.FindByIdsIn(amputatedLimbIds, patientId);
        }
    }
}
