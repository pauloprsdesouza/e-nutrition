using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class PutNutritionistRequest
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
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Crn { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public int Number { get; set; }

        public void MapTo(Nutritionist nutritionist)
        {
            nutritionist.Crn = Crn;
            nutritionist.User.Name = Name;
            nutritionist.User.Email = Email;
            nutritionist.User.Cpf = Cpf;
            nutritionist.Password = Password;
            nutritionist.User.BirthDate = BirthDate;
            nutritionist.User.Address.City = City;
            nutritionist.User.Address.Complement = Complement;
            nutritionist.User.Address.Neighborhood = Neighborhood;
            nutritionist.User.Address.Number = Number;
            nutritionist.User.Address.State = State;
            nutritionist.User.Address.Street = Street;
            nutritionist.User.Address.ZipCode = ZipCode;
        }
    }
}
