using Nutrinfo.Admin.Domain.Biochemistries;
using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.BiochemistryResults
{
    public class BiochemistryResult
    {
        public int BiochemistryId { get; set; }
        public int EvaluationId { get; set; }
        public double Result { get; set; }

        public Evaluation Evaluation { get; set; }
        public Biochemistry Biochemistry { get; set; }
    }
}
