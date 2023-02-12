using Nutrinfo.Admin.Domain.Semiologies;

namespace NutrInfo.Admin.Contracts.Semiologies
{
    public class SemiologyResponse
    {
        public int Id { get; set; }
        public string Hint { get; set; }
        public string BodyRegion { get; set; }
        public SemiologyGroupEnum Group { get; set; }
    }
}
