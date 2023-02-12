using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Contracts.ClinicalChanges
{
    public class GetClinicalChangeResponse
    {
        public IEnumerable<ClinicalChangeResponse> ClinicalChanges { get; set; }
    }
}
