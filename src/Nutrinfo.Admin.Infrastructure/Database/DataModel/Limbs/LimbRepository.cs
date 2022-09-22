using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Limbs;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Limbs
{
    public class LimbRepository : ILimbRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Limb> _limbs;

        public LimbRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _limbs = dbContext.Set<Limb>();
        }
        public async Task<List<Limb>> FindAll()
        {
            return await _limbs.ToListAsync();
        }

        public async Task<List<Limb>> FindByIdsIn(List<int> limbIds)
        {
            return await _limbs.Where(x => limbIds.Contains(x.Id)).ToListAsync();
        }
    }
}
