using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Diagnosis;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class DiagnosisEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IArmCircumferencePercentilRepository _armPercentil;

        public DiagnosisEvaluationRegistration(IEvaluationRepository evaluationRepository, IArmCircumferencePercentilRepository armPercentil)
        {
            _evaluationRepository = evaluationRepository;
            _armPercentil = armPercentil;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<DiagnosisResponse> Register(int evaluationId)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var armCalculation = new ArmCircumferenceCalculation(_armPercentil);
            var armClassification = await armCalculation.GetArmCircumferenceClassification(evaluation);

            return evaluation.MapToDiagnosisResponse(armClassification);
        }
    }
}
