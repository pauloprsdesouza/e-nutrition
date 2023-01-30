using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Domain.CircumferencePercentils
{
    public class ArmCircumferencePercentil
    {
        public int Id { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public double P5 { get; set; }
        public double P10 { get; set; }
        public double P15 { get; set; }
        public double P25 { get; set; }
        public double P50 { get; set; }
        public double P75 { get; set; }
        public double P85 { get; set; }
        public double P90 { get; set; }
        public double P95 { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
