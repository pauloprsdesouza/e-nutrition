using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace NutrInfo.Admin.Contracts.NutritionalStatesSemiology
{
    public static class NutritionalStateSemiologyResponseMap
    {
        public static NutritionalStateSemiologyResponse MapToResponse(this NutritionalStateSemiology nutritionalStateSemiology)
        {
            return new NutritionalStateSemiologyResponse()
            {
                Id = nutritionalStateSemiology.Id,
                BodyRegion = nutritionalStateSemiology.Semiology.BodyRegion,
                SemiologyId = nutritionalStateSemiology.SemiologyId,
                Description = nutritionalStateSemiology.Description,
                NutritionalState = nutritionalStateSemiology.NutritionalState
            };
        }
    }
}
