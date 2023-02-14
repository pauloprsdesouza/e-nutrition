using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Initial;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class InitialEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IAmputatedLimbRepository _amputatedLimbRepository;
        private readonly IAsciteRepository _asciteRepository;
        private readonly IAsciteDegreeRepository _asciteDegreeRepository;

        public InitialEvaluationRegistration(IEvaluationRepository evaluationRepository, IAmputatedLimbRepository amputatedLimbRepository, IAsciteRepository asciteRepository, IAsciteDegreeRepository asciteDegreeRepository)
        {
            _evaluationRepository = evaluationRepository;
            _amputatedLimbRepository = amputatedLimbRepository;
            _asciteRepository = asciteRepository;
            _asciteDegreeRepository = asciteDegreeRepository;
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

            var discountedWeight = 0d;
            discountedWeight += request.Weight * evaluation.AmputatedLimbs.Sum(x => x.LimbPercentage.Percentage) / 100;
            discountedWeight -= evaluation.Ascites.Sum(x => x.AsciteDegree.AsciticWeight + x.AsciteDegree.PeripheralEdema);
            discountedWeight -= request.EdemaWeight;

            evaluation.DiscountedWeight =  Math.Sqrt(Math.Pow(discountedWeight, 2));

            if (evaluation.AmputatedLimbs.Any() || evaluation.Ascites.Any() || request.EdemaWeight > 0)
            {
                evaluation.Imc = (request.Weight - evaluation.DiscountedWeight) / Math.Pow(request.Height, 2);
            }
            else
            {
                evaluation.Imc = (request.Weight) / Math.Pow(request.Height, 2);
            }

            request.MapTo(evaluation);
            evaluation.UpdatedAt = DateTimeOffset.UtcNow;

            return await _evaluationRepository.Update(evaluation);
        }
    }
}
