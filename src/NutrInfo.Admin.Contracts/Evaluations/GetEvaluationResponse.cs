using System.Collections.Generic;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class GetEvaluationResponse
    {
        public IEnumerable<EvaluationResponse> Evaluations { get; set; }
    }
}
