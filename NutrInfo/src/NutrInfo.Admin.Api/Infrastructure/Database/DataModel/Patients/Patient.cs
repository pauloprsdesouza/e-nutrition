using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public class Patient
    {
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
