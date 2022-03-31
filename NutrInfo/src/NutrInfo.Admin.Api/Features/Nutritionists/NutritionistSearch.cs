using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistSearch
    {
        private readonly ApiDbContext _dbContext;

        public NutritionistSearch(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Find(int crn)
        {
            var nutritionist = await _dbContext.Nutritionists
                                               .WhereCrn(crn)
                                               .SingleOrDefaultAsync();

            NutritionistNotFound = nutritionist == null;

            return nutritionist;
        }
    }
}
