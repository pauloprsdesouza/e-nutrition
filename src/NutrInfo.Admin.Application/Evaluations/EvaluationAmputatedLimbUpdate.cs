using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationAmputatedLimbUpdate
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationAmputatedLimbUpdate(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Update(AmputatedLimb amputatedLimb)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(amputatedLimb.EvaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var amputatedLimbContext = evaluation.AmputatedLimbs.Where(x => x.AmputatedLimbPercentageId == amputatedLimb.AmputatedLimbPercentageId).SingleOrDefault();

            if (amputatedLimbContext is null)
            {
                amputatedLimb.PatientId = evaluation.PatientId;
                evaluation.AmputatedLimbs.Add(amputatedLimb);
            }
            else
            {
                evaluation.AmputatedLimbs.Remove(amputatedLimbContext);
            }

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
