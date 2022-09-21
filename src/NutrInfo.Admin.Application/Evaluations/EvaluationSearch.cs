using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationSearch
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationSearch(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Find(int evaluationId)
        {
            var evaluation = await _evaluationRepository.FindById(evaluationId);

            if (evaluation == null)
            {
                EvaluationNotFound = true;
                return null;
            }

            return evaluation;
        }
    }
}
