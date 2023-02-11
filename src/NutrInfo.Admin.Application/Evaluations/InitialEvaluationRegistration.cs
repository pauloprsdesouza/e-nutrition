using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Application.AmputatedLimbs;
using NutrInfo.Admin.Application.Ascites;
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

            var netWeight = await CreateOrUpdateAmputatedLimbs(request, evaluation);
            netWeight += await CreateOrUpdateAscites(request, evaluation);

            request.Weight -= netWeight;

            request.MapTo(evaluation);
            evaluation.UpdatedAt = DateTimeOffset.UtcNow;

            return await _evaluationRepository.Update(evaluation);
        }

        private async Task<double> CreateOrUpdateAmputatedLimbs(PutInitialEvaluationRequest request, Evaluation evaluation)
        {
            if (request.AmputatedLimbs != null && request.AmputatedLimbs.Count > 0)
            {
                evaluation.Patient.AmputatedLimbs.Clear();

                var amputatedLimbSearch = new AmputatedLimbSearch(_amputatedLimbRepository);
                var amputatedLimbs = await amputatedLimbSearch.Find(request.AmputatedLimbs.Select(x => x.AmputatedLimbPercentageId).ToList(), evaluation.PatientId);

                if (amputatedLimbs.Count == 0)
                {
                    foreach (var amputatedLimb in request.AmputatedLimbs)
                    {
                        amputatedLimbs.Add(new AmputatedLimb()
                        {
                            EvaluationId = evaluation.Id,
                            PatientId = evaluation.PatientId,
                            AmputatedLimbPercentageId = amputatedLimb.AmputatedLimbPercentageId,
                            Reason = amputatedLimb.Reason
                        });
                    }

                    evaluation.AmputatedLimbs = amputatedLimbs;
                }

                var percentil = evaluation.Patient.AmputatedLimbs.Sum(x => x.LimbPercentage.Percentage);

                return request.Weight * percentil / 100;
            }

            return 0;
        }

        private async Task<double> CreateOrUpdateAscites(PutInitialEvaluationRequest request, Evaluation evaluation)
        {
            if (request.Ascites.Count > 0)
            {
                evaluation.Ascites.Clear();

                var asciteSearch = new AsciteSearch(_asciteRepository);
                var ids = request.Ascites.Select(x => x.AsciteDegreeId).ToList();
                var ascites = await asciteSearch.Find(ids);

                if (ascites.Count == 0)
                {
                    foreach (var ascite in request.Ascites)
                    {
                        evaluation.Ascites.Add(new Ascite()
                        {
                            AsciteDegreeId = ascite.AsciteDegreeId,
                            EvaluationId = evaluation.Id,
                            Reason = ascite.Reason,
                            HasAsciticWeight = ascite.HasAsciticWeight,
                            HasPeripheralEdema = ascite.HasPeripheralEdema
                        });
                    }
                }

                var asciteDegrees = await _asciteDegreeRepository.FindByIds(ids);

                var peripheralEdemaSum = 0d;
                var asciticWeightSum = 0d;

                foreach (var ascite in evaluation.Ascites)
                {
                    var asciteDegree = asciteDegrees.Where(x => x.Id == ascite.AsciteDegreeId).SingleOrDefault();

                    if (ascite.HasPeripheralEdema)
                    {
                        peripheralEdemaSum += asciteDegree.PeripheralEdema;
                    }

                    if (ascite.HasAsciticWeight)
                    {
                        peripheralEdemaSum += asciteDegree.AsciticWeight;
                    }
                }

                return peripheralEdemaSum + asciticWeightSum;
            }

            return 0;
        }
    }
}
