using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace NutrInfo.Admin.Contracts.Evaluations.Initial
{
    public class NutritionalStateSemiologyRequest
    {
        public int Id { get; set; }
        public int SemiologyId { get; set; }
        public NutritionalStatesSemiologyEnum NutritionalState { get; set; }

        public NutritionalStateSemiology ToNutritionalStateSemiology()
        {
            return new NutritionalStateSemiology()
            {
                Id = Id,
                SemiologyId = SemiologyId,
                NutritionalState = NutritionalState
            };
        }
    }
}
