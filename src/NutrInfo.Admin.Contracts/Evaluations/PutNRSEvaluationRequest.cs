using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
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
        public NutritionalStateEnum NutritionalState { get; set; }

        [Required]
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.DiseaseSeverity = DiseaseSeverity;
            evaluation.NutritionalState = NutritionalState;
            evaluation.ReducedDietaryIntake = ReducedDietaryIntake;
            evaluation.LostWeightLastThreeMonths = LostWeightLastThreeMonths;
            evaluation.Steps = EvaluationStepsEnum.NRN_2002;
        }
    }
}
