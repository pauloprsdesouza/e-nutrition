using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.AmputatedLimbs
{
    public class AmputatedLimb
    {
        public int EvaluationId { get; set; }
        public int PatientId { get; set; }
        public int AmputatedLimbPercentageId { get; set; }
        public string Reason { get; set; }

        public Evaluation Evaluation { get; set; }
        public Patient Patient { get; set; }
        public AmputatedLimbPercentage LimbPercentage { get; set; }
    }
}
