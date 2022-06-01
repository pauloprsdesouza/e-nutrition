using System;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class EvaluationResponse
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int BedNumber { get; set; }
        public double Protein { get; set; }
        public double Energy { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Imc { get; set; }
        public bool LowImc { get; set; }
        public bool IsWalking { get; set; }
        public bool HasEdema { get; set; }
        public bool HasAscites { get; set; }
        public bool HasAmputatedLimb { get; set; }
        public NutritionStateEnum NutritionState { get; set; }
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
