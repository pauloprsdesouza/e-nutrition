using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Contracts.Nutritionists
{
    public class PostSignInRequest
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Password { get; set; }

        public Nutritionist ToUser()
        {
            return new Nutritionist
            {
                User = new User()
                {
                    Cpf = Cpf
                },
                Password = Password
            };
        }
    }
}
