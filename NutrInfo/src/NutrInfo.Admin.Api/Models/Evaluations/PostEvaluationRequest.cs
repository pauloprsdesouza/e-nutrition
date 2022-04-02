using System;
using System.ComponentModel.DataAnnotations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class PostEvaluationRequest
    {
        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public bool IsWalking { get; set; }

        [Required]
        public bool HasEdema { get; set; }

        [Required]
        public bool HasAscite { get; set; }

        [Required]
        public bool HasAmputatedLimb { get; set; }

        [Required]
        public int BedNumber { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Energy { get; set; }

        public NutritionStateEnum NutritionState { get; set; }

        public DiseaseSeverityEnum DiseaseSeverity { get; set; }

        public Evaluation ToEvaluation()
        {
            return new Evaluation()
            {
                Weight = Weight,
                Height = Height,
                IsWalking = IsWalking,
                HasEdema = HasEdema,
                HasAscite = HasAscite,
                HasAmputatedLimb = HasAmputatedLimb,
                Imc = Weight / Math.Pow(Height, 2)
            };
        }
    }
}
