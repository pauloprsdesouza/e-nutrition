using Nutrinfo.Admin.Domain.AsciteDegrees;

namespace NutrInfo.Admin.Contracts.Ascities
{
    public class AsciteResponse
    {
        public int Id { get; set; }
        public AsciteDegreeEnum Degree { get; set; }
        public double AscitWeight { get; set; }
        public double PeripheralEdema { get; set; }
    }
}
