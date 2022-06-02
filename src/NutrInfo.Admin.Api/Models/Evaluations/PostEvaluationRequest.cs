using System.ComponentModel.DataAnnotations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;

namespace NutrInfo.Admin.Api.Models.Evaluations
{
    public class PostEvaluationRequest
    {
        [Required]
        public int PatientId { get; set; }

        public Evaluation ToEvaluation()
        {
            return new Evaluation()
            {
                PatientId = PatientId
            };
        }
    }
}
