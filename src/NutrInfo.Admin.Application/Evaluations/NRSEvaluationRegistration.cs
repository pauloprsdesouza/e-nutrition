using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Api.Models.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class NRSEvaluationRegistration
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public NRSEvaluationRegistration(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
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

            request.MapTo(evaluation);
            evaluation.UpdatedAt = DateTimeOffset.UtcNow;

            return await _evaluationRepository.Update(evaluation);
        }
    }
}
