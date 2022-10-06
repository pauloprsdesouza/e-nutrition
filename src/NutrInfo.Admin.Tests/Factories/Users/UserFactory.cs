using Bogus;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Tests.Factories.Users
{
    public static class UserFactory
    {
        public static User Build(this User user)
        {
            var userFaker = new Faker<User>()
            .RuleFor(p => p.Name, f => f.Person.FullName)
            .RuleFor(p => p.Cpf, f => f.Random.Replace("###.###.###-##"))
            .RuleFor(p => p.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(p => p.Email, f => f.Person.Email)
            .RuleFor(p => p.Gender, f => f.PickRandom<GenderEnum>())
            .RuleFor(p => p.Status, f => UserStatusEnum.ACTIVE)
            .RuleFor(p => p.CreatedAt, f => System.DateTimeOffset.UtcNow);

            return userFaker.Generate();
        }
    }
}
