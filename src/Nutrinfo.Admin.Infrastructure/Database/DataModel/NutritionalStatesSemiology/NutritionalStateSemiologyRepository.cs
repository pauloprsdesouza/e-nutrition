using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.NutritionalStatesSemiology
{
    public class NutritionalStateSemiologyRepository : INutritionalStateSemiologyRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<NutritionalStateSemiology> _nutritionalStates;

        public NutritionalStateSemiologyRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _nutritionalStates = dbContext.Set<NutritionalStateSemiology>();
        }

        public async Task<List<NutritionalStateSemiology>> FindAll()
        {
            return await _nutritionalStates.ToListAsync();
        }

        public async Task<NutritionalStateSemiology> FindById(int id)
        {
            return await _nutritionalStates.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
