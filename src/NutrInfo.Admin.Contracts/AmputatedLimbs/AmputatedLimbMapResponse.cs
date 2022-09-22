using Nutrinfo.Admin.Domain.Limbs;

namespace NutrInfo.Admin.Contracts.AmputatedLimbs
{
    public static class AmputatedLimbMapResponse
    {
        public static AmputatedLimbResponse MapToResponse(this Limb amputatedLimb)
        {
            return new AmputatedLimbResponse()
            {
                Id = amputatedLimb.Id,
                Name = amputatedLimb.Name,
                Percentil = amputatedLimb.Percentil
            };
        }
    }
}
