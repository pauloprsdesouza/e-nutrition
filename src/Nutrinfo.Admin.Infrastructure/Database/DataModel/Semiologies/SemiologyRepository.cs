using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Semiologies;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Semiologies
{
    public class SemiologyRepository : ISemiologyRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Semiology> _semiologies;

        public SemiologyRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _semiologies = dbContext.Set<Semiology>();
        }

        public async Task<Dictionary<string, List<Semiology>>> FindAllGrouped()
        {
            var semiologiesGrouped = new Dictionary<string, List<Semiology>>();

            var subcutaneousFatSemiologies = await _semiologies.Where(x => x.Group == SemiologyGroupEnum.SUBCUTANEOUS_FAT)
                                                               .Include(x => x.NutritionalStates)
                                                               .ToListAsync();

            var muscleMassSemiologies = await _semiologies.Where(x => x.Group == SemiologyGroupEnum.MUSCLE_MASS)
                                                          .Include(x => x.NutritionalStates)
                                                          .ToListAsync();

            semiologiesGrouped.Add("Gordura Subcutânea", subcutaneousFatSemiologies);
            semiologiesGrouped.Add("Massa Muscular", muscleMassSemiologies);

            return semiologiesGrouped;
        }
    }
}
