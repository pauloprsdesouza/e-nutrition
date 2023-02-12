using Nutrinfo.Admin.Domain.ClinicalChanges;

namespace Nutrinfo.Admin.Domain.SignsAndSymptoms
{
    public class SignAndSymptom
    {
        public int Id { get; set; }
        public int ClinicalChangeId { get; set; }
        public string Description { get; set; }
        public string PossibleMeanings { get; set; }

        public ClinicalChange ClinicalChange { get; set; }
    }
}
