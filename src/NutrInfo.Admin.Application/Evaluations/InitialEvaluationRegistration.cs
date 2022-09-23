using System;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Application.AmputatedLimbs;
using NutrInfo.Admin.Application.Ascites;
using NutrInfo.Admin.Contracts.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Initial;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class InitialEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IAmputatedLimbRepository _amputatedLimbRepository;
        private readonly IAsciteRepository _asciteRepository;

        public InitialEvaluationRegistration(IEvaluationRepository evaluationRepository, IAmputatedLimbRepository amputatedLimbRepository, IAsciteRepository asciteRepository)
        {
            _evaluationRepository = evaluationRepository;
            _amputatedLimbRepository = amputatedLimbRepository;
            _asciteRepository = asciteRepository;
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
                var ascites = await asciteSearch.Find(request.Ascites.Select(x => x.AsciteDegreeId).ToList());

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

                var peripheralEdemaSum = evaluation.Ascites.Where(x => x.HasPeripheralEdema).Sum(x => x.AsciteDegree.PeripheralEdema);
                var asciticWeightSum = evaluation.Ascites.Where(x => x.HasAsciticWeight).Sum(x => x.AsciteDegree.AsciticWeight);

                return request.Weight - (peripheralEdemaSum + asciticWeightSum);
            }

            return 0;
        }
    }
}
