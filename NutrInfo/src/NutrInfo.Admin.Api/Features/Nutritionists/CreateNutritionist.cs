using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class CreateNutritionist
    {
        private readonly ApiDbContext _dbContext;

        public CreateNutritionist(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Register(Nutritionist nutritionist)
        {
            nutritionist.User.CreatedAt = DateTimeOffset.UtcNow;
            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);
            nutritionist.User.Status = UserStatusEnum.Active;

            await _dbContext.Nutritionists.AddAsync(nutritionist);
            await _dbContext.SaveChangesAsync();
        }
    }
}
