using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Contracts.NutritionalStatesSemiology;
using NutrInfo.Admin.Contracts.BiochemistryResults;
using NutrInfo.Admin.Contracts.ClinicalChanges;

namespace NutrInfo.Admin.Contracts.Evaluations.Diagnosis
{
    public static class DiagnosisResponseMap
    {
        public static DiagnosisResponse MapToDiagnosisResponse(this Evaluation evaluation, ArmCircumferenceClassificationEnum armCircumferenceClassification, NutritionalStateEnum nutritionalStateCMB)
        {
            return new DiagnosisResponse()
            {
                ArmCircumferenceClassification = armCircumferenceClassification,
                Imc = evaluation.NutritionalState,
                NutritionalStateCMB = nutritionalStateCMB,
                HasLossMuscleMass = evaluation.Patient.User.Gender == GenderEnum.MALE && evaluation.CalfCircumference <= 34 || evaluation.Patient.User.Gender == GenderEnum.FEMALE && evaluation.CalfCircumference <= 33,
                Semiologies = evaluation.Semiologies.Select(x => x.MapToResponse()).ToList(),
                BiochemistryResults = evaluation.BiochemistryResults.Select(x => x.MapToResponse()).ToList(),
                ClinicalChanges = evaluation.ClinicalChanges.Select(x => x.MapToResponse()).ToList()
            };
        }
    }
}
