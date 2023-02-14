using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.AmputatedLimbs;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class PutEvaluationAmputatedLimbRequest
    {
        public int AmputatedLimbPercentageId { get; set; }

        [MaxLength(50)]
        public string Reason { get; set; }

        public AmputatedLimb ToAmputatedLimb(int evaluationId)
        {
            return new AmputatedLimb()
            {
                EvaluationId = evaluationId,
                AmputatedLimbPercentageId = AmputatedLimbPercentageId,
                Reason = Reason
            };
        }
    }
}
