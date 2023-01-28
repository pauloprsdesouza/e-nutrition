using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Contracts.Patients.WeightHeightEstimation
{
    public class GetWeightHeightEstimationQuery
    {
        public double ArmCircunference { get; set; }
        public double KneeHeight { get; set; }
    }
}
