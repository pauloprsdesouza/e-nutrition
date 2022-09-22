using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.NRS2002
{
    public static class NRSEvaluationMapResponse
    {
        public static NRSEvaluationResponse MapToNRSResponse(this Evaluation evaluation)
        {
            var _imcThreshold = 20.5;
            var scoreGreaterThan70Years = DateTime.UtcNow.Subtract(evaluation.Patient.User.BirthDate).Days >= 70 ? 1 : 0;
            var nutritionalRisk = (int)evaluation.NutritionalState + (int)evaluation.DiseaseSeverity + scoreGreaterThan70Years;

            return new NRSEvaluationResponse()
            {
                DiseaseSeverity = evaluation.DiseaseSeverity,
                LostWeightLastThreeMonths = evaluation.LostWeightLastThreeMonths,
                NutritionalState = evaluation.NutritionalState,
                ReducedDietaryIntake = evaluation.ReducedDietaryIntake,
                SeriouslyIllPatient = evaluation.SeriouslyIllPatient,
                LowImc = evaluation.Imc < _imcThreshold,
                HasNutritionalRisk = nutritionalRisk >= 3
            };
        }
    }
}
