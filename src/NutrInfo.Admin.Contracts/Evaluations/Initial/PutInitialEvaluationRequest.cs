using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

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
        [Range(1, 3)]
        public double Height { get; set; }

        public double EdemaWeight { get; set; }

        public List<AsciteItemRequest> Ascites { get; set; }

        public List<AmputatedLimbItemRequest> AmputatedLimbs { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight - EdemaWeight;
            evaluation.Height = Height;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.Imc = Math.Round(Weight / Math.Pow(Height, 2));
            evaluation.Step = EvaluationStepsEnum.NRS_2002;
            evaluation.NutritionalState = evaluation.getNutritionalState();
        }
    }
}
