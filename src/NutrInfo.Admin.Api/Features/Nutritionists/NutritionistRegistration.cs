using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistRegistration
    {
        private readonly ApiDbContext _dbContext;

        public NutritionistRegistration(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool NutritionistAlreadyExists { get; private set; }

        public async Task<Nutritionist> Register(Nutritionist nutritionist)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionistContext = await nutritionistSearch.Find(nutritionist.Crn);

            if (nutritionistContext != null)
            {
                NutritionistAlreadyExists = true;
                return null;
            }

            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);
            nutritionist.User.Status = UserStatusEnum.Active;
            nutritionist.User.CreatedAt = DateTimeOffset.UtcNow;

            await _dbContext.Nutritionists.AddAsync(nutritionist);
            await _dbContext.SaveChangesAsync();

            return nutritionist;
        }
    }
}
