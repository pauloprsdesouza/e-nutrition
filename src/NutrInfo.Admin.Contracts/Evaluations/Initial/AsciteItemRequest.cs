using System.ComponentModel.DataAnnotations;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class AsciteItemRequest
    {
        public int AsciteDegreeId { get; set; }

        [MaxLength(50)]
        public string Reason { get; set; }

        public bool HasAsciticWeight { get; set; }
        public bool HasPeripheralEdema { get; set; }
    }
}
