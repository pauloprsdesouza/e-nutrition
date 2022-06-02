using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Infrastructure.Formulas
{
    public static class HeightEstimation
    {
        public static double EstimateHeightByRaceAgeGender(RaceEnum race, int age, GenderEnum gender, double kneeHeight, double armCircumference)
        {
            if (race == RaceEnum.White)
            {
                if (age >= 19 && age <= 59)
                {
                    return gender == GenderEnum.Male ? 71.85 + (1.88 * kneeHeight) : 70.25 + (1.87 * kneeHeight) - (0.06 * age);
                }
                else if (age >= 60 && age <= 80)
                {
                    return gender == GenderEnum.Male ? 59.01 + (2.08 * kneeHeight) : 70 + (1.91 * kneeHeight) - (0.17 * age);
                }
            }
            else
            {
                if (age >= 19 && age <= 59)
                {
                    return gender == GenderEnum.Male ? 73.42 + (1.79 * kneeHeight) : 68.1 + (1.86 * kneeHeight) - (0.06 * age);
                }
                else if (age >= 60 && age <= 80)
                {
                    return gender == GenderEnum.Male ? 95.79 + (1.37 * kneeHeight) : 58.72 + (1.96 * kneeHeight);
                }
            }

            return 0;
        }
    }
}
