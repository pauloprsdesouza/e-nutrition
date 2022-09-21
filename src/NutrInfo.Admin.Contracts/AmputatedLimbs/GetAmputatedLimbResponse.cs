using System.Collections.Generic;

namespace NutrInfo.Admin.Api.Models.AmputatedLimbs
{
    public class GetAmputatedLimbResponse
    {
        public IEnumerable<AmputatedLimbResponse> AmputatedLimbs { get; set; }
    }
}
