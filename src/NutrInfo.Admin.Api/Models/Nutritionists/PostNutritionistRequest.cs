using System.ComponentModel.DataAnnotations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Addresses;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Models.Nutritionists
{
    public class PostNutritionistRequest
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

        public Nutritionist ToNutritionist()
        {
            Address address = new Address()
            {
                City = City,
                Complement = Complement,
                Neighborhood = Neighborhood,
                Number = Number,
                State = State,
                Street = Street,
                ZipCode = ZipCode,
            };

            User user = new User()
            {
                Name = Name,
                Email = Email,
                Cpf = Cpf,
                Address = address
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
