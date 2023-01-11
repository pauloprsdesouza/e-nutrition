using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.NRS2002;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class NRSEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public List<string> ValidationErros { get; private set; }

        public NRSEvaluationRegistration(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
            ValidationErros = new();
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Register(int evaluationId, PutNRSEvaluationRequest request)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            var imc = evaluation.Weight / Math.Pow(evaluation.Height, 2);

            var validationData = request.LostWeightLastThreeMonths > 0 || request.ReducedDietaryIntake || request.SeriouslyIllPatient || imc < 20.5;

            if (!validationData)
            {
                ValidationErros.Add("PATIENT_DOES_NOT_HAVE_NUTRITIONAL_RISK");
                return null;
            }

            if ((int)request.NutritionalStateSeverity + (int)request.DiseaseSeverity < 3)
            {
                evaluation.NextEvaluation = DateTime.UtcNow.AddDays(7);
            }

            request.MapTo(evaluation);
            evaluation.UpdatedAt = DateTimeOffset.UtcNow;

            return await _evaluationRepository.Update(evaluation);
        }
    }
}
