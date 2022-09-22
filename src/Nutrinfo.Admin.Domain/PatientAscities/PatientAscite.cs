using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.PatientAscities
{
    public class PatientAscite
    {
        public int AsciteDegreeId { get; set; }
        public int EvaluationId { get; set; }
        public bool HasAsciticWeight { get; set; }
        public bool HasPeripheralEdema { get; set; }

        public AsciteDegree AsciteDegree { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
