using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Anthropometry
{
    public class PutAnthropometryEvaluationRequest
    {
        [Required]
        public double ArmCircumference { get; set; }

        [Required]
        public double TricepsPleat { get; set; }

        [Required]
        public double CalfCircumference { get; set; }

        [Required]
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
