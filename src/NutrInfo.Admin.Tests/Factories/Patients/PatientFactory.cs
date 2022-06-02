using Bogus;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Tests.Factories.Patients
{
    public static class PatientFactory
    {
        public static Patient Build(this Patient patient)
        {
            var patientFaker = new Faker<Patient>()
            .RuleFor(p => p.Race, f => f.PickRandom<RaceEnum>());

            return patientFaker.Generate();
        }

        public static Patient WithUser(this Patient patient, User user)
        {
            patient.User = user;
            patient.UserId = user.Id;

            return patient;
        }
    }
}
