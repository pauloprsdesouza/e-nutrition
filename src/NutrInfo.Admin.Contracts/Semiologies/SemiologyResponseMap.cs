using Nutrinfo.Admin.Domain.Semiologies;

namespace NutrInfo.Admin.Contracts.Semiologies
{
    public static class SemiologyResponseMap
    {
        public static SemiologyResponse MapToResponse(this Semiology semiology)
        {
            return new SemiologyResponse()
            {
                Id = semiology.Id,
                Hint = semiology.Hint,
                BodyRegion = semiology.BodyRegion
            };
        }
    }
}
