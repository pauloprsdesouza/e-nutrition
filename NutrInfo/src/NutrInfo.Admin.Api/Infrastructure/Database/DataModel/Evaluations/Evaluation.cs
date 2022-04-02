using System;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NutritionistId { get; set; }
        public int BedNumber { get; set; }
        public float Protein { get; set; }
        public float Energy { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Imc { get; set; }
        public bool IsWalking { get; set; }
        public bool HasEdema { get; set; }
        public bool HasAscites { get; set; }
        public bool HasAmputatedLimb { get; set; }
        public NutritionStateEnum NutritionState { get; set; }
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Nutritionist Nutritionist { get; set; }
        public Patient Patient { get; set; }
    }
}
