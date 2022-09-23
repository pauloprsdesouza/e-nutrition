using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.Ascites
{
    public class Ascite
    {
        public int EvaluationId { get; set; }
        public int AsciteDegreeId { get; set; }
        public bool HasAsciticWeight { get; set; }
        public bool HasPeripheralEdema { get; set; }
        public string Reason { get; set; }

        public Evaluation Evaluation { get; set; }
        public AsciteDegree AsciteDegree { get; set; }
    }
}
