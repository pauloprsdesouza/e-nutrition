using System.ComponentModel.DataAnnotations;
using Nutrinfo.Admin.Domain.Ascites;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class AsciteItemRequest
    {
        public int AsciteDegreeId { get; set; }

        [MaxLength(50)]
        public string Reason { get; set; }

        public bool HasAsciticWeight { get; set; }
        public bool HasPeripheralEdema { get; set; }

        public Ascite ToAscite(int evaluationId)
        {
            return new Ascite()
            {
                EvaluationId = evaluationId,
                AsciteDegreeId = AsciteDegreeId,
                Reason = Reason,
                HasPeripheralEdema = HasPeripheralEdema,
                HasAsciticWeight = HasAsciticWeight
            };
        }
    }
}
