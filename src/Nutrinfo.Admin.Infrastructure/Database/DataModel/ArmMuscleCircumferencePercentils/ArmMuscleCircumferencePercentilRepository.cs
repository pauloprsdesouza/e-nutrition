using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.ArmMuscleCircumferencePercentils;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.ArmMuscleCircumferencePercentils
{
    public class ArmMuscleCircumferencePercentilRepository : IArmMuscleCircumferencePercentilRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<ArmMuscleCircumferencePercentil> _armPercentages;

        public ArmMuscleCircumferencePercentilRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _armPercentages = dbContext.Set<ArmMuscleCircumferencePercentil>();
        }

        public async Task<ArmMuscleCircumferencePercentil> FindByGenderAndAgeAndIsAged(GenderEnum gender, int age, bool isAged)
        {
            return await _armPercentages.Where(x => x.Gender == gender && x.StartAge <= age && x.EndAge >= age && x.IsAged == isAged).SingleOrDefaultAsync();
        }
    }
}
