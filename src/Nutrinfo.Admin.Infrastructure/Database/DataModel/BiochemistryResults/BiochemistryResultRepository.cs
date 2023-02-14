using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.BiochemistryResults;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.BiochemistryResults
{
    public class BiochemistryResultRepository : IBiochemistryResultRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<BiochemistryResult> _biochemistryResults;

        public BiochemistryResultRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _biochemistryResults = dbContext.Set<BiochemistryResult>();
        }

        public Task<BiochemistryResult> FindByBiochemistry(int biochemistryId)
        {
            return _biochemistryResults.Where(x => x.BiochemistryId == biochemistryId).SingleOrDefaultAsync();
        }
    }
}
