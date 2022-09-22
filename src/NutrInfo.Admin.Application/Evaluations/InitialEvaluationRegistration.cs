using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Limbs;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Application.AmputatedLimbs;
using NutrInfo.Admin.Contracts.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Initial;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class InitialEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ILimbRepository _amputatedLimbRepository;

        public InitialEvaluationRegistration(IEvaluationRepository evaluationRepository, ILimbRepository amputatedLimbRepository)
        {
            _evaluationRepository = evaluationRepository;
            _amputatedLimbRepository = amputatedLimbRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Register(int evaluationId, PutInitialEvaluationRequest request)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            if (request.AmputatedLimbs.Count > 0)
            {
                evaluation.Patient.AmputatedLimbs.Clear();

                var amputatedLimbSearch = new AmputatedLimbSearch(_amputatedLimbRepository);
                evaluation.Patient.AmputatedLimbs = await amputatedLimbSearch.Find(request.AmputatedLimbs);

                var percentil = evaluation.Patient.AmputatedLimbs.Sum(x => x.Percentil);

                evaluation.Weight -= evaluation.Weight * percentil / 100;
            }

            request.MapTo(evaluation);
            evaluation.UpdatedAt = DateTimeOffset.UtcNow;

            return await _evaluationRepository.Update(evaluation);
        }
    }
}
