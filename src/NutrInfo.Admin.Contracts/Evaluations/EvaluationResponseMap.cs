
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public static class EvaluationResponseMap
    {
        private static readonly double _imcThreshold = 20.5;

        public static EvaluationResponse MapToResponse(this Evaluation evaluation)
        {
            return new EvaluationResponse()
            {
                Id = evaluation.Id,
                //PatientName = evaluation.Patient.User.Name,
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
                CreatedAt = evaluation.CreatedAt,
                UpdatedAt = evaluation.UpdatedAt
            };
        }
    }
}
