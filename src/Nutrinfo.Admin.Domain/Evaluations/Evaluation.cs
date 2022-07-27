
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.Evaluations
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NutritionistId { get; set; }
        public int? BedNumber { get; set; }
        public double? Protein { get; set; }
        public double? Energy { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Imc { get; set; }
        public bool? IsWalking { get; set; }
        //public EdemaDegree? Edema { get; set; }
        public double? EdemaWeight { get; set; }
        public bool? HasAscite { get; set; }
        public List<int> AmputatedLimbs { get; set; }
        public NutritionStateEnum? NutritionState { get; set; }
        public DiseaseSeverityEnum? DiseaseSeverity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Nutritionist Nutritionist { get; set; }
        public Patient Patient { get; set; }
    }
}
