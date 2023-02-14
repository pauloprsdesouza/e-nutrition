using Nutrinfo.Admin.Domain.SignsAndSymptoms;
using NutrInfo.Admin.Contracts.SignsAndSymptoms;

namespace NutrInfo.Admin.Contracts.ClinicalChanges
{
    public class ClinicalChangeResponse
    {
        public int Id { get; set; }
        public string BodyRegion { get; set; }

        public List<SignAndSymptomResponse> SignsAndSymptoms { get; set; }
    }
}
