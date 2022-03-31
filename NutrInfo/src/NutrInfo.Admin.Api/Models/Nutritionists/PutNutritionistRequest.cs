using System.ComponentModel.DataAnnotations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;

namespace NutrInfo.Admin.Api.Models.Nutritionists
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
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Crn { get; set; }

        public void MapTo(Nutritionist nutritionist)
        {
            nutritionist.Crn = Crn;
            nutritionist.Name = Name;
            nutritionist.Email = Email;
            nutritionist.Password = Password;
        }
    }
}
