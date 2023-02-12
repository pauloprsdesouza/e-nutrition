using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationSemiologyUpdate
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly INutritionalStateSemiologyRepository _nutritionalStateRepository;

        public EvaluationSemiologyUpdate(IEvaluationRepository evaluationRepository, INutritionalStateSemiologyRepository nutritionalStateRepository)
        {
            _evaluationRepository = evaluationRepository;
            _nutritionalStateRepository = nutritionalStateRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Update(int evaluationId, int nutritionalStateSemiologyId)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var nutritionalStateSemiologyContext = evaluation.Semiologies.Where(x => x.Id == nutritionalStateSemiologyId).SingleOrDefault();

            if (nutritionalStateSemiologyContext is null)
            {
                var nutritionalState = await _nutritionalStateRepository.FindById(nutritionalStateSemiologyId);
                evaluation.Semiologies.Add(nutritionalState);
            }
            else
            {
                evaluation.Semiologies.Remove(nutritionalStateSemiologyContext);
            }

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
