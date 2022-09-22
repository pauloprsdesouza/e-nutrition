using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public static class InitialEvaluationMapResponse
    {
        public static InitialEvaluationResponse MapToInitialResponse(this Evaluation evaluation)
        {
            return new InitialEvaluationResponse()
            {
                EdemaWeight = evaluation.EdemaWeight,
                Height = evaluation.Height,
                IsWalking = evaluation.IsWalking,
                Weight = evaluation.Weight
            };
        }
    }
}
