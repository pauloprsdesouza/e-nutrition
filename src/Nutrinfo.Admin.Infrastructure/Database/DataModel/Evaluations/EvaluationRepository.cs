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
            var evaluationContext = await _evaluations.AddAsync(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluationContext.Entity;
        }

        public async Task<List<Evaluation>> FindAllMonitoringByNutritionist(int nutritionistId)
        {
            return await _evaluations.Where(x => x.NutritionistId == nutritionistId)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.AmputatedLimbs)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.User)
                                     .Include(x => x.Ascites)
                                     .ToListAsync();
        }

        public async Task<Evaluation> FindById(int evaluationId)
        {
            return await _evaluations.Where(x => x.Id == evaluationId)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.AmputatedLimbs)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.User)
                                     .Include(x => x.Ascites)
                                     .SingleOrDefaultAsync();
        }

        public async Task<List<Evaluation>> FindLastTwoEvaluationsFromPatient(int patientId)
        {
            return await _evaluations.Where(x => x.PatientId == patientId)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.AmputatedLimbs)
                                     .Include(x => x.Patient)
                                     .ThenInclude(x => x.User)
                                     .Include(x => x.Ascites)
                                     .OrderByDescending(x => x.CreatedAt)
                                     .Take(2)
                                     .ToListAsync();
        }

        public async Task<Evaluation> Update(Evaluation evaluation)
        {
            var evaluationContext = _evaluations.Update(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluationContext.Entity;
        }
    }
}
