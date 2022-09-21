using System;
using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class PutInitialEvaluationRequest
    {
        [Required]
        public bool IsWalking { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double EdemaWeight { get; set; }

        [Required]
        public bool HasAscite { get; set; }

        [Required]
        public bool HasAmputatedLimb { get; set; }

        [Required]
        public int BedNumber { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight;
            evaluation.Height = Height;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.HasAscite = HasAscite;
            evaluation.Imc = Weight / Math.Pow(Height, 2);
            evaluation.Steps = EvaluationStepsEnum.INITIAL_EVALUATION;
        }
    }
}
