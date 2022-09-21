using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations
{
    public class PutAnthropometryEvaluationRequest
    {
        [Required, Range(0.1, 1)]
        public double ArmCircumference { get; set; }

        [Required, Range(0.1, 1)]
        public double TricepsPleat { get; set; }

        [Required, Range(0.1, 1)]
        public double CalfCircumference { get; set; }

        [Required, Range(0.1, 1)]
        public double ArmMuscleCircumference { get; set; }

        public void MapTo(Evaluation evaluation)
        {
            evaluation.ArmCircumference = ArmCircumference;
            evaluation.TricepsPleat = TricepsPleat;
            evaluation.CalfCircumference = CalfCircumference;
            evaluation.ArmMuscleCircumference = ArmMuscleCircumference;
            evaluation.Step = EvaluationStepsEnum.ANTHROPOMETRY;
        }
    }
}
