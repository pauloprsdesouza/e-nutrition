using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.Patients
{
    public class Patient
    {
        public int UserId { get; set; }
        public RaceEnum Race { get; set; }

        public User User { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
