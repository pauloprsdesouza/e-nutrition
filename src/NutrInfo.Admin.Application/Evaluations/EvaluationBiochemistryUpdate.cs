using Nutrinfo.Admin.Domain.Biochemistries;
using Nutrinfo.Admin.Domain.BiochemistryResults;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationBiochemistryUpdate
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationBiochemistryUpdate(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Update(BiochemistryResult biochemistryResult)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(biochemistryResult.EvaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var biochemistryContext = evaluation.BiochemistryResults.Where(x => x.BiochemistryId == biochemistryResult.BiochemistryId).SingleOrDefault();

            if (biochemistryContext is null)
            {
                evaluation.BiochemistryResults.Add(biochemistryResult);
            }
            else
            {
                if (biochemistryContext.Result != biochemistryResult.Result)
                {
                    biochemistryContext.Result = biochemistryResult.Result;
                }
                else
                {
                    evaluation.BiochemistryResults.Remove(biochemistryContext);
                }
            }

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
