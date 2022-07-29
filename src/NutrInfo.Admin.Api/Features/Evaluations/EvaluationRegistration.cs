using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Api.Features.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel;

namespace NutrInfo.Admin.Api.Features.Evaluations
{
    public class EvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationRegistration(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Evaluation> Register(Evaluation evaluation)
        {
            var patientSearch = new PatientSearch(_evaluationRepository);
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
