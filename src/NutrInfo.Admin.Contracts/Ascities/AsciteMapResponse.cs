using Nutrinfo.Admin.Domain.AsciteDegrees;

namespace NutrInfo.Admin.Contracts.Ascities
{
    public static class AsciteMapResponse
    {
        public static AsciteResponse MapToResponse(this AsciteDegree ascite)
        {
            return new AsciteResponse()
            {
                Id = ascite.Id,
                Degree = ascite.Degree,
                AscitWeight = ascite.AsciticWeight,
                PeripheralEdema = ascite.PeripheralEdema
            };
        }
    }
}
