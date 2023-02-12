using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.SignsAndSymptoms;

namespace Nutrinfo.Admin.Domain.ClinicalChanges
{
    public class ClinicalChange
    {
        public int Id { get; set; }
        public string BodyRegion { get; set; }

        public List<Evaluation> Evaluations { get; set; }
        public List<SignAndSymptom> SignsAndSymptoms { get; set; }
    }
}
