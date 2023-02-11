using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Semiologies;

namespace Nutrinfo.Admin.Domain.NutritionalStatesSemiology
{
    public class NutritionalStateSemiology
    {
        public int Id { get; set; }
        public int SemiologyId { get; set; }
        public NutritionalStatesSemiologyEnum NutritionalState { get; set; }
        public string Description { get; set; }

        public Semiology Semiology { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}
