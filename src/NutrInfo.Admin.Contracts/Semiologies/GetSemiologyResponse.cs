using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Contracts.Semiologies
{
    public class GetSemiologyResponse
    {
        public IEnumerable<SemiologyResponse> Semiologies { get; set; }
    }
}
