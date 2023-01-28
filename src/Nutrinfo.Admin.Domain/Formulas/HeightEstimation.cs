using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Formulas
{
    public static class HeightEstimation
    {
        public static double EstimateHeightByRaceAgeGender(RaceEnum race, int age, GenderEnum gender, double kneeHeight)
        {
            if (race == RaceEnum.WHITE)
            {
                if (age is >= 19 and <= 59)
                {
                    return gender == GenderEnum.MALE ? 71.85 + (1.88 * kneeHeight) : 70.25 + (1.87 * kneeHeight) - (0.06 * age);
                }
                else if (age is >= 60 and <= 80)
                {
                    return gender == GenderEnum.MALE ? 59.01 + (2.08 * kneeHeight) : 70 + (1.91 * kneeHeight) - (0.17 * age);
                }
            }
            else
            {
                if (age is >= 19 and <= 59)
                {
                    return gender == GenderEnum.MALE ? 73.42 + (1.79 * kneeHeight) : 68.1 + (1.86 * kneeHeight) - (0.06 * age);
                }
                else if (age is >= 60 and <= 80)
                {
                    return gender == GenderEnum.MALE ? 95.79 + (1.37 * kneeHeight) : 58.72 + (1.96 * kneeHeight);
                }
            }

            return 0;
        }
    }
}
