using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;
using NutrInfo.Admin.Contracts;
using NutrInfo.Admin.Contracts.AmputatedLimbsPercentage;

namespace NutrInfo.Admin.Api.Controllers
{
    [Route("api/v1/amputatedlimbspercentage")]
    public class AmputatedLimbsPercentageController : Controller
    {
        private readonly IAmputatedLimbPercentageRepository _repository;

        public AmputatedLimbsPercentageController(IAmputatedLimbPercentageRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all registered amputated limbs
        /// </summary>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetAmputatedLimbPercentageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> List()
        {
            var amputatedLimbs = await _repository.FindAll();

            return Ok(new GetAmputatedLimbPercentageResponse()
            {
                LimbsPercentage = amputatedLimbs.Select(x => x.MapToResponse())
            });
        }
    }
}
