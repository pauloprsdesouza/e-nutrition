using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class DeleteNutritionist
    {
        private readonly ApiDbContext _dbContext;

        public DeleteNutritionist(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Nutritionist nutritionist)
        {
            nutritionist.Status = NutritionistStatusEnum.Archived;

            _dbContext.Nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();
        }
    }
}
