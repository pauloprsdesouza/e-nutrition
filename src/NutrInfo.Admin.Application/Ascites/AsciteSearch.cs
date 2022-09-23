using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Ascites;

namespace NutrInfo.Admin.Application.Ascites
{
    public class AsciteSearch
    {
        private readonly IAsciteRepository _repository;

        public AsciteSearch(IAsciteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Ascite>> Find(List<int> asciteIds)
        {
            return await _repository.FindByIdsIn(asciteIds);
        }
    }
}
