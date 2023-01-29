using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Patients
{
    public class Patient
    {
        public Patient()
        {
            Evaluations = new();
            AmputatedLimbs = new();
        }

        public int UserId { get; set; }
        public RaceEnum Race { get; set; }

        public User User { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<AmputatedLimb> AmputatedLimbs { get; set; }
    }
}
