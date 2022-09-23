using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Application.Evaluations
{
    public class EvaluationMonitoring
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationMonitoring(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<List<Evaluation>> Find(int nutritionistId)
        {
            return await _evaluationRepository.FindAllMonitoringByNutritionist(nutritionistId);
        }
    }
}
