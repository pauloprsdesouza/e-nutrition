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

        public List<AsciteItemRequest> Ascites { get; set; }

        public List<AmputatedLimbItemRequest> AmputatedLimbs { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight - EdemaWeight;
            evaluation.Height = Height/100;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.Imc = Math.Round(Weight / Math.Pow(Height/100, 2));
            evaluation.Step = EvaluationStepsEnum.NRS_2002;
            evaluation.NutritionalState = evaluation.GetNutritionalState();
        }
    }
}
