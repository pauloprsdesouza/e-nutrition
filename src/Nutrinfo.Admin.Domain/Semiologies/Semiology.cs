using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace Nutrinfo.Admin.Domain.Semiologies
{
    public class Semiology
    {
        public int Id { get; set; }
        public string Hint { get; set; }
        public SemiologyGroupEnum Group { get; set; }

        public List<NutritionalStateSemiology> NutritionalStates { get; set; }
    }
}
