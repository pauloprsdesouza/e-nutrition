using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.AsciteDegrees
{
    public class AsciteDegreeRepository : IAsciteDegreeRepository
    {

        private readonly ApiDbContext _dbContext;
        private readonly DbSet<AsciteDegree> _ascites;

        public AsciteDegreeRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _ascites = dbContext.Set<AsciteDegree>();
        }

        public async Task<List<AsciteDegree>> FindAll()
        {
            return await _ascites.ToListAsync();
        }

        public async Task<List<AsciteDegree>> FindByIds(List<int> ids)
        {
            return await _ascites.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
