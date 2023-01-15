using System;
using Nutrinfo.Admin.Domain.Evaluations;
using NutrInfo.Admin.Contracts.Patients;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public class EvaluationResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Imc { get; set; }
        public bool IsWalking { get; set; }
        public bool HasEdema { get; set; }
        public bool HasAscites { get; set; }
        public NutritionalStateEnum NutritionState { get; set; }
        public DiseaseSeverityEnum DiseaseSeverity { get; set; }
        public EvaluationStatusEnum Status { get; set; }
        public EvaluationStepsEnum Step { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
