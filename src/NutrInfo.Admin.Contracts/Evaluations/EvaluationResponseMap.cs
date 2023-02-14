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
                PatientId = evaluation.Patient?.User?.Id,
                MedicalRecord = evaluation.Patient?.MedicalRecord,
                Weight =  evaluation.Ascites.Any() || evaluation.AmputatedLimbs.Any() || evaluation.EdemaWeight > 0 ? evaluation.Weight - evaluation.DiscountedWeight : evaluation.Weight,
                Height = evaluation.Height,
                IsWalking = evaluation.IsWalking,
                NutritionState = evaluation.NutritionalState,
                DiseaseSeverity = evaluation.DiseaseSeverity,
                Status = evaluation.Status,
                Step = evaluation.Step,
                CreatedAt = evaluation.CreatedAt,
                UpdatedAt = evaluation.UpdatedAt,
                IsNextEvaluation = evaluation.NextEvaluation?.Date == DateTime.UtcNow.Date,
                NextEvaluation = evaluation.NextEvaluation
            };
        }
    }
}
