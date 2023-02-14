using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.ArmMuscleCircumferencePercentils
{
    public class ArmMuscleCircumferenceCalculation
    {
        private readonly IArmMuscleCircumferencePercentilRepository _repository;

        public ArmMuscleCircumferenceCalculation(IArmMuscleCircumferencePercentilRepository repository)
        {
            _repository = repository;
        }

        public async Task<NutritionalStateEnum> CalculateCMB(Evaluation evaluation)
        {
            var age = evaluation.Patient.User.GetAge();
            var percentil = await _repository.FindByGenderAndAgeAndIsAged(evaluation.Patient.User.Gender, age, age >= 60);

            var cmb = evaluation.ArmMuscleCircumference - Math.PI * (evaluation.TricepsPleat / 10);

            var cmbAdequation = (cmb / percentil.P50) * 100;

            return cmbAdequation switch
            {
                <= 70 => NutritionalStateEnum.SEVERE_MALNUTRITION,
                > 70 and <= 80 => NutritionalStateEnum.MODERATE_MALNUTRITION,
                > 80 and <= 90 => NutritionalStateEnum.LIGHT_MALNUTRITION,
                > 90 and <= 110 => NutritionalStateEnum.EUTROPHY,
                > 110 and <= 120 => NutritionalStateEnum.OVERWEIGHT,
                _ => NutritionalStateEnum.OBESITY
            };
        }
    }
}
