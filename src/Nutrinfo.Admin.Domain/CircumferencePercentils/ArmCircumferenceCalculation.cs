using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.CircumferencePercentils
{
    public class ArmCircumferenceCalculation
    {
        private readonly IArmCircumferencePercentilRepository _percentils;

        public ArmCircumferenceCalculation(IArmCircumferencePercentilRepository percentils)
        {
            _percentils = percentils;
        }
        public async Task<ArmCircumferenceClassificationEnum> GetArmCircumferenceClassification(Evaluation evaluation)
        {
            var age = evaluation.Patient.User.GetAge();
            var percentil = await _percentils.FindByGenderAndAge(evaluation.Patient.User.Gender, age);

            if (age > 60)
            {
                if (evaluation.ArmCircumference < percentil.P5)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION;
                else if (evaluation.ArmCircumference >= percentil.P5 && evaluation.ArmCircumference < percentil.P10)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION_RISK;
                else if (evaluation.ArmCircumference >= percentil.P10 && evaluation.ArmCircumference < percentil.P90)
                    return ArmCircumferenceClassificationEnum.EUTROPHY;
                else
                    return ArmCircumferenceClassificationEnum.OBESITY;
            }
            else
            {
                if (evaluation.ArmCircumference < percentil.P5)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION;
                else if (evaluation.ArmCircumference >= percentil.P5 && evaluation.ArmCircumference < percentil.P15)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION_RISK;
                else if (evaluation.ArmCircumference >= percentil.P15 && evaluation.ArmCircumference < percentil.P85)
                    return ArmCircumferenceClassificationEnum.EUTROPHY;
                if (evaluation.ArmCircumference >= percentil.P85 && evaluation.ArmCircumference < percentil.P95)
                    return ArmCircumferenceClassificationEnum.OVERWEIGHT;
                else
                    return ArmCircumferenceClassificationEnum.OBESITY;
            }
        }
    }
}
