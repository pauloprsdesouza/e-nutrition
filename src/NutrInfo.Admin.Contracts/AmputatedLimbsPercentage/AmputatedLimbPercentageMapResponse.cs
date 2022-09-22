using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;

namespace NutrInfo.Admin.Contracts.AmputatedLimbsPercentage
{
    public static class AmputatedLimbPercentageMapResponse
    {
        public static AmputatedLimbPercentageResponse MapToResponse(this AmputatedLimbPercentage limbPercentage)
        {
            return new AmputatedLimbPercentageResponse()
            {
                Id = limbPercentage.Id,
                Name = limbPercentage.Name,
                Percentil = limbPercentage.Percentage
            };
        }
    }
}
