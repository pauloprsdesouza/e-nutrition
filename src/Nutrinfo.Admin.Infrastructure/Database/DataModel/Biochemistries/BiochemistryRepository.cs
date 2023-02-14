using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Biochemistries;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Biochemistries
{
    public class BiochemistryRepository : IBiochemistryRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Biochemistry> _biochemistries;

        public BiochemistryRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _biochemistries = dbContext.Set<Biochemistry>();
        }

        public async Task<List<Biochemistry>> FindAll()
        {
            return await _biochemistries.ToListAsync();
        }

        public async Task<Biochemistry> FindById(int id)
        {
            return await _biochemistries.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
