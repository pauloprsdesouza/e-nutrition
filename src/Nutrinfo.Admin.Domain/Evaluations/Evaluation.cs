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
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public Nutritionist Nutritionist { get; set; }
        public Patient Patient { get; set; }
        public List<AmputatedLimb> AmputatedLimbs { get; set; }
        public List<Ascite> Ascites { get; set; }
    }
}
