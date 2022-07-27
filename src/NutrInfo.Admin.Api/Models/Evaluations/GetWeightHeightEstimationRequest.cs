using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public List<int> AmputatedLimbs { get; set; }
    }
}
