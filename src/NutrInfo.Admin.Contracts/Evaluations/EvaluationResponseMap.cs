
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public static class EvaluationResponseMap
    {
        private static readonly double _imcThreshold = 20.5;

        public static EvaluationResponse MapToResponse(this Evaluation evaluation)
        {
            var scoreGreaterThan70Years = DateTime.UtcNow.Subtract(evaluation.Patient.User.BirthDate).Days >= 70 ? 1 : 0;
            var nutritionalRisk = (int)evaluation.NutritionalState + (int)evaluation.DiseaseSeverity + scoreGreaterThan70Years;

            return new EvaluationResponse()
            {
                Id = evaluation.Id,
                PatientName = evaluation.Patient.User.Name,
                Imc = evaluation.Imc,
                Weight = evaluation.Weight,
                Height = evaluation.Height,
                LowImc = evaluation.Imc < _imcThreshold,
                IsWalking = evaluation.IsWalking,
                HasAscites = evaluation.HasAscite,
                NutritionState = evaluation.NutritionalState,
                DiseaseSeverity = evaluation.DiseaseSeverity,
                Status = evaluation.Status,
                Step = evaluation.Step,
                HasNutritionalRisk = nutritionalRisk >= 3,
                CreatedAt = evaluation.CreatedAt,
                UpdatedAt = evaluation.UpdatedAt
            };
        }
    }
}
