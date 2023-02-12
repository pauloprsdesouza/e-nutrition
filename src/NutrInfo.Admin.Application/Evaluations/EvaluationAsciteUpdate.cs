using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationAsciteUpdate
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationAsciteUpdate(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Update(Ascite ascite)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(ascite.EvaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var asciteContext = evaluation.Ascites.Where(x => x.AsciteDegreeId == ascite.AsciteDegreeId).SingleOrDefault();

            if (asciteContext is null)
            {
                evaluation.Ascites.Add(ascite);
            }
            else
            {
                evaluation.Ascites.Remove(asciteContext);
            }

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
