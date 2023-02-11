using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations;
using NutrInfo.Admin.Contracts.Evaluations.Anthropometry;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class AnthropometryEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public AnthropometryEvaluationRegistration(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public bool EvaluationNotFound { get; private set; }

        public async Task<Evaluation> Register(int evaluationId, PutAnthropometryEvaluationRequest request)
        {
            var evaluationSearch = new EvaluationSearch(_evaluationRepository);
            var evaluation = await evaluationSearch.Find(evaluationId);

            if (evaluationSearch.EvaluationNotFound)
            {
                EvaluationNotFound = true;
                return null;
            }

            request.MapTo(evaluation);

            var lastCompletedEvaluation = await _evaluationRepository.FindLastEvaluationsFromPatient(evaluation.PatientId);

            if (lastCompletedEvaluation is not null)
            {
                lastCompletedEvaluation.NextEvaluation = null;
                lastCompletedEvaluation.UpdatedAt = DateTimeOffset.UtcNow;
                await _evaluationRepository.Update(lastCompletedEvaluation);
            }

            evaluation.UpdatedAt = DateTimeOffset.UtcNow;
            evaluation.Status = EvaluationStatusEnum.COMPLETED;
            evaluation.NextEvaluation = DateTimeOffset.UtcNow.AddDays(7);

            await _evaluationRepository.Update(evaluation);

            return evaluation;
        }
    }
}
