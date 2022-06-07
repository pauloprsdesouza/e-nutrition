using System.Collections.Generic;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs
{
    public class AmputatedLimb
    {
        public int Id { get; set; }
        public string Limb { get; set; }
        public double Percentual { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
