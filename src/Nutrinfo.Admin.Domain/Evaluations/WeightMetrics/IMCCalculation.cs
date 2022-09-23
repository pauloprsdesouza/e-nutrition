using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Evaluations.WeightMetrics
{
    public static class IMCCalculation
    {
        public static NutritionalStateEnum GetNutritionalState(this Evaluation evaluation)
        {
            double percentual;

            if (evaluation.Patient.User.Gender == GenderEnum.MALE)
            {
                double pi = 22 * Math.Pow(evaluation.Height, 2);
                percentual = evaluation.Weight / pi * 100;
            }
            else
            {
                double pi = 21 * Math.Pow(evaluation.Height, 2);
                percentual = evaluation.Weight / pi * 100;
            }

            return percentual switch
            {
                <= 70 => NutritionalStateEnum.SEVERE_MALNUTRITION,
                > 70 and <= 80 => NutritionalStateEnum.MODERATE_MALNUTRITION,
                > 80 and <= 90 => NutritionalStateEnum.LIGHT_MALNUTRITION,
                > 80 and <= 110 => NutritionalStateEnum.EUTROPHY,
                > 110 and <= 120 => NutritionalStateEnum.OVERWEIGHT,
                _ => NutritionalStateEnum.OBESITY,
            };
        }
    }
}
