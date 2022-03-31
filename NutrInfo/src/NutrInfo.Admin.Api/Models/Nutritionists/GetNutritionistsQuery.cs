using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutrInfo.Admin.Api.Models.Nutritionists
{
    public class GetNutritionistsQuery
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Crn
        /// </summary>
        public int Crn { get; set; }
    }
}
