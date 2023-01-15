using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class PutInitialEvaluationRequest
    {
        [Required]
        public bool IsWalking { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
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
            evaluation.Step = EvaluationStepsEnum.INITIAL;
        }
    }
}
