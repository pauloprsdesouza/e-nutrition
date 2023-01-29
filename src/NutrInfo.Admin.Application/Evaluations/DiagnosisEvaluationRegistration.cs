using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class DiagnosisEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public DiagnosisEvaluationRegistration(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Register(int evaluationId)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            return evaluation;
        }
    }
}
