using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Addresses;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Models.Patients
{
    public class PostPatientRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        [Required]
        public int Number { get; set; }

        public Patient ToPatient()
        {
            var address = new Address()
            {
                City = City,
                Complement = Complement,
                Neighborhood = Neighborhood,
                Number = Number,
                State = State,
                Street = Street,
                ZipCode = ZipCode,
            };

            var user = new User()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf,
                Address = address
            };

            return new Patient()
            {
                User = user,
            };
        }
    }
}
