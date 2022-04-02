using System;
using System.Collections.Generic;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists
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
