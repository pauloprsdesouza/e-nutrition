using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistRemoval
    {
        private readonly ApiDbContext _dbContext;

        public NutritionistRemoval(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Delete(int crn)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionist.User.Status = UserStatusEnum.Archived;

            _dbContext.Nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();

            return nutritionist;
        }
    }
}
