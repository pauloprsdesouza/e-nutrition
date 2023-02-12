using Nutrinfo.Admin.Domain.ClinicalChanges;

namespace NutrInfo.Admin.Contracts.ClinicalChanges
{
    public static class ClinicalChangeResponseMap
    {
        public static ClinicalChangeResponse MapToResponse(this ClinicalChange clinicalChange)
        {
            return new ClinicalChangeResponse()
            {
                Id = clinicalChange.Id,
                BodyRegion = clinicalChange.BodyRegion
            };
        }
    }
}
