using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

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
            nutritionist.User.Status = UserStatusEnum.Archived;

            _dbContext.Nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();
        }
    }
}
