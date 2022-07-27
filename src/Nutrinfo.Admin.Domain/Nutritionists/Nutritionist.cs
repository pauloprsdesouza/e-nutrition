using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Nutritionists
{
    public class Nutritionist
    {
        public int UserId { get; set; }
        public int Crn { get; set; }
        public string Password { get; set; }

        public User User { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
