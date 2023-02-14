using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.ClinicalChanges;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.ClinicalChanges
{
    public class ClinicalChangeRepository : IClinicalChangeRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<ClinicalChange> _clinicalChanges;

        public ClinicalChangeRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _clinicalChanges = dbContext.Set<ClinicalChange>();
        }

        public async Task<List<ClinicalChange>> FindAll()
        {
            return await _clinicalChanges.Include(x => x.SignsAndSymptoms).ToListAsync();
        }

        public async Task<ClinicalChange> FindById(int clinicalChangeId)
        {
            return await _clinicalChanges.Where(x => x.Id == clinicalChangeId).SingleOrDefaultAsync();
        }
    }
}
