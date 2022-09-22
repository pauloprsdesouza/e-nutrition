using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Contracts.Evaluations.Anthropometry
{
    public class AnthropometryEvaluationResponse
    {
        public double ArmCircumference { get; set; }
        public double TricepsPleat { get; set; }
        public double CalfCircumference { get; set; }
        public double ArmMuscleCircumference { get; set; }
        public EvaluationStepsEnum Step { get; set; }
    }
}
