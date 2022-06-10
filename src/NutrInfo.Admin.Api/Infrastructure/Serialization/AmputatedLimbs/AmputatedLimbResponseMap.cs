using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs;
using NutrInfo.Admin.Api.Models.AmputatedLimbs;

namespace NutrInfo.Admin.Api.Infrastructure.Serialization.AmputatedLimbs
{
    public static class AmputatedLimbResponseMap
    {
        public static AmputatedLimbResponse MapToResponse(this AmputatedLimb amputatedLimb)
        {
            return new AmputatedLimbResponse()
            {
                Id = amputatedLimb.Id,
                Limb = amputatedLimb.LimbName,
                Percentual = amputatedLimb.Percentual
            };
        }
    }
}
