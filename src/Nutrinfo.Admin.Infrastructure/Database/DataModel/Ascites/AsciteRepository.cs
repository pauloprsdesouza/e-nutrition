using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Ascites;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.Ascites
{
    public class AsciteRepository : IAsciteRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Ascite> _ascites;

        public AsciteRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _ascites = dbContext.Set<Ascite>();
        }

        public async Task<List<Ascite>> FindByIdsIn(List<int> asciteIds)
        {
            return await _ascites.Where(x => asciteIds.Contains(x.AsciteDegreeId))
                                        .Include(x => x.AsciteDegree)
                                        .ToListAsync();
        }

        public async Task<List<Ascite>> FindByPatientId(int patientId)
        {
            return await _ascites.Where(x => x.Evaluation.PatientId == patientId).ToListAsync();
        }
    }
}
