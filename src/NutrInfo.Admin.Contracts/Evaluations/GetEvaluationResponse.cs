using System.Collections.Generic;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public class GetEvaluationResponse
    {
        public IEnumerable<EvaluationResponse> Evaluations { get; set; }
    }
}
