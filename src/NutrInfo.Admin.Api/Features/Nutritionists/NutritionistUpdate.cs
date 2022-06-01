using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistUpdate
    {
        private readonly ApiDbContext _dbContext;

        public NutritionistUpdate(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Update(Nutritionist nutritionist)
        {
            nutritionist.User.UpdatedAt = DateTimeOffset.UtcNow;
            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);

            _dbContext.Nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();
        }
    }
}
