using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Anthropometry
{
    public static class AnthropometryEvaluationMapResponse
    {
        public static AnthropometryEvaluationResponse MapToAnthropometryResponse(this Evaluation evaluation)
        {
            return new AnthropometryEvaluationResponse()
            {
                ArmCircumference = evaluation.ArmCircumference,
                CalfCircumference = evaluation.CalfCircumference,
                ArmMuscleCircumference = evaluation.ArmMuscleCircumference,
                TricepsPleat = evaluation.TricepsPleat,
                Step = evaluation.Step
            };
        }
    }
}
