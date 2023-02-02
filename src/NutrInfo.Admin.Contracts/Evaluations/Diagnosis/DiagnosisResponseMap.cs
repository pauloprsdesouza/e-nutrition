using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Evaluations.Diagnosis
{
    public static class DiagnosisResponseMap
    {
        public static DiagnosisResponse MapToDiagnosisResponse(this Evaluation evaluation, ArmCircumferenceClassificationEnum armCircumferenceClassification)
        {
            return new DiagnosisResponse()
            {
                ArmCircumferenceClassification = armCircumferenceClassification,
                Imc = evaluation.NutritionalState,
                HasLossMuscleMass = evaluation.Patient.User.Gender == GenderEnum.MALE && evaluation.CalfCircumference <= 34 || evaluation.Patient.User.Gender == GenderEnum.FEMALE && evaluation.CalfCircumference <= 33
            };
        }
    }
}
