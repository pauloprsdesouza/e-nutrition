using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class PostNutritionistRequest
    {
        [Required]
        [MaxLength(200)]
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

        public Nutritionist ToNutritionist()
        {
            var user = new User()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf
            };

            return new Nutritionist()
            {
                Crn = Crn,
                User = user,
                Password = Password
            };
        }
    }
}
