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
        public async Task<ArmCircumferenceClassificationEnum> GetArmCircumferenceClassification(Patient patient, double armCircumference)
        {
            var age = patient.User.GetAge();
            var percentil = await _percentils.FindByGenderAndAge(patient.User.Gender, age);

            if (age > 60)
            {
                if (armCircumference < percentil.P5)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION;
                else if (armCircumference >= percentil.P5 && armCircumference < percentil.P10)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION_RISK;
                else if (armCircumference >= percentil.P10 && armCircumference < percentil.P90)
                    return ArmCircumferenceClassificationEnum.EUTROPHY;
                else
                    return ArmCircumferenceClassificationEnum.OBESITY;
            }
            else
            {
                if (armCircumference < percentil.P5)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION;
                else if (armCircumference >= percentil.P5 && armCircumference < percentil.P15)
                    return ArmCircumferenceClassificationEnum.MALNUTRITION_RISK;
                else if (armCircumference >= percentil.P15 && armCircumference < percentil.P85)
                    return ArmCircumferenceClassificationEnum.EUTROPHY;
                if (armCircumference >= percentil.P85 && armCircumference < percentil.P95)
                    return ArmCircumferenceClassificationEnum.OVERWEIGHT;
                else
                    return ArmCircumferenceClassificationEnum.OBESITY;
            }
        }
    }
}
