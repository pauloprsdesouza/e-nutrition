using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbsPercentage
{
    public class AmputatedLimbPercentageRepository : IAmputatedLimbPercentageRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<AmputatedLimbPercentage> _limbsPercentages;

        public AmputatedLimbPercentageRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _limbsPercentages = dbContext.Set<AmputatedLimbPercentage>();
        }

        public async Task<List<AmputatedLimbPercentage>> FindAll()
        {
            return await _limbsPercentages.ToListAsync();
        }

        public async Task<List<AmputatedLimbPercentage>> FindByIdsIn(List<int> limbsPercentageIds)
        {
            return await _limbsPercentages.Where(x => limbsPercentageIds.Contains(x.Id)).ToListAsync();
        }
    }
}
