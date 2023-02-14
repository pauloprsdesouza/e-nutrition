using Nutrinfo.Admin.Domain.Biochemistries;
using Nutrinfo.Admin.Domain.BiochemistryResults;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class PutEvaluationBiochemistryRequest
    {
        public int BiochemistryId { get; set; }
        public double Result { get; set; }

        public BiochemistryResult ToBiochemistryResult(int evaluationId)
        {
            return new BiochemistryResult()
            {
                EvaluationId = evaluationId,
                BiochemistryId = BiochemistryId,
                Result = Result
            };
        }
    }
}
