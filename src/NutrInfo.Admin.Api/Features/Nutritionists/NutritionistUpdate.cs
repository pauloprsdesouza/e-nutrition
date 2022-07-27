using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Models.Nutritionists;

namespace NutrInfo.Admin.Api.Features.Nutritionists
{
    public class NutritionistUpdate
    {
        private readonly ApiDbContext _dbContext;

        public NutritionistUpdate(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool NutritionistNotFound { get; private set; }

        public async Task<Nutritionist> Update(int crn, PutNutritionistRequest nutritionistRequest)
        {
            var nutritionistSearch = new NutritionistSearch(_dbContext);
            var nutritionist = await nutritionistSearch.Find(crn);

            if (nutritionistSearch.NutritionistNotFound)
            {
                NutritionistNotFound = true;
                return null;
            }

            nutritionistRequest.MapTo(nutritionist);

            nutritionist.User.UpdatedAt = DateTimeOffset.UtcNow;
            nutritionist.Password = BCrypt.Net.BCrypt.HashPassword(nutritionist.Password);

            _dbContext.Nutritionists.Update(nutritionist);
            await _dbContext.SaveChangesAsync();

            return nutritionist;
        }
    }
}
