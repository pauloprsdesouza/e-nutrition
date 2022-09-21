using System;
using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public class PutInitialEvaluationRequest
    {
        [Required]
        public bool IsWalking { get; set; }

        [Required, Range(50, 200)]
        public double Weight { get; set; }

        [Required, Range(0.5, 2.5)]
        public double Height { get; set; }

        [Required, Range(1, 12)]
        public double EdemaWeight { get; set; }

        [Required]
        public bool HasAscite { get; set; }

        [Required]
        public bool HasAmputatedLimb { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight;
            evaluation.Height = Height;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.HasAscite = HasAscite;
            evaluation.Imc = Weight / Math.Pow(Height, 2);
            evaluation.Step = EvaluationStepsEnum.INITIAL;
        }
    }
}
