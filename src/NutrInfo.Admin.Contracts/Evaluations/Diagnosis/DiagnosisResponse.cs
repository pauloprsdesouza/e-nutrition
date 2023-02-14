using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.BiochemistryResults;
using NutrInfo.Admin.Contracts.ClinicalChanges;
using NutrInfo.Admin.Contracts.NutritionalStatesSemiology;
using NutrInfo.Admin.Contracts.SignsAndSymptoms;

namespace NutrInfo.Admin.Contracts.Evaluations.Diagnosis
{
    public class DiagnosisResponse
    {
        public ArmCircumferenceClassificationEnum ArmCircumferenceClassification { get; set; }
        public NutritionalStateEnum NutritionalStateCMB { get; set; }
        public NutritionalStateEnum Imc { get; set; }
        public bool HasLossMuscleMass { get; set; }
        public List<NutritionalStateSemiologyResponse> Semiologies { get; set; }
        public List<BiochemistryResultResponse> BiochemistryResults { get; set; }
        public List<ClinicalChangeResponse> ClinicalChanges { get; set; }
    }
}
