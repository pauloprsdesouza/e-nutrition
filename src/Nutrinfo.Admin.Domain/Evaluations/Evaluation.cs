using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.Evaluations
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NutritionistId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Imc { get; set; }
        public bool IsWalking { get; set; }
        public double EdemaWeight { get; set; }
        public NutritionalStateEnum NutritionalState { get; set; }
        public NutritionalStateSeverityEnum NutritionalStateSeverity { get; set; }
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }
        public double LostWeightLastThreeMonths { get; set; }
        public bool ReducedDietaryIntake { get; set; }
        public bool SeriouslyIllPatient { get; set; }
        public double ArmCircumference { get; set; }
        public double TricepsPleat { get; set; }
        public double CalfCircumference { get; set; }
        public double ArmMuscleCircumference { get; set; }
        public EvaluationStatusEnum Status { get; set; }
        public EvaluationStepsEnum Step { get; set; }
        public DateTimeOffset? NextEvaluation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public Nutritionist Nutritionist { get; set; }
        public Patient Patient { get; set; }
        public List<AmputatedLimb> AmputatedLimbs { get; set; }
        public List<Ascite> Ascites { get; set; }

        public NutritionalStateEnum getNutritionalState()
        {
            const double IDEAL_IMC = 21.7;

            var idealWeight = IDEAL_IMC * Math.Pow(Height, 2);
            var percentualIdealWeight = Weight / idealWeight * 100;

            if (percentualIdealWeight <= 70)
                return NutritionalStateEnum.SEVERE_MALNUTRITION;
            else if (percentualIdealWeight > 80 && percentualIdealWeight <= 80)
                return NutritionalStateEnum.MODERATE_MALNUTRITION;
            else if (percentualIdealWeight > 80 && percentualIdealWeight <= 90)
                return NutritionalStateEnum.LIGHT_MALNUTRITION;
            else if (percentualIdealWeight > 90 && percentualIdealWeight <= 110)
                return NutritionalStateEnum.EUTROPHY;
            else if (percentualIdealWeight > 110 && percentualIdealWeight <= 120)
                return NutritionalStateEnum.OVERWEIGHT;
            else
                return NutritionalStateEnum.OBESITY;
        }
    }
}
