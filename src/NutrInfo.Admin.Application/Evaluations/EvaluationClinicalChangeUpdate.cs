using Nutrinfo.Admin.Domain.ClinicalChanges;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationClinicalChangeUpdate
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IClinicalChangeRepository _clinicalChangeRepository;

        public EvaluationClinicalChangeUpdate(IEvaluationRepository evaluationRepository, IClinicalChangeRepository nutritionalStateRepository)
        {
            _evaluationRepository = evaluationRepository;
            _clinicalChangeRepository = nutritionalStateRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Update(int evaluationId, int clinicalChangeId)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var clinicalChangeContext = evaluation.ClinicalChanges.Where(x => x.Id == clinicalChangeId).SingleOrDefault();

            if (clinicalChangeContext is null)
            {
                var clinicalChange = await _clinicalChangeRepository.FindById(clinicalChangeId);
                evaluation.ClinicalChanges.Add(clinicalChange);
            }
            else
            {
                evaluation.ClinicalChanges.Remove(clinicalChangeContext);
            }

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
