using Bogus;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Tests.Factories.Addresses
{
    public static class AddressFactory
    {
        public static Address Build(this Address address)
        {
            var addressFaker = new Faker<Address>()
            .RuleFor(p => p.City, f => f.Address.City())
            .RuleFor(p => p.Street, f => f.Address.StreetAddress())
            .RuleFor(p => p.Complement, f => f.Address.FullAddress())
            .RuleFor(p => p.Neighborhood, f => f.Address.State())
            .RuleFor(p => p.Number, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.State, f => f.Address.State());

            return addressFaker.Generate();
        }

        public static Address WithUser(this Address address, User user)
        {
            address.User = user;
            address.UserId = user.Id;

            return address;
        }
    }
}
