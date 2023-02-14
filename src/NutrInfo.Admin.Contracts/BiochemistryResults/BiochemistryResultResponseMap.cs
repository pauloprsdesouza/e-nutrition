using Nutrinfo.Admin.Domain.BiochemistryResults;

namespace NutrInfo.Admin.Contracts.BiochemistryResults
{
    public static class BiochemistryResultResponseMap
    {
        public static BiochemistryResultResponse MapToResponse(this BiochemistryResult biochemistry)
        {
            return new BiochemistryResultResponse()
            {
                EvaluationId = biochemistry.EvaluationId,
                BiochemistryId = biochemistry.BiochemistryId,
                HealthExam = biochemistry.Biochemistry.HealthExam,
                Result = biochemistry.Result,
                Referency = $"{biochemistry.Biochemistry.MinimumThreshold} - {biochemistry.Biochemistry.MaximumThreshold}",
                MaximumThreshold = biochemistry.Biochemistry.MaximumThreshold,
                MinimumThreshold = biochemistry.Biochemistry.MinimumThreshold,
                PossibleMeanings = biochemistry.Biochemistry.PossibleMeanings
            };
        }
    }
}
