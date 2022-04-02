using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class CreateEvaluation
    {
        private readonly ApiDbContext _dbContext;

        public CreateEvaluation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Register(Evaluation evaluation)
        {
            evaluation.CreatedAt = DateTimeOffset.UtcNow;

            await _dbContext.Evaluations.AddAsync(evaluation);
            await _dbContext.SaveChangesAsync();
        }
    }
}
