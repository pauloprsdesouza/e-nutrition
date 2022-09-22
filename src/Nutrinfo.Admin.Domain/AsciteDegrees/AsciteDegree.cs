using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.AsciteDegrees
{
    public class AsciteDegree
    {
        public int Id { get; set; }
        public AsciteDegreeEnum Degree { get; set; }
        public double AsciticWeight { get; set; }
        public double PeripheralEdema { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}
