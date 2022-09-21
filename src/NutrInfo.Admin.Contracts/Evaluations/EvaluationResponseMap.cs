
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
                PatientName = evaluation.Patient.User.Name,
                // BedNumber = evaluation.BedNumber,
                // Protein = evaluation.Protein,
                // Energy = evaluation.Energy,
                // Imc = evaluation.Imc,
                LowImc = evaluation.Imc < _imcThreshold,
                // IsWalking = evaluation.IsWalking,
                // HasEdema = evaluation.HasEdema,
                // HasAscites = evaluation.HasAscite,
                // HasAmputatedLimb = evaluation.HasAmputatedLimb,
                // NutritionState = evaluation.NutritionState,
                // DiseaseSeverity = evaluation.DiseaseSeverity,
                CreatedAt = evaluation.CreatedAt,
                UpdatedAt = evaluation.UpdatedAt

            };
        }
    }
}
