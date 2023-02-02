using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Diagnosis
{
    public class DiagnosisResponse
    {
        public ArmCircumferenceClassificationEnum ArmCircumferenceClassification { get; set; }
        public NutritionalStateEnum Imc { get; set; }
        public bool HasLossMuscleMass { get; set; }
    }
}
