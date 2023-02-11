using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Domain.Biochemistries
{
    public class Biochemistry
    {
        public int Id { get; set; }
        public string HealthExam { get; set; }
        public double MinimumThreshold { get; set; }
        public double MaximumThreshold { get; set; }
        public string PossibleMeanings { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
