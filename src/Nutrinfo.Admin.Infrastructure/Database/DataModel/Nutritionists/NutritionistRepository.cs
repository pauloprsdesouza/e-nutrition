using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Nutritionists
{
    public class NutritionistRepository : INutritionistRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Nutritionist> _nutritionists;

        public NutritionistRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _nutritionists = dbContext.Set<Nutritionist>();
        }

        public async Task<Nutritionist> Create(Nutritionist nutritionist)
        {
            await _nutritionists.AddAsync(nutritionist);
            await _dbContext.SaveChangesAsync();

            return nutritionist;
        }

        public async Task<Nutritionist> FindByCrn(int crn)
        {
            return await _nutritionists.Where(x => x.Crn == crn)
                                       .Include(x => x.User)
                                       .SingleOrDefaultAsync();
        }

        public async Task<Nutritionist> FindByName(string name)
        {
            return await _nutritionists.Where(x => x.User.Name == name).SingleOrDefaultAsync();
        }

        public async Task<Nutritionist> Update(Nutritionist nutritionist)
        {
            _nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();

            return nutritionist;
        }
    }
}
