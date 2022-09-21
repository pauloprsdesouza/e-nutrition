using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Patients
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
        public DateTime BirthDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public int Number { get; set; }

        public Patient ToPatient()
        {
            var user = new User()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf,
                BirthDate = BirthDate
            };

            return new Patient()
            {
                User = user,
            };
        }
    }
}
