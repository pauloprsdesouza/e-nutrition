using Nutrinfo.Admin.Domain.Patients;

namespace Nutrinfo.Admin.Domain.Limbs
{
    public class Limb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentil { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
