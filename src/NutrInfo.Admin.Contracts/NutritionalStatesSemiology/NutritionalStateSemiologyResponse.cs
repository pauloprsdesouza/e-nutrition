using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace NutrInfo.Admin.Contracts.NutritionalStatesSemiology
{
    public class NutritionalStateSemiologyResponse
    {
        public int Id { get; set; }
        public int SemiologyId { get; set; }
        public NutritionalStatesSemiologyEnum NutritionalState { get; set; }
        public string Description { get; set; }
        public string BodyRegion { get; set; }
    }
}
