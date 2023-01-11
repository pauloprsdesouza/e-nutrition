using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.NRS2002
{
    public class PutNRSEvaluationRequest
    {
        [Required]
        public double LostWeightLastThreeMonths { get; set; }

        [Required]
        public bool ReducedDietaryIntake { get; set; }

        [Required]
        public bool SeriouslyIllPatient { get; set; }

        [Required]
        public NutritionalStateSeverityEnum NutritionalStateSeverity { get; set; }

        [Required]
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.DiseaseSeverity = DiseaseSeverity;
            evaluation.NutritionalStateSeverity = NutritionalStateSeverity;
            evaluation.ReducedDietaryIntake = ReducedDietaryIntake;
            evaluation.LostWeightLastThreeMonths = LostWeightLastThreeMonths;
            evaluation.Step = EvaluationStepsEnum.NRS_2002;
        }
    }
}
