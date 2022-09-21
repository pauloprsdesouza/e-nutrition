using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;
using NutrInfo.Admin.Application.Patients;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IPatientRepository _patientRepository;

        public EvaluationRegistration(IEvaluationRepository evaluationRepository, IPatientRepository patientRepository)
        {
            _evaluationRepository = evaluationRepository;
            _patientRepository = patientRepository;
        }

        public bool PatientNotFound { get; private set; }

        public async Task<Evaluation> Register(int nutritionistId, Evaluation evaluation)
        {
            var patientSearch = new PatientSearch(_patientRepository);
            await patientSearch.Find(evaluation.PatientId);

            if (patientSearch.PatientNotFound)
            {
                PatientNotFound = true;
                return null;
            }

            evaluation.NutritionistId = nutritionistId;
            evaluation.CreatedAt = System.DateTimeOffset.UtcNow;

            return await _evaluationRepository.Create(evaluation);
        }
    }
}
