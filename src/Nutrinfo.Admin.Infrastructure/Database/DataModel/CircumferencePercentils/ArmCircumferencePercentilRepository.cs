using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.CircumferencePercentils
{
    public class ArmCircumferencePercentilRepository : IArmCircumferencePercentilRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<ArmCircumferencePercentil> _percentils;

        public ArmCircumferencePercentilRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _percentils = dbContext.Set<ArmCircumferencePercentil>();
        }

        public async Task<ArmCircumferencePercentil> FindByGenderAndAge(GenderEnum gender, int age)
        {
            return await _percentils.Where(x => x.Gender == gender && x.StartAge <= age && x.EndAge >= age).SingleOrDefaultAsync();
        }
    }
}
