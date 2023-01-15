using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public static class EvaluationResponseMap
    {
        public static EvaluationResponse MapToResponse(this Evaluation evaluation)
        {
            return new EvaluationResponse()
            {
                Id = evaluation.Id,
                Imc = evaluation.Imc,
                PatientName = evaluation.Patient?.User?.Name,
                Weight = evaluation.Weight,
                Height = evaluation.Height,
                IsWalking = evaluation.IsWalking,
                NutritionState = evaluation.NutritionalState,
                DiseaseSeverity = evaluation.DiseaseSeverity,
                Status = evaluation.Status,
                Step = evaluation.Step,
                CreatedAt = evaluation.CreatedAt,
                UpdatedAt = evaluation.UpdatedAt
            };
        }
    }
}
