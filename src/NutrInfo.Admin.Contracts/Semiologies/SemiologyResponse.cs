using Nutrinfo.Admin.Domain.Semiologies;
using NutrInfo.Admin.Contracts.NutritionalStatesSemiology;

namespace NutrInfo.Admin.Contracts.Semiologies
{
    public class SemiologyResponse
    {
        public int Id { get; set; }
        public string Hint { get; set; }
        public string BodyRegion { get; set; }
        public SemiologyGroupEnum Group { get; set; }
        public List<NutritionalStateSemiologyResponse> NutritionalStates { get; set; }
    }
}
