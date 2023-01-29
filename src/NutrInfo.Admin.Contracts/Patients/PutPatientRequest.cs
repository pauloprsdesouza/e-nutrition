using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Patients
{
    public class PutPatientRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public int MedicalRecord { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public RaceEnum Race { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public UserStatusEnum Status { get; set; }


        public Patient ToPatient()
        {
            var user = new User()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf,
                BirthDate = BirthDate,
                Gender = Gender,
                Status = Status
            };

            return new Patient()
            {
                User = user,
                Race = Race,
                MedicalRecord = MedicalRecord
            };
        }
    }
}
