using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.NRS2002
{
    public class NRSEvaluationResponse
    {
        public double LostWeightLastThreeMonths { get; set; }
        public bool ReducedDietaryIntake { get; set; }
        public bool SeriouslyIllPatient { get; set; }
        public NutritionalStateEnum NutritionalState { get; set; }
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }
        public bool LowImc { get; set; }
        public bool HasNutritionalRisk { get; set; }
    }
}
