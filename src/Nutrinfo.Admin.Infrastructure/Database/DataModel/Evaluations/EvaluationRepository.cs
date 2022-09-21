using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Evaluations
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly DbSet<Evaluation> _evaluations;

        public EvaluationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _evaluations = dbContext.Set<Evaluation>();
        }

        public async Task<Evaluation> Create(Evaluation evaluation)
        {
            await _evaluations.AddAsync(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluation;
        }

        public async Task<Evaluation> FindById(int evaluationId)
        {
            return await _evaluations.Where(x => x.Id == evaluationId)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.User)
                                     .SingleOrDefaultAsync();
        }

        public async Task<Evaluation> Update(Evaluation evaluation)
        {
            _evaluations.Update(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluation;
        }
    }
}
