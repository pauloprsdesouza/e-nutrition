using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Infrastructure.Formulas
{
    public class WeightEstimation
    {
        public static double EstimateWeightByRaceAgeGender(RaceEnum race, int age, GenderEnum gender, double kneeHeight, double armCircumference)
        {
            if (race == RaceEnum.White)
            {
                if (age >= 19 && age <= 59)
                {
                    if (gender == GenderEnum.Male)
                        return (kneeHeight * 1.19) + (armCircumference * 3.21) - 86.82;
                    else
                        return (kneeHeight * 1.01) + (armCircumference * 2.81) - 66.04;
                }
                else if (age >= 60 && age <= 80)
                {
                    if (gender == GenderEnum.Male)
                        return (kneeHeight * 1.10) + (armCircumference * 3.07) - 75.81;
                    else
                        return (kneeHeight * 1.09) + (armCircumference * 2.68) - 65.51;
                }
            }
            else
            {
                if (age >= 19 && age <= 59)
                {
                    if (gender == GenderEnum.Male)
                        return (kneeHeight * 1.09) + (armCircumference * 3.14) - 83.72;
                    else
                        return (kneeHeight * 1.24) + (armCircumference * 2.97) - 82.48;
                }
                else if (age >= 60 && age <= 80)
                {
                    if (gender == GenderEnum.Male)
                        return (kneeHeight * 0.44) + (armCircumference * 2.86) - 39.21;
                    else
                        return (kneeHeight * 1.50) + (armCircumference * 2.58) - 84.22;
                }
            }

            return 0;
        }
    }
}
