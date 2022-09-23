using Nutrinfo.Admin.Domain.Ascites;

namespace Nutrinfo.Admin.Domain.AsciteDegrees
{
    public class AsciteDegree
    {
        public int Id { get; set; }
        public AsciteDegreeEnum Degree { get; set; }
        public double AsciticWeight { get; set; }
        public double PeripheralEdema { get; set; }

        public List<Ascite> Ascites { get; set; }
    }
}
