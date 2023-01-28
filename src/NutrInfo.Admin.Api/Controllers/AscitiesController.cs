using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.AmputatedLimbsPercentage;
using NutrInfo.Admin.Contracts.Ascities;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/ascities")]
    public class AscitiesController : Controller
    {
        private readonly IAsciteDegreeRepository _ascities;

        public AscitiesController(IAsciteDegreeRepository ascities)
        {
            _ascities = ascities;
        }

        /// <summary>
        /// Get all registered amputated limbs
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetAsciteResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var ascities = await _ascities.FindAll();

            return Ok(new GetAsciteResponse()
            {
                Ascities = ascities.Select(x => x.MapToResponse())
            });
        }
    }
}
