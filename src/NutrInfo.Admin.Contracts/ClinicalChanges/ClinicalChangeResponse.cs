using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Contracts.ClinicalChanges
{
    public class ClinicalChangeResponse
    {
         public int Id { get; set; }
        public string BodyRegion { get; set; }
    }
}
