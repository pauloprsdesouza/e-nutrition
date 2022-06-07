using System;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Features.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationRegistration
    {
        private readonly ApiDbContext _dbContext;

        public EvaluationRegistration(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Evaluation> Register(Evaluation evaluation)
        {
            var patientSearch = new PatientSearch(_dbContext);
            var patient = await patientSearch.Find(evaluation.PatientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            evaluation.CreatedAt = DateTimeOffset.UtcNow;

            await _dbContext.Evaluations.AddAsync(evaluation);
            await _dbContext.SaveChangesAsync();

            return evaluation;
        }
    }
}
