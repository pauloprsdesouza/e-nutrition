using Nutrinfo.Admin.Domain.AmputatedLimbs;

namespace Nutrinfo.Admin.Domain.AmputatedLimbsPercentage
{
    public class AmputatedLimbPercentage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

        public List<AmputatedLimb> AmputatedLimbs { get; set; }
    }
}
