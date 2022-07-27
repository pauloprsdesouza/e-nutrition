using System;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Nutritionist Nutritionist { get; set; }
        public Patient Patient { get; set; }
        public Address Address { get; set; }
    }
}
