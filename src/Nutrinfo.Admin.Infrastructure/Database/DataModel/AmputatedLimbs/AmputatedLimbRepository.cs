using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.AmputatedLimbs;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbs
{
    public class AmputatedLimbRepository : IAmputatedLimbRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<AmputatedLimb> _amputatedLimbs;

        public AmputatedLimbRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _amputatedLimbs = dbContext.Set<AmputatedLimb>();
        }

        public async Task<List<AmputatedLimb>> FindByIdsIn(List<int> amputatedLimbsIds, int patientId)
        {
            return await _amputatedLimbs.Where(x => amputatedLimbsIds.Contains(x.AmputatedLimbPercentageId) && x.PatientId == patientId).ToListAsync();
        }

        public async Task<List<AmputatedLimb>> FindByPatientId(int patientId)
        {
            return await _amputatedLimbs.Where(x => x.PatientId == patientId).ToListAsync();
        }
    }
}
