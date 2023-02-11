using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.ClinicalChanges
{
    public class ClinicalChange
    {
        public int Id { get; set; }
        public string BodyRegion { get; set; }
        public string SignsAndSymptoms { get; set; }
        public string PossibleMeaning { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
