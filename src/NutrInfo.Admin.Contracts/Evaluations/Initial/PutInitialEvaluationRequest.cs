using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Limbs;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class PutInitialEvaluationRequest
    {
        [Required]
        public bool IsWalking { get; set; }

        [Required, Range(50, 200)]
        public double Weight { get; set; }

        [Required, Range(0.5, 2.5)]
        public double Height { get; set; }

        [Range(0, 12)]
        public double EdemaWeight { get; set; }

        public bool HasAscite { get; set; }

        public List<int> AmputatedLimbs { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.Weight = Weight - EdemaWeight;
            evaluation.Height = Height;
            evaluation.IsWalking = IsWalking;
            evaluation.EdemaWeight = EdemaWeight;
            evaluation.HasAscite = HasAscite;
            evaluation.Imc = Weight / Math.Pow(Height, 2);
            evaluation.Step = EvaluationStepsEnum.INITIAL;
        }
    }
}
