
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Addresses
{
    public class Address
    {
        public int UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int Number { get; set; }

        public User User { get; set; }
    }
}
