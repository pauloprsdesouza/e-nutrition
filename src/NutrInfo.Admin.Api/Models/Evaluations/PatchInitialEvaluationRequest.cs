using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class PatchInitialEvaluationRequest
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool IsWalking { get; set; }
        public bool HasEdema { get; set; }
        public bool HasAscites { get; set; }
        public bool HasAmputatedLimb { get; set; }
    }
}
