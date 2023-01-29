using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Anthropometry
{
    public class PutAnthropometryEvaluationRequest
    {
        [Required]
        [Range(1, double.MaxValue)]
        public double ArmCircumference { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double TricepsPleat { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double CalfCircumference { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double ArmMuscleCircumference { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.ArmCircumference = ArmCircumference;
            evaluation.TricepsPleat = TricepsPleat;
            evaluation.CalfCircumference = CalfCircumference;
            evaluation.ArmMuscleCircumference = ArmMuscleCircumference;
            evaluation.Step = EvaluationStepsEnum.DIAGNOSIS;
        }
    }
}
