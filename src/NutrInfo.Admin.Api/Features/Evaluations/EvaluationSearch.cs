using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationSearch
    {
        private readonly ApiDbContext _dbContext;

        public EvaluationSearch(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Find(int id)
        {
            var evaluation = await _dbContext.Evaluations
                                             .WithId(id)
                                             .IncludePatient()
                                             .IncludeUser()
                                             .SingleOrDefaultAsync();

            EvaluationNotFound = evaluation == null;

            return evaluation;
        }
    }
}
