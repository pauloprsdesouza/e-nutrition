using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Formulas
{
    public class WeightEstimation
    {
        public static double EstimateWeightByRaceAgeGender(RaceEnum race, int age, GenderEnum gender, double kneeHeight, double armCircumference)
        {
            if (race == RaceEnum.WHITE)
            {
                if (age is >= 19 and <= 59)
                {
                    return gender == GenderEnum.MALE
                        ? (kneeHeight * 1.19) + (armCircumference * 3.21) - 86.82
                        : (kneeHeight * 1.01) + (armCircumference * 2.81) - 66.04;
                }
                else if (age is >= 60 and <= 80)
                {
                    return gender == GenderEnum.MALE
                        ? (kneeHeight * 1.10) + (armCircumference * 3.07) - 75.81
                        : (kneeHeight * 1.09) + (armCircumference * 2.68) - 65.51;
                }
            }
            else
            {
                if (age is >= 19 and <= 59)
                {
                    return gender == GenderEnum.MALE
                        ? (kneeHeight * 1.09) + (armCircumference * 3.14) - 83.72
                        : (kneeHeight * 1.24) + (armCircumference * 2.97) - 82.48;
                }
                else if (age is >= 60 and <= 80)
                {
                    return gender == GenderEnum.MALE
                        ? (kneeHeight * 0.44) + (armCircumference * 2.86) - 39.21
                        : (kneeHeight * 1.50) + (armCircumference * 2.58) - 84.22;
                }
            }

            return 0;
        }
    }
}
