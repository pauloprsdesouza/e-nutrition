using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class GetWeightHeightEstimationRequest
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public double KneeHeight { get; set; }

        [Required]
        public double ArmCircumference { get; set; }
    }
}
