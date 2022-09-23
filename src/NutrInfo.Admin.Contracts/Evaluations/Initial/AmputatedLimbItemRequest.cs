using System.ComponentModel.DataAnnotations;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class AmputatedLimbItemRequest
    {
        public int AmputatedLimbPercentageId { get; set; }

        [MaxLength(50)]
        public string Reason { get; set; }
    }
}
