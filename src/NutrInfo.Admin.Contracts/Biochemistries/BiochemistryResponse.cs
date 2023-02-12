using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Contracts.Biochemistries
{
    public class BiochemistryResponse
    {
        public int Id { get; set; }
        public string HealthExam { get; set; }
        public double MinimumThreshold { get; set; }
        public double MaximumThreshold { get; set; }
        public string PossibleMeanings { get; set; }
    }
}
