using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Patients;

namespace NutrInfo.Admin.Contracts.Patients
{
    public class PutPatientRequest
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

        public void MapTo(Patient patient)
        {
            patient.User.Name = Name;
            patient.User.Email = Email;
            patient.User.Cpf = Cpf;
            patient.User.Address.City = City;
            patient.User.Address.Complement = Complement;
            patient.User.Address.Neighborhood = Neighborhood;
            patient.User.Address.Number = Number;
            patient.User.Address.State = State;
            patient.User.Address.Street = Street;
            patient.User.Address.ZipCode = ZipCode;
        }
    }
}
