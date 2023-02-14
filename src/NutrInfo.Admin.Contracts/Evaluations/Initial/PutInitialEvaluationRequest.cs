using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Evaluations.WeightMetrics;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class PutInitialEvaluationRequest
    {
        [Required]
        public bool IsWalking { get; set; }

        [Required]
        [Range(5, 300)]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public double EdemaWeight { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight;
            evaluation.Height = Height;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.Step = EvaluationStepsEnum.NRS_2002;
            evaluation.NutritionalState = evaluation.GetNutritionalState();
        }
    }
}
