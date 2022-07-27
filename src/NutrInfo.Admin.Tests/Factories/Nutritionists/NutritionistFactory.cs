using Bogus;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Tests.Factories.Nutritionists
{
    public static class NutritionistFactory
    {
        public static Nutritionist Build(this Nutritionist nutritionist)
        {
            var nutritionistFaker = new Faker<Nutritionist>()
            .RuleFor(p => p.Crn, f => f.Random.Int(1, 500))
            .RuleFor(p => p.Password, f => f.Internet.Password());

            return nutritionistFaker.Generate();
        }

        public static Nutritionist WithUser(this Nutritionist nutritionist, User user)
        {
            nutritionist.User = user;
            nutritionist.UserId = user.Id;

            return nutritionist;
        }
    }
}
