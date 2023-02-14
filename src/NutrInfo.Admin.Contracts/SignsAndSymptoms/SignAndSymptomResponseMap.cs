using Nutrinfo.Admin.Domain.SignsAndSymptoms;

namespace NutrInfo.Admin.Contracts.SignsAndSymptoms
{
    public static class SignAndSymptomResponseMap
    {
        public static SignAndSymptomResponse MapToResponse(this SignAndSymptom signAndSymptom)
        {
            return new SignAndSymptomResponse()
            {
                Id = signAndSymptom.Id,
                Description = signAndSymptom.Description,
                PossibleMeanings = signAndSymptom.PossibleMeanings,
                ClinicalChangeId = signAndSymptom.ClinicalChangeId
            };
        }
    }
}
